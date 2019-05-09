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

    public Button[] buttons;
    public bool onWrong = false;


    void Start()
    {



        //starting Button
        randomizer();
    }

    public void onTrue() {
        yourScore += 1;
        randomizer();
    }

    public void onFalse()
    {
        StartCoroutine(onFalseDelay());
    }


    private void randomizer() {
        for (int i = 0; i <= 3; i++)
        {
            buttons[i].GetComponentInChildren<Image>().sprite = falseSprites[Random.Range(0, 19)];
            buttons[i].gameObject.tag = "Salah";

        }
        int corAns = Random.Range(0, 3);
        buttons[corAns].GetComponentInChildren<Image>().sprite = trueSprites[Random.Range(0, 9)];
        buttons[corAns].gameObject.tag = "Benar";
    }
    
    IEnumerator onFalseDelay()
    {
        onWrong = true;
        Debug.Log("Delay Salah 1 Detik ...");
        yield return new WaitForSeconds(1);
        onWrong = false;
        
    }

    
    



}
