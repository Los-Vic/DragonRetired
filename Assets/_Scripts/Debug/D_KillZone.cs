using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class D_KillZone : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player")
			StartCoroutine (DelayLoadScene ());
		else if (coll.GetComponent<Rock> () != null)
			Destroy (coll.gameObject);
	}

	IEnumerator DelayLoadScene()
	{
		yield return new WaitForSeconds (1.5f);
		LevelManager.Instance.ReloadScene ();
	}
}
