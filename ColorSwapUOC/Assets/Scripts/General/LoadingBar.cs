using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour {

    private bool loadScene = false;
    public string loadingSceneName;
    public float waitSecondsPrev;
    public float waitSecondsPost;
    public Slider sliderBar;
    public GameObject panelPrivacy;
    
    // Use this for initialization
	void Start ()
    {
        sliderBar.gameObject.SetActive(false);
        panelPrivacy.gameObject.SetActive(false);
        Invoke("LoadPrivacy", 0.5f);
    }

    void LoadPrivacy()
    {
        Debug.Log(GlobalInfo.gameFirstTime);
        if (GlobalInfo.gameFirstTime == "true")
        {
            panelPrivacy.gameObject.SetActive(true);
        }
        else
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        Invoke("Loading", waitSecondsPrev);
    }

    void Loading()
    {
	    if(loadScene == false)
        {
            loadScene = true;
            sliderBar.gameObject.SetActive(true);
            StartCoroutine("LoadNewScene");
        }
	}

    IEnumerator LoadNewScene()
    {
        yield return new WaitForSeconds(waitSecondsPost);
        AsyncOperation async = SceneManager.LoadSceneAsync(loadingSceneName);

        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            sliderBar.value = progress;
            yield return null;
        }
    }
}
