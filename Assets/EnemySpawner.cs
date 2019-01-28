using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    public GameObject boxPrefab;
    public GameObject enemyPrefab;
    public int numberOfboxes;
    public int numberOfEnemies;
    public Collider[] colliders;
    float[] box_x = new float[] { 0f, 4.0f, 4.0f, -4.0f, -4.0f };
    float[] box_z = new float[] { 0f, 4.0f, -4.0f, -4.0f, 4.0f };

    //2.5f

    //public bool check_distance(float )

    public override void OnStartServer()
    {
        


        for(int i = 0; i< numberOfEnemies; i++)
        {
            var spawnPosition = new Vector3(
                Random.Range(-8f, 8f), 0, Random.Range(-8f, 8f));
            var spawnRotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(0, 180), 0.0f));
            var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            
            NetworkServer.Spawn(enemy);

        }
        for (int i = 0; i < numberOfboxes; i++)
        {
            var spawnPosition = new Vector3(
                box_x[i], -0.92f, box_z[i]);
            var spawnRotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(0, 180), 0.0f));
            var box = (GameObject)Instantiate(boxPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(box);

        }

        




    }
}
