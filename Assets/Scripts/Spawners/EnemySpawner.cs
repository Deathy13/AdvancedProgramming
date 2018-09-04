using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemy;
    public Transform spawnPoint;
    public Transform waypointParent;


    public override void OnStartServer()
    {
        for (int i = 0; i < numberOfEnemy; i++)
        {
            //spawnPoint.rotation = Quaternion.Euler(
            //     0.0f,
            //     Random.Range(0, 180),
            //     0.0f);

            GameObject enemyClone = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Get Enemy component from 'enemyPrefab'
        // |Declaration|<-----------Definition------------>|
            Enemy enemy = enemyClone.GetComponent<Enemy>();

            // Assign (=) the waypointParent to enemy.waypointParent;
            enemy.waypointParent = waypointParent;
            NetworkServer.Spawn(enemyClone);
        }
    }
    // Use this for initialization
    
}
