using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShootingController2D : MonoBehaviour
{
    public GameObject projectilePref;
    public float fireForce = 10f;
    private Vector3 mousePosition;
    private Vector3 mouseDirection;
    public Transform muzzle_1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
   

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePref, muzzle_1.position, muzzle_1.rotation) as GameObject;
        //projectile.GetComponent<Rigidbody2D>().AddForce(muzzle_1.up * fireForce, ForceMode2D.Impulse);
        projectile.GetComponent<Rigidbody2D>().velocity = muzzle_1.up * fireForce;

    }
}
