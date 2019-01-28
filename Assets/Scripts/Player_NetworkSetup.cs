using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Player_NetworkSetup : NetworkBehaviour
{
    [SerializeField] Camera FPSCharacterCam;
    [SerializeField] AudioListener audioListener;

    public override void OnStartLocalPlayer()
    {
        
    }

}
