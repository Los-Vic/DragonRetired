using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedal : AbstractGrid {


	#region Unity Events
	// Use this for initialization
	void Start () {
		Initialization ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	#endregion

	#region Methods
	public override void Initialization ()
	{
		state = State.Normal;
		ability = Ability.Flammable | Ability.Freezable;

	}
	public override bool OnFired ()
	{
		if (state == State.Freezing) {
			state = State.Normal;
			Debug.Log ("pedal is valid now");
			return true;
		}
		return false;
	}
	public override bool OnFreezed ()
	{
		if (state == State.Normal ) {
			state = State.Freezing;
			Debug.Log ("pedal is invalid now");
			return true;
		}
		return false;
		
	}
	public override bool OnAntiGravity ()
	{
		return false;
	}
	public override void InteractWithPrince ()
	{
	}

	#endregion
}
