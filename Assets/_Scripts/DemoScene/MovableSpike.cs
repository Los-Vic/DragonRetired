using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovableSpike : MonoBehaviour {

	private MoveTween mt;
	private Vector3 o_pos;
	private BoxCollider2D boxColl;
	public bool triggered;

	void Awake()
	{
		mt = GetComponent<MoveTween> ();
		boxColl = GetComponent<BoxCollider2D> ();	

	}
	void Start()
	{
		
		o_pos = transform.position;
		triggered = false;
	}
	void FixedUpdate()
	{
		if(triggered)
			mt.isOn = true;

		Collider2D[] colls = Physics2D.OverlapBoxAll (boxColl.bounds.center, boxColl.bounds.extents * 2, 0);

		foreach (Collider2D coll in colls) {
			if (coll.tag == "Player")
				LevelManager.Instance.BackToLastCheckPoint ();
			if (coll.tag == "Rock" || coll.tag == "Wood")
				mt.isOn = false;
			}	
		
	}
	/*
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player")
			LevelManager.Instance.BackToLastCheckPoint ();

		if (coll.tag == "Rock")
			blockRock++;
		if (coll.tag == "Wood")
			blockWood++;
	}
		
	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.tag == "Rock")
			blockRock--;
		if (coll.tag == "Wood")
			blockWood--;
	}*/






	public void Reset()
	{
		triggered = false;
		transform.position = o_pos;
		mt.isOn = false;
	}
}
