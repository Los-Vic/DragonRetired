using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//宝箱类
public class Treasure : AbstractGrid {

	void Start()
	{
		destructable = true; 
		flammable = true;
	}

	/// <summary>
	/// 火焰魔法，燃烧，半秒后点燃周围物体，1s后宝箱自毁（里面的道具也消失）
	/// </summary>
	public  override void OnFired()
	{
		freezed = false;
		StartCoroutine (FireEvent());
		onFireNow = true;
		Debug.Log ("Treasure is fired");
	}
	/// <summary>
	/// 冰冻魔法，熄灭
	/// </summary>
	public  override void OnFreezed()
	{
		freezed = true;
		Debug.Log ("Treasure is freezed");
	}
	/// <summary>
	/// 反重力无效
	/// </summary>
	public override  void OnAntiGravity()
	{
		Debug.Log ("Treasure is antigravity");
	}
	/// <summary>
	/// 王子打开后会怎样
	/// </summary>
	public override void InteractWithPrince()
	{

		DestroySelf ();
	}

	/// <summary>
	/// 搜索周围一格内的物体,并使之燃烧
	/// </summary>
	private void FireNearBy()
	{
		Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position+new Vector3(0.5f,0.5f,0f),1);

		foreach (Collider2D coll in colls) 
		{
			if (coll.gameObject != gameObject) 
			{
				AbstractGrid ag = coll.GetComponent<AbstractGrid> ();
				if (ag != null && ag.flammable &&!ag.onFireNow)
					ag.OnFired ();
			}
		}
	}
	/// <summary>
	/// 处理燃烧事件
	/// </summary>
	/// <returns>The event.</returns>

	private IEnumerator FireEvent()
	{
		yield return new WaitForSeconds (0.5f);
		FireNearBy ();
		yield return new WaitForSeconds (0.5f);
		DestroySelf ();
	}
	private void DestroySelf()
	{
		Destroy (gameObject);
	}
		

}
