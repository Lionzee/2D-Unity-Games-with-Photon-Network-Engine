using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayService : MonoBehaviour
{

    public GameObject btnSignIn, btnShowAchievement;
    public Sprite yesLogin, noLogin;

    // Start is called before the first frame update
    void Start()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
    }

    public void onSignIn() {
        Social.localUser.Authenticate((bool success) =>
        {
            if (success == true)
            {
                btnSignIn.GetComponent<Button>().interactable = false;
                btnSignIn.GetComponentInChildren<Image>().sprite = yesLogin;
                btnShowAchievement.SetActive(true);
                unlockLoginAch();

            }
            else
            {
                btnSignIn.GetComponentInChildren<Image>().sprite = noLogin;
                btnShowAchievement.SetActive(false);   
            }
        });
    }


    public void showAchUI() {
        PlayGamesPlatform.Instance.ShowAchievementsUI();
    }

    public void unlockLoginAch() {
        PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_login, 100f, null);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
