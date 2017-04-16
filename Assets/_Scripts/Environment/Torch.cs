using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//火炬（路灯）类
public class Torch : AbstractGrid {


	void Start()
	{
		flammable = true;
	}


	/// <summary>
	/// 火焰魔法，点燃，灯亮
	/// </summary>
	public  override void OnFired()
	{
		onFireNow = true;
		Debug.Log ("Torch is fired");
	}
	/// <summary>
	/// 冰冻魔法，熄灭,灯灭
	/// </summary>
	public  override void OnFreezed()
	{
		onFireNow = false;
		Debug.Log ("Torch is freezed");
	}
	/// <summary>
	/// 反重力无效
	/// </summary>
	public override  void OnAntiGravity()
	{
		Debug.Log ("Torch is antiG");
	}
	public override void InteractWithPrince()
	{
	}

	/// <summary>
	/// 计算屏幕坐标，供shader用
	/// </summary>
	/// <returns>The position on screen.</returns>
	public Vector3 ComputePosOnScreen()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position + new Vector3(0.5f,0.5f,0));
		pos.x /= Screen.width;
		pos.y /= Screen.height;
		pos.x *= (float)Screen.width / Screen.height;

		return pos;
	}
}
