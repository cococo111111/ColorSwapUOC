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
    public GAui panelSettings;


    private void Awake()
    {
        GSui.Instance.m_AutoAnimation = false;
        GSui.Instance.m_IdleTime = 0;
        panelSettings.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        GSui.Instance.PlayInAnims(buttonPlay.transform, true);
        GSui.Instance.PlayInAnims(buttonSettings.transform, true);
        GSui.Instance.PlayInAnims(buttonHowToPlay.transform, true);
    }

    public void LoadSettingsPanel()
    {
        panelSettings.gameObject.SetActive(true);
        GSui.Instance.PlayOutAnims(buttonPlay.transform, true);
        GSui.Instance.PlayOutAnims(buttonSettings.transform, true);
        GSui.Instance.PlayOutAnims(buttonHowToPlay.transform, true);
        GSui.Instance.PlayInAnims(panelSettings.transform, true);
    }

    public void ExitSettingsPanel()
    {
        GSui.Instance.PlayOutAnims(panelSettings.transform, true);
        GSui.Instance.PlayInAnims(buttonPlay.transform, true);
        GSui.Instance.PlayInAnims(buttonSettings.transform, true);
        GSui.Instance.PlayInAnims(buttonHowToPlay.transform, true);
    }

    public void LoadGameScene()
    {
        GSui.Instance.PlayOutAnims(buttonPlay.transform, true);
        GSui.Instance.PlayOutAnims(buttonSettings.transform, true);
        GSui.Instance.PlayOutAnims(buttonHowToPlay.transform, true);
        StartCoroutine(GoPlayScene());
    }

    IEnumerator GoStartScene()
    {
        yield return new WaitForSeconds(2f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }

    IEnumerator GoPlayScene()
    {
        yield return new WaitForSeconds(1.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

}
