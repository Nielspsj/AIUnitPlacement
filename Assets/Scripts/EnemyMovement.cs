using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public bool canMove = true;
    private int waypointIndex = 0;
    private Vector2 target;
    private Transform player;
    private float speed = 10f;
    private NavMeshAgent agent;
    private Vector2 lastTarget;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        SetupNavmeshAgent();

        UpdateWaypointDestination();
        agent.SetDestination(target);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            //UpdateMoveStraightToPlayer();
            UpdateWayPointMovement();
            //target = player.position;
            //UpdateNavmeshMovement();
        }
        else if (canMove == false)
        {
            target = transform.position;
            //UpdateNavmeshMovement();
            agent.SetDestination(target);
        }        
    }

    private void SetupNavmeshAgent()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //target = player.position;
    }
    private void UpdateNavmeshMovement()
    {
        agent.SetDestination(target);
    }

    private void UpdateMoveStraightToPlayer()
    {
        target = player.position;
        Movement();
    }

    private void UpdateWayPointMovement()
    {
        
        if (lastTarget == null)
        {
            //Movement();
            //UpdateNavmeshMovement();
        }
        else if(lastTarget != null)
        {
            target = lastTarget;
            //Movement();
            //UpdateNavmeshMovement();
        }
        
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            NextWaypointIndex();
            UpdateWaypointDestination();
            Debug.Log("next target");

        }
    }

    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    private void UpdateWaypointDestination()
    {
        target = waypoints[waypointIndex].position;
        lastTarget = target;
        UpdateNavmeshMovement();
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
