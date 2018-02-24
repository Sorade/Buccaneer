using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Mission
{
    MERCHANT,
    HUNTER,
}

[RequireComponent(typeof(FlottillaMotor))]
public class FlottillaController : MonoBehaviour {
    private FlottillaStats stats;
    private FlottillaMotor motor;
    private Collider col;

    private PortController currentPort;

    private void Awake()
    {
        stats = GetComponent<FlottillaStats>();
        motor = GetComponent<FlottillaMotor>();
        col = GetComponent<Collider>();
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
                currentPort = other.gameObject.GetComponent<PortController>();
                StartCoroutine(DelayedPortInteraction());
                break;
            case "Player":
                Debug.Log("Interact with " + other.gameObject.name);
                break;
            default:
                break;
        }
    }

    IEnumerator DelayedPortInteraction()
    {
        transform.Find("GFX").gameObject.SetActive(false);
        this.enabled = false;
        yield return new WaitForSeconds(stats.stayDelay);
        this.enabled = true;
        transform.rotation = Quaternion.LookRotation(-transform.forward, Vector3.up);
        transform.Find("GFX").gameObject.SetActive(true);
        motor.MoveToPoint(currentPort.RequestDestination(stats.mission));
    }
}
