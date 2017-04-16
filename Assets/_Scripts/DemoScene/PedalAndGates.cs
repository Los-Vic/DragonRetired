using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalAndGates : MonoBehaviour {

	public MoveTween mt1; // end to start
	public MoveTween mt2; // start to end



	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player"  || coll.GetComponent<Rock>()!=null) {
			mt1.isOn = true;
			mt1.back = true;

			mt2.isOn = true;
			mt2.back = false;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.tag == "Player"  || coll.GetComponent<Rock>()!=null) {
			mt1.isOn = true;
			mt1.back = false;

			mt2.isOn = true;
			mt2.back = true;
		}
	}
}
