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

    public GAui tres;
    public GAui dos;
    public GAui uno;
    public GAui start;

    public GameObject grid;
    public GameObject gridBackGround;
    public GameObject gridResult;
    public GAui level;
    public Text levelText;
    public GameObject energyCell;

    private void Awake()
    {
        Instance = this;
        GSui.Instance.m_AutoAnimation = false;
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
    public void StartGame()
    {
        grid.SetActive(true);
        gridBackGround.SetActive(true);
        gridResult.SetActive(true);
    }

    public void NewGoalsSound()
    {
        if (GlobalInfo.soundPlay == true)
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
       if (GlobalInfo.soundPlay == true)
       {
            StartCoroutine(SoundEffects(newColorSound1));            
       }   
    }

    public void NewColorSound2()
    {
        if (GlobalInfo.soundPlay == true)
        {
            StartCoroutine(SoundEffects(newColorSound2));            
        }
    }

    public void DragDropSound()
    {
        if (GlobalInfo.soundPlay == true)
        {
            StartCoroutine(SoundEffects(dragDropSound));            
        }
    }

    public void DragDropGoalSound()
    {
        if (GlobalInfo.soundPlay == true)
        {
            StartCoroutine(SoundEffects(dragDropGoalSound));
        }
    }

    IEnumerator SoundEffects(AudioClip clip)
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().PlayOneShot(clip,0.7f);
    }

}
