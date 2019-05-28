using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GUIAnimator;


public class PlayEffectsMenu : MonoBehaviour
{

    public GAui buttonPlay;
    public GAui buttonSettings;
    public GAui buttonRanking;
    public GAui buttonShop;
    public GAui buttonCards;
    public GAui buttonSocial;
    public GAui buttonRate;
    public GAui panelSettings;
    public GAui panelShop;
    public GAui panelCombis;
    public GAui panelGame;


    private void Awake()
    {
        GSui.Instance.m_AutoAnimation = false;
        GSui.Instance.m_IdleTime = 0;
        panelSettings.gameObject.SetActive(false);
        panelCombis.gameObject.SetActive(false);
        panelShop.gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        GSui.Instance.PlayInAnims(buttonPlay.transform, true);
        GSui.Instance.PlayInAnims(buttonSettings.transform, true);
        GSui.Instance.PlayInAnims(buttonRanking.transform, true);
        GSui.Instance.PlayInAnims(buttonShop.transform, true);
        GSui.Instance.PlayInAnims(buttonCards.transform, true);
        GSui.Instance.PlayInAnims(buttonSocial.transform, true);
        GSui.Instance.PlayInAnims(buttonRate.transform, true);
    }

    public void LoadSettingsPanel()
    {
        panelSettings.gameObject.SetActive(true);
        GSui.Instance.PlayOutAnims(buttonPlay.transform, true);
        GSui.Instance.PlayOutAnims(buttonSettings.transform, true);
        GSui.Instance.PlayOutAnims(buttonRanking.transform, true);
        GSui.Instance.PlayOutAnims(buttonShop.transform, true);
        GSui.Instance.PlayOutAnims(buttonCards.transform, true);
        GSui.Instance.PlayOutAnims(buttonSocial.transform, true);
        GSui.Instance.PlayOutAnims(buttonRate.transform, true);
        GSui.Instance.PlayInAnims(panelSettings.transform, true);
    }

    public void ExitSettingsPanel()
    {
        GSui.Instance.PlayOutAnims(panelSettings.transform, true);
        GSui.Instance.PlayInAnims(buttonPlay.transform, true);
        GSui.Instance.PlayInAnims(buttonSettings.transform, true);
        GSui.Instance.PlayInAnims(buttonRanking.transform, true);
        GSui.Instance.PlayInAnims(buttonShop.transform, true);
        GSui.Instance.PlayInAnims(buttonCards.transform, true);
        GSui.Instance.PlayInAnims(buttonSocial.transform, true);
        GSui.Instance.PlayInAnims(buttonRate.transform, true);
    }

    public void LoadShopPanel()
    {
        panelShop.gameObject.SetActive(true);
        GSui.Instance.PlayOutAnims(buttonPlay.transform, true);
        GSui.Instance.PlayOutAnims(buttonSettings.transform, true);
        GSui.Instance.PlayOutAnims(buttonRanking.transform, true);
        GSui.Instance.PlayOutAnims(buttonShop.transform, true);
        GSui.Instance.PlayOutAnims(buttonCards.transform, true);
        GSui.Instance.PlayOutAnims(buttonSocial.transform, true);
        GSui.Instance.PlayOutAnims(buttonRate.transform, true);
        GSui.Instance.PlayInAnims(panelShop.transform, true);
    }

    public void ExitShopPanel()
    {
        GSui.Instance.PlayOutAnims(panelShop.transform, true);
        GSui.Instance.PlayInAnims(buttonPlay.transform, true);
        GSui.Instance.PlayInAnims(buttonSettings.transform, true);
        GSui.Instance.PlayInAnims(buttonRanking.transform, true);
        GSui.Instance.PlayInAnims(buttonShop.transform, true);
        GSui.Instance.PlayInAnims(buttonCards.transform, true);
        GSui.Instance.PlayInAnims(buttonSocial.transform, true);
        GSui.Instance.PlayInAnims(buttonRate.transform, true);
    }

    public void LoadCombisPanel()
    {
        panelCombis.gameObject.SetActive(true);
        GSui.Instance.PlayOutAnims(buttonPlay.transform, true);
        GSui.Instance.PlayOutAnims(buttonSettings.transform, true);
        GSui.Instance.PlayOutAnims(buttonRanking.transform, true);
        GSui.Instance.PlayOutAnims(buttonShop.transform, true);
        GSui.Instance.PlayOutAnims(buttonCards.transform, true);
        GSui.Instance.PlayOutAnims(buttonSocial.transform, true);
        GSui.Instance.PlayOutAnims(buttonRate.transform, true);
        GSui.Instance.PlayInAnims(panelCombis.transform, true);
    }

    public void ExitCombisPanel()
    {
        GSui.Instance.PlayOutAnims(panelCombis.transform, true);
        GSui.Instance.PlayInAnims(buttonPlay.transform, true);
        GSui.Instance.PlayInAnims(buttonSettings.transform, true);
        GSui.Instance.PlayInAnims(buttonRanking.transform, true);
        GSui.Instance.PlayInAnims(buttonShop.transform, true);
        GSui.Instance.PlayInAnims(buttonCards.transform, true);
        GSui.Instance.PlayInAnims(buttonSocial.transform, true);
        GSui.Instance.PlayInAnims(buttonRate.transform, true);
    }

    public void LoadGameScene()
    {
        GSui.Instance.PlayOutAnims(buttonPlay.transform, true);
        GSui.Instance.PlayOutAnims(buttonSettings.transform, true);
        GSui.Instance.PlayOutAnims(buttonRanking.transform, true);
        GSui.Instance.PlayOutAnims(buttonShop.transform, true);
        GSui.Instance.PlayOutAnims(buttonCards.transform, true);
        GSui.Instance.PlayOutAnims(buttonSocial.transform, true);
        GSui.Instance.PlayOutAnims(buttonRate.transform, true);
        GSui.Instance.PlayInAnims(panelGame.transform, true);
        //StartCoroutine(GoPlayScene());
    }
    public void ExitGameScene()
    {
        GSui.Instance.PlayOutAnims(panelGame.transform, true);
        GSui.Instance.PlayInAnims(buttonPlay.transform, true);
        GSui.Instance.PlayInAnims(buttonSettings.transform, true);
        GSui.Instance.PlayInAnims(buttonRanking.transform, true);
        GSui.Instance.PlayInAnims(buttonShop.transform, true);
        GSui.Instance.PlayInAnims(buttonCards.transform, true);
        GSui.Instance.PlayInAnims(buttonSocial.transform, true);
        GSui.Instance.PlayInAnims(buttonRate.transform, true);
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
