using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//金属栅栏类
public class MetalFence : AbstractGrid {

	void Start()
	{
		destructable = true; 
	}

	/// <summary>
	/// 火焰魔法，解冻
	/// </summary>
	public  override void OnFired()
	{
		freezed = false;
		Debug.Log ("MetalFence is fired");
	}
	/// <summary>
	/// 冰冻魔法，冻结，可被王子击碎
	/// </summary>
	public  override void OnFreezed()
	{
		freezed = true;
		Debug.Log ("MetalFence is freezed");
	}
	/// <summary>
	/// 反重力无效
	/// </summary>
	public override  void OnAntiGravity()
	{
		Debug.Log ("MetalFence is antigravity");
	}
	public override void InteractWithPrince()
	{
	}
}
