using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] EnemyMovement enemyMovement;
    private int health = 10;
    private ScoreManager scoreManager;
    private Transform player;

    public GameObject projectilePref;
    private float fireForce = 10f;
    private float timeCounter;
    [SerializeField] private float fireRate = 2f;


    // Start is called before the first frame update
    void Start()
    {
        //Find player, then use distance to make behavior states.
        player = GameObject.FindGameObjectWithTag("Player").transform;

        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            scoreManager.EnemyKilled();
            Destroy(gameObject);
        }

        UpdateBehaviorStates();
    }

    private void UpdateBehaviorStates()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) < 2)
            {
                Debug.Log("within attack range");
                Attacking();
            }
            else if (Vector2.Distance(transform.position, player.position) >= 2)
            {
                Debug.Log("outside attack range");
                Patroling();
            }
        }
    }

    private void Patroling()
    {
        //Normal movement
        //How do you talk between the scripts? Or merge both scripts?
        enemyMovement.canMove = true;
    }
    private void Alert()
    {

    }
    private void Chase()
    {

    }
    private void Attacking()
    {
        //Stops moving
        //How do you talk between the scripts? Or merge both scripts?
        enemyMovement.canMove = false;

        //Shoots the player
        ShootingTimer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");

        if (collision.transform.tag == "PlayerProjectile")
        {
            health -= 5;
        }

    }

    //Spawn the projectile.
    //Find the direction to shoot towards.
    //Send the projectile in a direction with the speed from fireForce.
    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePref, transform.position, transform.rotation) as GameObject;
        Vector2 direction = player.position - transform.position;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * fireForce;
    }

    //Count upwards to a fireRate point.
    //Reset the counter and shoot.
    private void ShootingTimer ()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter > fireRate)
        {
            timeCounter = 0;
            Shoot();
        }
    }
}
