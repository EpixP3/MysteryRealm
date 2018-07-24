using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour {

    public Image loadingOverlay;

	void Start () {
        loadingOverlay.gameObject.SetActive(true);
        StartCoroutine(CrossfadeLoading());
	}
	
	void Update () {
		
	}
    IEnumerator CrossfadeLoading()
    {
        yield return new WaitForSeconds(0.8f);
        loadingOverlay.CrossFadeAlpha(0f, 0.5f, true);
    }
}
