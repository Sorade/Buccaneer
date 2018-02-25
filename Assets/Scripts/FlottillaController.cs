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
    private GameController gc;
    private FlottillaStats stats;
    private FlottillaMotor motor;
    private Collider col;
    private PlayerCombat playerCombat;

    private PortController currentPort;

    private void Awake()
    {
        stats = GetComponent<FlottillaStats>();
        motor = GetComponent<FlottillaMotor>();
        col = GetComponent<Collider>();
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Start()
    {
        motor.SetRandomDest();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.gameObject.name);

        string otherTag = other.gameObject.tag;
        switch (otherTag)
        {
            case "Port":
                Debug.Log("Interact with " + other.gameObject.name);
                ArriveInPort(other.gameObject.GetComponent<PortController>());
                break;
            case "Player":
                Debug.Log("Interact with " + other.gameObject.name);
                if (playerCombat.ResolveOutcome(stats))
                {
                    gc.gameObject.GetComponent<FlottillaPool>().Pool(this);
                    gc.flottillaInGame -= 1;
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
        transform.rotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
        Vector3 newDest = currentPort.RequestDestination(stats.mission);
        motor.MoveToPoint(newDest);
        currentPort = null;
        //StartCoroutine(SafetyColliderDisable());
    }

    public void ArriveInPort(PortController port){
        currentPort = port;
        currentPort.Dock(this);
    }

    IEnumerator SafetyColliderDisable()
    {
        col.enabled = false;
        yield return new WaitForSeconds(1f);
        col.enabled = true;
    }

}
