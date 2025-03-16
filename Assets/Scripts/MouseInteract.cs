  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteract : MonoBehaviour
{   

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hitInfo))
        {
            if(hitInfo.transform.tag == "Interactable" && Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Can interact with this");
                hitInfo.transform.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }
}
