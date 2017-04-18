using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalAndStone : MonoBehaviour {


	public MoveTween mt;
	private Pedal pedal;

	void Awake()
	{
		pedal = GetComponent<Pedal> ();
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player") {

			if (mt.GetComponent<SnapToGrid> () != null)
				mt.GetComponent<SnapToGrid> ().isSnapOn = false;

			if(pedal.state == State.Normal)
				mt.isOn = true;
		}
	}
}
