using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovableSpike : MonoBehaviour {

	private MoveTween mt;
	private bool block;

	void Start()
	{
		mt = GetComponent<MoveTween> ();
	}
	void FixedUpdate()
	{

		if (block)
			mt.isOn = false;
		block = false;//交由OnTriggerXX函数确定
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player")
			LevelManager.Instance.ReloadScene ();
	}


	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.tag == "Rock")
			block = true;
	}
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.tag == "Rock" && block == false)
			mt.isOn = true;
	}

}
