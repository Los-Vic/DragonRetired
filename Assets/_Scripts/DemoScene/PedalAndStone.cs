using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalAndStone : MonoBehaviour {


	public MoveTween mt;

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player") {

			if(mt.GetComponent<SnapToGrid>()!=null)
				mt.GetComponent<SnapToGrid> ().isSnapOn = false;
			
			mt.isOn = true;
		}
	}
}
