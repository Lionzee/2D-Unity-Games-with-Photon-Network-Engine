using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour
{

    public Sprite[] trueSprites;
    public Sprite[] falseSprites;
    public Text yourTextIndicator;
    private int yourScore;
    public GameObject wrongSign;
    public GameObject winSign,loseSign;


    public Button[] buttons;
    public bool onWrong = false;


    // handle button click e ndek button manager


    private void Start()
    {



        yourScore = 0;
        yourTextIndicator.text = yourScore.ToString();

        randomizer();
    }

    private void Update()
    {
        yourTextIndicator.text = yourScore.ToString();


        if (yourScore >= 20) {
            // iki kondisi lek menang ubahen ae engko
            hideButton();
            winSign.SetActive(true);
        }
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



}
