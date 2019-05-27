using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GUIAnimator;

public class PlayEffects : MonoBehaviour
{
    public static PlayEffects Instance;
    public AudioClip newGoalsSound;
    public AudioClip newColorSound1;
    public AudioClip newColorSound2;
    public AudioClip dragDropSound;
    public AudioClip dragDropGoalSound;
    public AudioClip timeEndSound;
    AudioSource timeEnding;

    public GAui tres;
    public GAui dos;
    public GAui uno;
    public GAui start;
    public GAui gameOver;

    public GameObject grid;
    public GameObject gridBackGround;
    public GameObject gridResult;
    public GAui level;
    public GAui time;
    public Text levelText;
    public GameObject energyCell;

    private void Awake()
    {
        gameOver.gameObject.SetActive(false);
        Instance = this;
        GSui.Instance.m_AutoAnimation = false;
        timeEnding = GameObject.Find("TimeText").GetComponent<AudioSource>();
        
    }
    void Start()
    {
        GSui.Instance.PlayInAnims(tres.transform, true);
    }

    public void ThreeOut()
    {
        GSui.Instance.PlayOutAnims(tres.transform, true);
        GSui.Instance.PlayInAnims(dos.transform, true);
    }

    public void TwoOut()
    {
        GSui.Instance.PlayOutAnims(dos.transform, true);
        GSui.Instance.PlayInAnims(uno.transform, true);
    }
    public void OneOut()
    {
        GSui.Instance.PlayOutAnims(uno.transform, true);
        GSui.Instance.PlayInAnims(start.transform, true);
    }
    public void StartOut()
    {
        GSui.Instance.PlayOutAnims(start.transform, true);
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        GSui.Instance.PlayInAnims(gameOver.transform, true);
        StartCoroutine(GoToMainMenu());
    }

    public void NewGoalsSound()
    {
        if (GlobalInfo.soundPlay == "true")
        {
            StartCoroutine(SoundEffects(newGoalsSound));
        }
    }

    public void ShowLevel(string numLevel)
    {
        GSui.Instance.PlayInAnims(level.transform, true);
        levelText.text = "LEVEL " + numLevel;
    }


    public void LevelOut()
    {
        GSui.Instance.PlayOutAnims(level.transform, true);
    }

    public void HideLevel()
    {

    }

    public void NewColorSound1()
    {
       if (GlobalInfo.soundPlay == "true")
       {
            StartCoroutine(SoundEffects(newColorSound1));            
       }   
    }

    public void NewColorSound2()
    {
        if (GlobalInfo.soundPlay == "true")
        {
            StartCoroutine(SoundEffects(newColorSound2));            
        }
    }

    public void DragDropSound()
    {
        if (GlobalInfo.soundPlay == "true")
        {
            StartCoroutine(SoundEffects(dragDropSound));            
        }
    }

    public void DragDropGoalSound()
    {
        if (GlobalInfo.soundPlay == "true")
        {
            StartCoroutine(SoundEffects(dragDropGoalSound));
        }
    }

    public void TimeEnding()
    {
        GSui.Instance.PlayInAnims(time.transform, true);
        timeEnding.clip = timeEndSound;
        timeEnding.Play();
        timeEnding.loop = true;
    }

    public void TimeEndingStop()
    {
        //Parar el sonido del reloj
        timeEnding.Stop();
        timeEnding.loop = false;
        GSui.Instance.PlayOutAnims(time.transform, true);

    }

    IEnumerator SoundEffects(AudioClip clip)
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().PlayOneShot(clip,0.7f);
    }

    IEnumerator GoToMainMenu()
    {
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }

}
