using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class GameBehaviour : MonoBehaviour
{

    public Sprite[] trueSprites;
    public Sprite[] falseSprites;
    public Text yourTextIndicator;

    public GameObject[] spawnManuk;
    public GameObject[] manuk;

    private int yourScore;
    private int cDown= 5;
    private bool isStarting = false;

    public GameObject wrongSign;
    public GameObject winSign,loseSign,finishLine;

    public GameObject waitPanel;
    public Text txtInfo, txtCount;
    


    public Button[] buttons;
    public bool onWrong = false;


    // handle button click e ndek button manager


    private void Start()
    {


        hideButton();
        
        yourScore = 0;
        yourTextIndicator.text = yourScore.ToString();

       

       // randomizer();
    }

    private void Update()
    {
        yourTextIndicator.text = yourScore.ToString();


        //
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && isStarting == false) {
            StartCoroutine(gameCountdown());
            isStarting = true;
        }



        if (yourScore >= 20) {
            // iki kondisi lek menang ubahen ae engko
            hideButton();
            winSign.SetActive(true);
        }
    }

    private void gameStart() {
        // spawn
        waitPanel.SetActive(false);
        finishLine.SetActive(true);

        if (PhotonNetwork.IsMasterClient)
        {
            manuk[0] = PhotonNetwork.Instantiate(manuk[0].name, spawnManuk[0].transform.position, Quaternion.identity, 0);
        }
        else
        {
            manuk[1] = PhotonNetwork.Instantiate(manuk[1].name, spawnManuk[1].transform.position, Quaternion.identity, 0);
        }

        randomizer();
    }

    public void endScene(int _player) {

        if (_player == 1) {
            hideButton();
            winSign.SetActive(true);
        } else if (_player == 2) {
            hideButton();
            loseSign.SetActive(true);
        }
        finishLine.SetActive(false);
    }

    private void showButton() {
        for (int i = 0; i <=3; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
    }

    private void hideButton() {
        for (int i = 0; i <=3; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }

    private void randomizer() {

        // iki ngacak button e

        showButton();
        for (int i=0;i<=3;i++) {
            buttons[i].GetComponentInChildren<Image>().sprite = falseSprites[Random.Range(0, 19)];
            buttons[i].gameObject.tag = "Salah";
        }
        int correctAnswer = Random.Range(0, 3);
        buttons[correctAnswer].GetComponentInChildren<Image>().sprite = trueSprites[Random.Range(0, 9)];
        buttons[correctAnswer].gameObject.tag = "Benar";



    }

    public void onBenar() {
        // kondisi lek metek tombol e bener
        // manuk e mlaku no 

        if (PhotonNetwork.IsMasterClient)
        {
            manuk[0].transform.position += new Vector3(1,0,0);
        }
        else {
            manuk[1].transform.position += new Vector3(1,0,0);
        }

        yourScore += 1;

        randomizer(); 
    }


    public void onSalah() {

        // iki lek salah engko metu tombol silang e ndek coroutine e gawe punish
        // ben gak nyepam

        StartCoroutine(onFalseDelay());
    }

    IEnumerator onFalseDelay() {
        onWrong = true;
        Debug.Log("False Delay Executed !");
        hideButton();
        wrongSign.SetActive(true);
        yield return new WaitForSeconds(2f);
        wrongSign.SetActive(false);
        showButton();

        randomizer();

        onWrong = false;
    }

    IEnumerator gameCountdown() {
        txtInfo.text = "GAME WILL START IN ..";
        do
        {
            txtCount.text = cDown.ToString();
            yield return new WaitForSeconds(1f);
            cDown -= 1;
        } while (cDown > 0);
        gameStart();
    }



}
