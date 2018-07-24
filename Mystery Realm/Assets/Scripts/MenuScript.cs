using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject menuMenu, playMenu, optionsMenu, tutorial;
    public Image blackBackgorund, loadingOverlay;
    
	void Start () {
        tutorial.SetActive(false);
        blackBackgorund.CrossFadeAlpha(0f, 0f, true);
        loadingOverlay.CrossFadeAlpha(0f, 0f, true);
        loadingOverlay.gameObject.SetActive(false);
    }
	
	void Update () {
		
	}

    public void GoToPlayMenu()
    {
        if (PlayerPrefs.GetInt("FirstPlay") == 0)
        {
            //First play --> Tutorial
            tutorial.SetActive(true);
            blackBackgorund.CrossFadeAlpha(1f, 1f, true);
        }
        else
        {
            menuMenu.SetActive(false);
            playMenu.SetActive(true);
        }
    }
    public void GoToOptionsMenu()
    {
        menuMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void GoToMenuMenu()
    {
        menuMenu.SetActive(true);
        optionsMenu.SetActive(false);
        playMenu.SetActive(false);
    }
    public void TutorialOkBtn()
    {
        loadingOverlay.gameObject.SetActive(true);
        loadingOverlay.CrossFadeAlpha(0f, 0f, true);
        loadingOverlay.CrossFadeAlpha(1f, 0.5f, true);
        StartCoroutine(LoadNewLevel());
    }
    IEnumerator LoadNewLevel()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }
}
