using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{
    public const int maxHealth = 100;

    public bool destoryOnDeath;


    
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth;

    

    public Slider healthSlider;

    private NetworkStartPosition[] spawnPoints;

    private void Start()
    {
        if (isLocalPlayer)
        {
            spawnPoints = FindObjectsOfType<NetworkStartPosition>();
        }
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log(currentHealth+" : BEFORE");
        if(!isServer)
        {
            return;
        }

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            if (destoryOnDeath)
            {
                Destroy(gameObject);
            }
            else
            {
                currentHealth = maxHealth;

                RpcRespawn();
            }

        }
        

        Debug.Log(currentHealth + " : AFTER");


    }

    public void OnChangeHealth(int health)
    {
        Debug.Log("OnChangeHealth for "+ health);
        if (!isServer)
        { currentHealth = health; }
        healthSlider.value = currentHealth;
    }

    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            Vector3 spawnPoint = Vector3.zero;
            if(spawnPoints != null && spawnPoints.Length>0)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            }
            transform.position = spawnPoint;
        }

    }

    
    
}
