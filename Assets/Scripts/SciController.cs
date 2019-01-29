using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;
public class SciController : NetworkBehaviour
{


    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        //Added for UNET Tutorials
        float animSpeed = Mathf.Abs(vertical);
        GetComponent<Animator>().SetFloat("Speed", animSpeed);

        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            GetComponent<Animator>().SetBool("Rifle", true);
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.Space) == true)
        {
            GetComponent<Animator>().SetBool("Rifle", false);
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

    }
}
