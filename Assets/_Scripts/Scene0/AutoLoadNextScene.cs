using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoadNextScene : MonoBehaviour {

	public GameObject canvas;

	void Start()
	{
		StartCoroutine (LoadNextScene());
	}


	IEnumerator LoadNextScene()
	{
		yield return new WaitForSeconds(1);
		canvas.SetActive (true);
		SceneManager.LoadScene (1);
	}
}
