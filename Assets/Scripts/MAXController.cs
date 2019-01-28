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
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            GetComponent<Animator>().SetBool("Jumpchk", true);
            //transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.Space) == true)
        {
            GetComponent<Animator>().SetBool("Jumpchk", false);
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

    }
}
