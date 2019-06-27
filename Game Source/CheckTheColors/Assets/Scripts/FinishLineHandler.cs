using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FinishLineHandler : MonoBehaviour
{

    public GameBehaviour gBeh;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (collision.gameObject.name == "manuk1(Clone)")
            {
                Debug.Log("Server Win");
                gBeh.endScene(1);
            }
            else if (collision.gameObject.name == "manuk2(Clone)")
            {
                Debug.Log("Client Win");
                gBeh.endScene(2);
            }
        }
        else
        {
            if (collision.gameObject.name == "manuk1(Clone)")
            {
                Debug.Log("Server Win");
                gBeh.endScene(2);
            }
            else if (collision.gameObject.name == "manuk2(Clone)")
            {
                Debug.Log("Client Win");
                gBeh.endScene(1);
            }
        }
    }

}
