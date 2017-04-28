using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class D_KillZone : MonoBehaviour {

	public bool water;
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player") {
			//LevelManager.Instance.BackToLastCheckPoint ();
			if(!water)
				StartCoroutine (LevelManager.Instance.PlayDie ());
			else
				StartCoroutine (LevelManager.Instance.PlayDrown ());
		}
		else if (coll.tag == "Rock")
			Destroy (coll.gameObject);
	}
		
}
