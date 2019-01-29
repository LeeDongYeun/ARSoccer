using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class MAXController : NetworkBehaviour
{
    public float moveSpeed = 2f;

    public GameObject bulletPrefab;

    public Transform bulletSpawn;
    public Transform bulletSpawn2;
    public Transform bulletSpawn3;
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            GetComponent<Animator>().SetBool("Jumpchk", true);
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }*/
        if (Input.GetKeyUp(KeyCode.Space) == true)
        {
            GetComponent<Animator>().SetBool("Punchchk", false);
            CmdFire();
            //GetComponent<Animator>().SetBool("Jumpchk", false);
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetBool("Punchchk", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetBool("Punchchk", false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<Animator>().SetBool("Kickchk", true);
            Invoke("CmdFires", 1.5f);
            
            //CmdFires();
        }
        if (Input.GetMouseButtonUp(1))
        {
            GetComponent<Animator>().SetBool("Kickchk", false);
            
        }
        if (Input.GetMouseButtonDown(2))
        {
            GetComponent<Animator>().SetBool("Eggchk", true);
        }
        if (Input.GetMouseButtonUp(2))
        {
            GetComponent<Animator>().SetBool("Eggchk", false);
        }
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        Debug.Log(x + " and " + z);

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        //Added for UNET Tutorials
        float animSpeed = Mathf.Abs(vertical);
        GetComponent<Animator>().SetFloat("Speed", animSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetBool("Punchchk", true);
            
            
        }

    }

    [Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        NetworkServer.Spawn(bullet);
        Destroy(bullet, 4.0f);

        //var bullet2 = (GameObject)Instantiate(bulletPrefab, bulletSpawn2.position, bulletSpawn2.rotation);
        //bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * 6;

        //NetworkServer.Spawn(bullet2);
        //Destroy(bullet2, 4.0f);
    }

    [Command]
    void CmdFires()
    {
        

        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        NetworkServer.Spawn(bullet);
        Destroy(bullet, 4.0f);

        var bullet2 = (GameObject)Instantiate(bulletPrefab, bulletSpawn2.position, bulletSpawn2.rotation);
        bullet2.GetComponent<Rigidbody>().velocity = bullet2.transform.forward * 6;

        NetworkServer.Spawn(bullet2);
        Destroy(bullet2, 4.0f);
        var bullet3 = (GameObject)Instantiate(bulletPrefab, bulletSpawn3.position, bulletSpawn3.rotation);
        bullet3.GetComponent<Rigidbody>().velocity = bullet3.transform.forward * 6;

        NetworkServer.Spawn(bullet3);
        Destroy(bullet3, 4.0f);
    }

}
