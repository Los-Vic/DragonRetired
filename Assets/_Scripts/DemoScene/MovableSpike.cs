using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovableSpike : MonoBehaviour {

	private MoveTween mt;

	void Start()
	{
		mt = GetComponent<MoveTween> ();
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player")
			LevelManager.Instance.ReloadScene ();
		
	   if (coll.GetComponent<Rock> () != null)
			mt.isOn = false;
	}


	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.GetComponent<Rock> () != null)
			mt.isOn = true;
	}

}
