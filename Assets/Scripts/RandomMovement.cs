using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {
    public MeshFilter filter;
    private Mesh mesh;
    private Vector2 rangeX;
    private Vector2 rangeZ;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float changeDirectionDelay;
    private float timer;
    private Vector3 destination;

    private void Awake()
    {
        mesh = filter.mesh;
        float width = mesh.bounds.extents.x * filter.transform.localScale.x;
        float height = mesh.bounds.extents.z * filter.transform.localScale.z;
        rangeX = new Vector2 (filter.transform.position.x - width, filter.transform.position.x + width);
        rangeZ = new Vector2(filter.transform.position.z - width, filter.transform.position.z + height);

    }

    void Update () {
        if (Vector3.Distance(transform.position, destination) < 0.5)
        {
            timer = 0; //will cause a new destination to be selected
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = changeDirectionDelay;
            SetDestination();
        }

        MoveToDestination();
    }

    void SetDestination()
    {
        float destinationX = Random.Range(rangeX.x, rangeX.y);
        float destinationZ = Random.Range(rangeZ.x, rangeZ.y);
        destination = new Vector3(destinationX, transform.position.y, destinationZ);
    }

    void MoveToDestination()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
    }
}
