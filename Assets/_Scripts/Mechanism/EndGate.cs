using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.SceneManagement;

public class EndGate : MonoBehaviour {

	public UnityArmatureComponent uac;

	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player") {
		//	Debug.Log ("Startcorutine");
			StartCoroutine (Happy ());
		}
	}

	IEnumerator Happy()
	{

		uac.GetComponent<PrinceController> ().enabled = false;
		uac.GetComponent<PrinceAnimator> ().enabled = false;
		uac.animation.timeScale = 1f;
		uac.animation.GotoAndPlayByFrame ("happy", 0, 0);

		yield return new WaitForSeconds (3f);
		int id = SceneManager.GetActiveScene ().buildIndex+1;

		if (id == 3)
			LevelManager.Instance.ToScene (id);
	}
}
