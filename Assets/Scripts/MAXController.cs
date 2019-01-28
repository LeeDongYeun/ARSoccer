using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class MAXController : NetworkBehaviour
{
    public float moveSpeed = 2f;
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        //if(Input.GetKey(KeyCode.S)==true)
        //{
        //    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        //}

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

    }
}
