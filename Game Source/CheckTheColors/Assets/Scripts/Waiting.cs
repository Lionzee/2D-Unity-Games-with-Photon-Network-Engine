using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Waiting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
        Debug.Log("Kentod");

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.LoadLevel("Match");
        }
    }
}
