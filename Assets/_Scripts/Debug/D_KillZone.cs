using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class D_KillZone : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player") {
			FindObjectOfType<HpManager> ().Hp = 3;
			LevelManager.Instance.BackToLastCheckPoint ();
		}
		else if (coll.tag == "Rock")
			Destroy (coll.gameObject);
	}
		
}
