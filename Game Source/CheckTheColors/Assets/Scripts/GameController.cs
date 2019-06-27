using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviour
{
    public GameObject[] spawnManuk;
    public GameObject[] manuk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (PhotonNetwork.IsMasterClient)
        //{
        //    manuk[0].GetComponent<Transform>().Translate(new Vector3(Time.deltaTime, 0, 0));
        //} else
        //{
        //    manuk[1].GetComponent<Transform>().Translate(new Vector3(2 * Time.deltaTime, 0, 0));
        //}
    }
}
