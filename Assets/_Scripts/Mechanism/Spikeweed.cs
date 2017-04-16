using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//地刺陷阱
public class Spikeweed : AbstractGrid {

	void Start()
	{
	}

	/// <summary>
	/// 火焰魔法，解冻
	/// </summary>
	public  override void OnFired()
	{
		freezed = false;
		Debug.Log ("Trap is fired");
	}
	/// <summary>
	/// 冰冻魔法，冻结,失效
	/// </summary>
	public  override void OnFreezed()
	{
		freezed = true;
		Debug.Log ("Trap is freezed");
	}
	/// <summary>
	/// 反重力无效
	/// </summary>
	public override  void OnAntiGravity()
	{
		Debug.Log ("Stone is antigravity");
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(!freezed && coll.tag =="Player")
			Debug.Log ("Kill creature");
	}
	public override void InteractWithPrince()
	{
	}
}
