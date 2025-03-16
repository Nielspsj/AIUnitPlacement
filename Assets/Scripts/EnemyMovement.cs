using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private int waypointIndex = 0;
    private Vector2 target;
    private Transform player;
    private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Vector2.Distance(transform.position, target) < 0.1)
        {
            UpdateDestination();
            NextWaypointIndex();
        }
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
    }
    private void NextWaypointIndex()
    {
        waypointIndex++;
        if(waypointIndex == waypoints.Count)
        {
            waypointIndex = 0;
        }
    }
}
