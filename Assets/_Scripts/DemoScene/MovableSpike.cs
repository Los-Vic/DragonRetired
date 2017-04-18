using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovableSpike : MonoBehaviour {

	private MoveTween mt;
	private int blockRock;
	public bool triggered;

	void Start()
	{
		mt = GetComponent<MoveTween> ();
		blockRock = 0;
		triggered = false;
	}
	void FixedUpdate()
	{
		if (triggered) {
			if (blockRock > 0)
				mt.isOn = false;
			else
				mt.isOn = true;
		}
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player")
			LevelManager.Instance.ReloadScene ();

		if (coll.tag == "Rock")
			blockRock++;
	}
		
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.tag == "Rock")
			blockRock--;
	}

}
