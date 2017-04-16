using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//水类
public class Water : AbstractGrid {

	public Sprite[] sprites;//0: normal , 1:ice

	private SpriteRenderer sp;
	private BoxCollider2D b_coll;

	void Awake()
	{
		sp = GetComponent<SpriteRenderer> ();
		b_coll = GetComponent<BoxCollider2D> ();
	}
	void Start()
	{

	}


	/// <summary>
	/// 火焰魔法，解冻
	/// </summary>
	public  override void OnFired()
	{
		freezed = false;
		sp.sprite = sprites [0];
		b_coll.isTrigger = true;
		Debug.Log ("Water is fired");
	}
	/// <summary>
	/// 冰冻魔法，冻结
	/// </summary>
	public  override void OnFreezed()
	{
		freezed = true;
		sp.sprite = sprites [1];
		b_coll.isTrigger = false;
		Debug.Log ("Water is freezed");
	}
	/// <summary>
	/// 反重力无效
	/// </summary>
	public override  void OnAntiGravity()
	{
		Debug.Log ("Water is antiG");
	}
	public override void InteractWithPrince()
	{
	}

}
