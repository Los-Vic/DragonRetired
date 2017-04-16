using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//岩石类（地面）
public class Stone : AbstractGrid {

	public Sprite[] sprites; //0:normal 1:ice
	public PhysicsMaterial2D smooth;

	private SpriteRenderer sp;
	private BoxCollider2D coll;


	public bool startWithFreezed;


	void Awake()
	{
		sp = GetComponent<SpriteRenderer> ();
		coll = GetComponent<BoxCollider2D> ();
	}
	void Start()
	{
		woodFriendly = true;
		if (startWithFreezed)
			OnFreezed ();
	}

	/// <summary>
	/// 火焰魔法，解冻
	/// </summary>
	public  override void OnFired()
	{
		freezed = false;
		sp.sprite = sprites [0];
		coll.sharedMaterial = null;
		Debug.Log ("Stone is fired");
	}
	/// <summary>
	/// 冰冻魔法，冻结
	/// </summary>
	public  override void OnFreezed()
	{
		freezed = true;
		sp.sprite = sprites [1];
		coll.sharedMaterial = smooth;
		Debug.Log ("Stone is freezed");
	}
	/// <summary>
	/// 反重力无效
	/// </summary>
	public override  void OnAntiGravity()
	{
		Debug.Log ("Stone is antigravity");
	}
	public override void InteractWithPrince()
	{

	}

}
