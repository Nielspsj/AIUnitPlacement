using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    //List of waypoints to move between.
    public List<Transform> waypoints = new List<Transform>();
    //Start at 0, meaning the first in the list.
    private int waypointIndex = 0;
    //The target to move towards.
    private Vector2 target;
    //The speed to move at.
    private float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //Set the target to move towards when we start the scene.
        target = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWaypointMovement();
    }
    private void UpdateWaypointMovement()
    {
        Movement();
        //Check if we are close enough to the target location to change targets.
        if(Vector2.Distance(transform.position, target) < 0.1f)
        {
            NextWaypointIndex();
            //Set the new target to move towards.
            target = waypoints[waypointIndex].position;
        }
    }   
    private void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    //Go to the next index in the list.
    //Reset index if we reach the end of the list. Thus start over on the list.
    private void NextWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Count)
        {
            waypointIndex = 0;
        }
    }
}
