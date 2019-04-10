using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GUIAnimator;


public class PlayEffectsMenu : MonoBehaviour
{

    public GAui buttonPlay;
    public GAui buttonSettings;
    public GAui buttonHowToPlay;
    public GAui buttonCircular;


    private void Awake()
    {
        GSui.Instance.m_AutoAnimation = false;
        GSui.Instance.m_IdleTime = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        GSui.Instance.PlayInAnims(buttonPlay.transform, true);
        GSui.Instance.PlayInAnims(buttonSettings.transform, true);
        GSui.Instance.PlayInAnims(buttonHowToPlay.transform, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
