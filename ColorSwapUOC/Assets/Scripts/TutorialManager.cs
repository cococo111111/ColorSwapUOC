using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour

{

    public GameObject[] tutorial;


    // Start is called before the first frame update
    void Start()
    {
        for (var i = 1; i < tutorial.Length; i++)
        {
            tutorial[i].SetActive(false);
        }
    }

    public void ButtonNext(int numberTutorial)
    {
        tutorial[numberTutorial].SetActive(false);
        tutorial[numberTutorial + 1].SetActive(true);
    }

    public void ButtonPlay()
    {
        PlayEffectsMenu.Instance.ExitTutorialPanel();
        GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_IM_ALREADY_PLAYING);
        PlayEffectsMenu.Instance.LoadBackPackForGamePanel();
    }

}
