using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2D : MonoBehaviour
{
    public List<GameObject> enemiesList = new List<GameObject>();
    public List<GameObject> spawnLocationsList = new List<GameObject>();
    public GameObject enemyGO;
    private int index = 0;
    public Vector3 spawnPosition;
    private GameObject spawnLocation;

   

    // Start is called before the first frame update
    void Start()
    {
        SpawnForLoop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            //SpawnEnemies();
            SpawnForLoop();
        }
        //SpawnAtLocations();
    }

    //Pick an enemy at random.
    //That enemy will spawn at spawnPosition.
    private void SpawnEnemies()
    {
        index = Random.Range(0, enemiesList.Count);
        GameObject enemy = Instantiate(enemiesList[index], spawnPosition, enemiesList[index].transform.rotation);
    }

    //Pick a location at random.
    //The enemyGO prefab will spawn at that random location.
    private void SpawnAtLocations()
    {
        index = Random.Range(0, spawnLocationsList.Count);
        spawnLocation = spawnLocationsList[index];
        GameObject enemy  = Instantiate(enemyGO, spawnLocationsList[index].transform.position, enemiesList[index].transform.rotation);
    }

    //Go through the spawn locations list one location at a time.
    //Check if the location has the ToughSpawn tag. Spawn a tough enemy if so.
    //else spawn a normal enemy.
    private void SpawnForLoop()
    {
        for(int i = 0; i < spawnLocationsList.Count; i++)
        {
            //spawnLocationsList[i].SetActive(true);
            if(spawnLocationsList[i].transform.tag == "ToughSpawn")
            {
                //Spawn the tough enemy!
                
            }
            else
            {
                //Only weak enemies spawn here...
                Instantiate(enemyGO, spawnLocationsList[i].transform.position, spawnLocationsList[i].transform.rotation);
            }
            //spawnLocationsList[i].SetActive(false);
        }
    }

    //Delay by a set time. These are called Coroutines.
    private IEnumerator SpawnDelayer()
    {
        yield return new WaitForSeconds(1);
        //Do something after the delay.
    }

}
