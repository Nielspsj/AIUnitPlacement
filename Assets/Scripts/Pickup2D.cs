using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup2D : MonoBehaviour
{
    public List<GameObject> inventoryList = new List<GameObject>();
    private GameObject pickedUpItem;
   

    private void AddToInventory()
    {
        inventoryList.Add(pickedUpItem);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Pickup")
        {
            pickedUpItem = other.gameObject;
            AddToInventory();
        }
    }
}
