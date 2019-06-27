using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class MainMenu : MonoBehaviourPunCallbacks
{

    public Text PUNStatus;
    public GameObject quickPlayBtn;
    private bool connectionStatus = false;
    private bool anotherPlayerConnected = false;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
         
        
    }


    public void onFindRoomClicked() {
        if (!connectionStatus)
        {
            // error handling
        }
        else {
            quickPlayBtn.SetActive(false);
            PhotonNetwork.JoinRandomRoom();

            StartCoroutine(WaitJoinRoom());
        }
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PUNStatus.text = "PUN Status : Successfully Connected";
        connectionStatus = true;
    }

    public override void OnJoinedRoom()
    {
        StopAllCoroutines();
        PhotonNetwork.LoadLevel("Match");
    }

    IEnumerator WaitJoinRoom()
    {
        yield return new WaitForSeconds(2f);
        RoomOptions roomOpt = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        int roomNumber = Random.Range(0, 1000);
        PhotonNetwork.CreateRoom("Room " + roomNumber.ToString(), roomOpt, null, null);

     
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }
}
