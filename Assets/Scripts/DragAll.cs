using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAll : MonoBehaviour
{
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
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit == true)
            {
                draggingTF = hit.transform;
                offset = draggingTF.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            draggingTF = null;
        }
        if (draggingTF != null)
        {
            draggingTF.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        }
    }
}
