using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
//王子类
public class Prince : AbstractGrid {

	//private int hp;
	private Rigidbody2D m_rb;
	private bool faceRight;
	private HpManager hpM;

	public bool onElevator;

	void Awake()
	{
		m_rb = GetComponent<Rigidbody2D> ();
		hpM = FindObjectOfType<HpManager> ();
	}
	void Start()
	{
		antiGable = true;
		flammable = true;
		faceRight = true;
	}

	/// <summary>
	/// 火焰魔法，受伤掉血，（冻结时）解冻
	/// </summary>
	public  override void OnFired()
	{
		freezed = false;
		hpM.HpAdd (-1);
		Debug.Log ("Prince is fired");
	}
	/// <summary>
	/// 冰冻魔法，冻结掉血，数秒后解冻
	/// </summary>
	public  override void OnFreezed()
	{
		freezed = true;
		Debug.Log ("Prince is freezed");
	}
	/// <summary>
	/// 反重力，数秒内下落速度减慢，无法触发机关
	/// </summary>
	public override  void OnAntiGravity()
	{
		StartCoroutine (AntiGEvent());
		Debug.Log ("Prince is antigravity");
	}


	/// <summary>
	/// 计算屏幕坐标，供shader用
	/// </summary>
	/// <returns>The position on screen.</returns>
	public Vector3 ComputePosOnScreen()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint (transform.position);
		pos.x /= Screen.width;
		pos.y /= Screen.height;

		pos.x *= (float)Screen.width / Screen.height;

		return pos;
	}
	//反重力处理
	private IEnumerator AntiGEvent()
	{
		m_rb.gravityScale = 1;
		yield return new WaitForSeconds (5);
		m_rb.gravityScale = 3;
		Debug.Log ("Prince antiG end");
	}

	//转身
	public void TurnAround(float h)
	{
		if (h > 0) {
			faceRight = true;
			GetComponent<SpriteRenderer> ().flipX = false;
		} else if(h<0) {
			faceRight = false;
			GetComponent<SpriteRenderer> ().flipX = true;
		}
	}
	public override void InteractWithPrince()
	{
	}
	public void Interact()
	{
		if (faceRight) {
			Collider2D coll = Physics2D.OverlapPoint (transform.position + new Vector3 (1f, 0, 0),LayerMask.GetMask("AbstractGrid"));
			if (coll != null) {
				coll.GetComponent<AbstractGrid> ().InteractWithPrince ();
			}
		} else {
			Collider2D coll = Physics2D.OverlapPoint (transform.position + new Vector3 (-1f, 0, 0),LayerMask.GetMask("AbstractGrid"));
			if (coll != null) {
				coll.GetComponent<AbstractGrid> ().InteractWithPrince ();
			}
		}
	}


	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll != null) {


			if (coll.collider.GetComponent<ElevatorPlaten> () != null)//站在电梯上
				onElevator = true;
			
			Rock tmpRock = coll.collider.GetComponent<Rock> (); 

			if (tmpRock != null) {


				if (tmpRock.onElevator) //踩在电梯的石头上
					onElevator = true;
				
				//石头下砸到玩家
				Vector2 dir = tmpRock.transform.position - transform.position;

				if (Vector2.Dot (dir.normalized, Vector2.up) > 0.8f && tmpRock.GetComponent<Rigidbody2D> ().bodyType == RigidbodyType2D.Dynamic) {
					hpM.HpAdd (-1);
					Destroy (tmpRock.gameObject);
				}

			}

			//背门砸死
			if (coll.gameObject.GetComponent<AbstractGrid> () == null && coll.collider.tag !="Ladder") {

				Vector2 dir = coll.transform.position - transform.position;
				if (Vector2.Dot (dir.normalized, Vector2.up) > 0.8f )
				{
					LevelManager.Instance.ReloadScene ();
				}
			}

		}


		}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll != null) {
			if (coll.collider.GetComponent<ElevatorPlaten> () != null)
				onElevator = false;

			Rock tmpRock = coll.collider.GetComponent<Rock> (); 

			if (tmpRock != null) {

				if (tmpRock.onElevator) //离开电梯的石头上
					onElevator = false;
			}
		}

	}
		
}
