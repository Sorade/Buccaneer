using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mission
{
    MERCHANT,
    HUNTER,
    PLAYER
}

[RequireComponent(typeof(FlottillaMotor))]
public class FlottillaController : MonoBehaviour {
    private FlottillaStats stats;
    private FlottillaMotor motor;
    private Collider col;
    private PlayerCombat playerCombat;
    private Behaviour behaviour;

    private PortController currentPort;

    private void Awake()
    {
        stats = GetComponent<FlottillaStats>();
        motor = GetComponent<FlottillaMotor>();
        col = GetComponent<Collider>();
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        behaviour = GetComponent<Behaviour>();
    }

    void Update()
    {
        if (behaviour != null && currentPort == null)
        {
            behaviour.MissionRoutine();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Interactions(other);
    }

    private void Interactions(Collider other)
    {
        string otherTag = other.gameObject.tag;
        switch (otherTag)
        {
            case "Port":
                ArriveInPort(other.gameObject.GetComponent<PortController>());
                break;
            case "Player":
                //if player wins the battle
                if (playerCombat.ResolveOutcome(stats))
                {
                    GameController.instance.gameObject.GetComponent<FlottillaPool>().Pool(this);
                    GameController.instance.flottillaInGame -= 1;
                }
                break;
            default:
                break;
        }
    }

    public void Sleep()
    {
        transform.Find("GFX").gameObject.SetActive(false);
        this.enabled = false;
    }

    public void WakeUp() { 
        this.enabled = true;
        //transform.rotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
        transform.Find("GFX").gameObject.SetActive(true);
    }

    public void SetUp()
    {
        stats.SetUp();
    }

    public void LeavePort()
    {
        //checks that the flottilla in indeed in a port before leaving it
        if (currentPort != null)
        {
            transform.rotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
            Vector3 newDest = currentPort.RequestDestination(stats.mission);
            motor.MoveToPoint(newDest);
            currentPort = null;

        }
    }

    public void ArriveInPort(PortController port){
        currentPort = port;
        currentPort.Dock(this);
    }
}
