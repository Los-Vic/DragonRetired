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
		yield return new WaitForSeconds(0.25f);
		canvas.SetActive (true);
		LevelManager.Instance.ToScene (1);
	}
}
