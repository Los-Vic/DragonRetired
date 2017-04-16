using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WoodSkill : MonoBehaviour,ISkill{

	private bool isNull;//是否为空技能
	private static string skillName = "Wood";
	private bool isReady; //此处是否可以放置

	public GameObject woodPrefab;
	public GameObject woodIndicator;

	public static string GetName()
	{
		return skillName;
	}

	#region 实现接口
	/// <summary>
	/// 继承至ISkill
	/// </summary>
	public bool IsNull{
		get
		{
			return isNull;
		}
	}
	public string Name{
		get
		{
			return skillName;
		}
	}

	/// <summary>
	/// 初始化函数
	/// </summary>
	public void Initialization()
	{
		isNull = false;
		isReady = false;

	}


	// Use this for initialization
	void Start () {
		Initialization ();
	}

	/// <summary>
	/// 点击技能按钮后，显示指示器
	/// </summary>
	public void ShowIndicator()
	{
		isReady = false;
		if (Utility.WithinLightRange ()) {
			Vector3 pos = Utility.SnappingGrid (Input.mousePosition);

			woodIndicator.transform.position = pos+new Vector3(0,0,-1);
			woodIndicator.GetComponent<SpriteRenderer> ().enabled = true;

			Collider2D coll = Utility.GetMouseTargetAbstractGrid (pos);
			if (coll == null) {
				if (FindNearByWoodFriend (pos)) {
					woodIndicator.GetComponent<SpriteRenderer> ().color = Color.blue;
					isReady = true;
				} else
					woodIndicator.GetComponent<SpriteRenderer> ().color = Color.red;
			} else
				woodIndicator.GetComponent<SpriteRenderer> ().color = Color.red;
		} else
			HideIndicator ();

	}
	/// <summary>
	/// 执行技能
	/// </summary>
	public bool Execute()
	{
		if (isReady) {
			Vector3 pos = Utility.SnappingGrid (Input.mousePosition);
			GameObject newWood = Instantiate (woodPrefab, pos, Quaternion.identity);
			isReady = false;
			return true;
		} else
			return false;
	}
	/// <summary>
	/// 关闭指示器
	/// </summary>
	public void HideIndicator()
	{
		isReady = false;
		woodIndicator.GetComponent<SpriteRenderer> ().enabled = false;
	}

	#endregion


	/// <summary>
	/// 找四个方向上距离一格内是否可以生长木块
	/// </summary>


	private bool FindNearByWoodFriend(Vector3 pos)
	{
		Vector3 tmp = pos;
		AbstractGrid ag;
		Collider2D coll;

		coll = Physics2D.OverlapPoint (new Vector2 (tmp.x + 1, tmp.y),Utility.lmForSkill);
		if (coll != null) {
			ag = coll.GetComponent<AbstractGrid> ();
			if (ag != null && ag.woodFriendly)
				return true;
		}

		coll = Physics2D.OverlapPoint (new Vector2 (tmp.x - 1, tmp.y),LayerMask.GetMask("AbstractGrid"));
		if (coll != null) {
			ag = coll.GetComponent<AbstractGrid> ();
			if (ag != null && ag.woodFriendly)
				return true;
		}

		coll = Physics2D.OverlapPoint (new Vector2 (tmp.x , tmp.y+1),LayerMask.GetMask("AbstractGrid"));
		if (coll != null) {
			ag = coll.GetComponent<AbstractGrid> ();
			if (ag != null && ag.woodFriendly)
				return true;
		}

		coll = Physics2D.OverlapPoint (new Vector2 (tmp.x , tmp.y-1),LayerMask.GetMask("AbstractGrid"));
		if (coll != null) {
			ag = coll.GetComponent<AbstractGrid> ();
			if (ag != null && ag.woodFriendly)
				return true;
		}

		return false;
	}

}
