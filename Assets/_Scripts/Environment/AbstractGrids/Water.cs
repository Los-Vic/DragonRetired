﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//水类
public class Water : AbstractGrid {

	#region Variables

	private BoxCollider2D b_coll;

	public bool startWithFreezed;
	public GameObject iceCube;
	#endregion

	#region Unity Events
	void Awake()
	{
		b_coll = GetComponent<BoxCollider2D> ();
	}
	void Start()
	{
		Initialization ();
		if (startWithFreezed)
			OnFreezed ();
	}
	#endregion

	#region Methods
	/// <summary>
	/// Initialization this instance.
	/// </summary>
	public override void Initialization ()
	{
		state = State.Normal;
		ability = Ability.Flammable | Ability.Freezable;
	}
	/// <summary>
	/// 火焰魔法，解冻
	/// </summary>
	public  override bool OnFired()
	{
		if (state == State.Freezing) {
			state = State.Normal;
			iceCube.SetActive (false);
			b_coll.isTrigger = true;
			Debug.Log ("Water is fired");
			return true;
		}
		return false;
	}
	/// <summary>
	/// 冰冻魔法，冻结
	/// </summary>
	public  override bool OnFreezed()
	{
		if (state == State.Normal) {
			state = State.Freezing;
			iceCube.SetActive (true);
			b_coll.isTrigger = false;
			Debug.Log ("Water is freezed");
			return true;
		}
		return false;
	}
	/// <summary>
	/// 反重力无效
	/// </summary>
	public override  bool OnAntiGravity()
	{
		Debug.Log ("Water is antiG");
		return false;
	}
	public override void InteractWithPrince()
	{
	}
	#endregion

}
