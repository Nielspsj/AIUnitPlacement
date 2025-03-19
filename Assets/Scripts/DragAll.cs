using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAll : MonoBehaviour
{
    //Test1: Mouse input in an if-statement.
    //Test2: Create a Physics2D.Raycast that sends a ray.
    //Test3: Check if we hit anything.
    //Test4: Create a variable to store the thing we hit and want to drag. Store the hit info.
    //Test5: Empty the dragging variable when we release the mouse button.
    //Test6: Offset the position of the object being dragged?? (we need the object's original z-position).
    
    private Transform draggingTF = null;
    private Vector3 offset;
  
    // Update is called once per frame
    void Update()
    {
        SendRay();
    }
    private void SendRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Store hit information of the object we hit. It must have a collider.
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit == true)
            {
                //Store the object we hit into a dragging transform variable.
                draggingTF = hit.transform;
                //Store the offset because we need the z-position of the object.
                offset = draggingTF.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        //Empty the storage of the dragging variable when we release the mouse.
        else if (Input.GetMouseButtonUp(0))
        {
            draggingTF = null;
        }
        //If we have an object stored in the dragging variable: Change the position.
        if (draggingTF != null)
        {
            draggingTF.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}
