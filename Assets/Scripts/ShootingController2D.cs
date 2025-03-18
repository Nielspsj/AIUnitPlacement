using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShootingController2D : MonoBehaviour
{
    //Our projectile prefab
    public GameObject projectilePref;
    //Speed of the projectile.
    private float fireForce = 5f;
    //If we want to add more muzzles with other angles.
    public Transform muzzle_1;  

    // Update is called once per frame
    void Update()
    {       
        //Left mouse button down. Runs only once per event.
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
   
    //Spawn the projectile prefab at the muzzle position and rotation.
    //Give it velocity in a up direction with speed.
    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePref, muzzle_1.position, muzzle_1.rotation) as GameObject;
        projectile.GetComponent<Rigidbody2D>().velocity = muzzle_1.up * fireForce;
    }
}
