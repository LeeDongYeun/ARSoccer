using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BoxSpawner : NetworkBehaviour
{
    public GameObject boxPrefab;

    public int numberOfboxes;

    public override void OnStartServer()
    {
        for (int i = 0; i < numberOfboxes; i++)
        {
            var spawnPosition = new Vector3(
                Random.Range(-4f, 4f), -0.92f, Random.Range(-4f, 4f));
            var spawnRotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(0, 180), 0.0f));
            var box = (GameObject)Instantiate(boxPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(box);

        }




    }
}
