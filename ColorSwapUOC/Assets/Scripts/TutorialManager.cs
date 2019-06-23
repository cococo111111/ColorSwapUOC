using EasyMobile;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour

{
    public static TutorialManager Instance;
    public GameObject[] tutorial;
    public Button ButPlay;
    public Button next1;
    public Button next2;
    public Button next3;
    public Button next4;
    public Button next5;
    public Button next6;
    public Button next7;
    public Button next8;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ResetPanels();
    }

    public void ResetPanels()
    {
        for (var i = 0; i < tutorial.Length; i++)
        {
            tutorial[i].SetActive(false);
        }
        tutorial[0].SetActive(true);
        ButPlay.interactable = true;
        next1.interactable = true;
        next2.interactable = true;
        next3.interactable = true;
        next4.interactable = true;
        next5.interactable = true;
        next6.interactable = true;
        next7.interactable = true;
        next8.interactable = true;
    }

    public void ButtonNext(int numberTutorial)
    {
        tutorial[numberTutorial].SetActive(false);
        tutorial[numberTutorial + 1].SetActive(true);
    }

    public void ButtonPlay()
    {
        PlayEffectsMenu.Instance.ExitTutorialPanel();
        ButPlay.interactable = true;
        next1.interactable = true;
        next2.interactable = true;
        next3.interactable = true;
        next4.interactable = true;
        next5.interactable = true;
        next6.interactable = true;
        next7.interactable = true;
        next8.interactable = true;
        GameServices.UnlockAchievement(EM_GameServicesConstants.Achievement_IM_ALREADY_PLAYING);
        PlayEffectsMenu.Instance.LoadBackPackForGamePanel();
    }

}
