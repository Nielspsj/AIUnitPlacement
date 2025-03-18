  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{   

    // Update is called once per frame
    void Update()
    {
        //Create a variable for the hit information.
        RaycastHit hitInfo;
        //Create a variable for the ray (laser) we sound out.
        //Store in it the mouse position on our screen.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Send a physics raycast from our position and get whatever it hits.
        if(Physics.Raycast(ray, out hitInfo))
        {
            //Check for tag and is we push the left mouse button
            if(hitInfo.transform.tag == "Interactable" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Can interact with this");
                //Turn it green!
                hitInfo.transform.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}
