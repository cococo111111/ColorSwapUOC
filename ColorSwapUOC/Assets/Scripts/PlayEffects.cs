using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffects : MonoBehaviour
{
    public AudioClip newGoalsSound;
    public AudioClip newColorSound1;
    public AudioClip newColorSound2;
    public AudioClip dragDropSound;
    public AudioClip dragDropGoalSound;

    public GameObject energyCell;

    public void NewGoalsSound()
    {
        if (GlobalInfo.soundPlay == true)
        {
            StartCoroutine(SoundEffects(newGoalsSound));
        }
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
