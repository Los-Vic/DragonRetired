using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager> {


	public GameObject sceneMenu;

	private SkillCounter sc;

	protected LevelManager(){
	}

	void Start()
	{
		sc = FindObjectOfType<SkillManager> ().skillCounter;
		if (sc == null)
			Debug.Log ("cann't find skillCounter");
	}

	// Update is called once per frame
	void Update () {
		
	}


	//进入上一个场景
	public void PreviousScene()
	{
		int id = SceneManager.GetActiveScene ().buildIndex;
		id = id - 1;

		if (id > 0)
			SceneManager.LoadScene (id);
		else
			Debug.Log ("can't return to Scene 0!");
	}
	//进入下一个场景
	public void NextScene()
	{
		int id = SceneManager.GetActiveScene ().buildIndex;
		id = id + 1;

		if (id < SceneManager.sceneCountInBuildSettings)
			SceneManager.LoadScene (id);
		else
			Debug .Log("This is the last scene!");
	}

	//调到指定id的场景
	public void ToScene(int id)
	{
		if (id < SceneManager.sceneCountInBuildSettings) {
			sc.Reset ();
			SceneManager.LoadScene (id);
			sceneMenu.SetActive (false);

		}
	}
	public void ReloadScene()
	{
		sc.Reset ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

	}
}
