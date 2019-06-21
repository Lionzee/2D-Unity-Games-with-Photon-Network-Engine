using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public GameBehaviour gBehaviour;

    public void onButtonClicked() {
        if (gBehaviour.onWrong == false) {
            Debug.Log(gameObject.tag.ToString());
            if (gameObject.tag == "Benar") {
                gBehaviour.onBenar();
            } else if (gameObject.tag == "Salah") {
                gBehaviour.onSalah();
            }
        }
    }

    
}
