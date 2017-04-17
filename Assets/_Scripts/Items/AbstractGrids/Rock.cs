using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//石头类
[RequireComponent(typeof(Rigidbody2D))]

public class Rock : AbstractGrid {

	#region Variables
	public Sprite[] sprites; // 0 : normal ; 1: ice

	public bool onElevator; // 是否在盘子上

	private Rigidbody2D m_rb;
	private SpriteRenderer sp;
	private float originGScale;

	//
	private ParticleSystem ps;
	#endregion

	#region Unity Events
	void Awake()
	{
		sp = GetComponent<SpriteRenderer> ();
		m_rb = GetComponent<Rigidbody2D> ();
		ps = GetComponentInChildren<ParticleSystem> ();
	}

	void Start()
	{
		Initialization ();
		originGScale = m_rb.gravityScale;

	}
	#endregion

	public override void Initialization ()
	{
		state = State.Normal;
		ability = Ability.Flammable | Ability.Freezable | Ability.AntiGable;
	}
	/// <summary>
	/// 火焰魔法，解冻
	/// </summary>
	public  override bool OnFired()
	{
		if (state == State.Freezing) {
			state = State.Normal;
			sp.sprite = sprites [0];
			m_rb.bodyType = RigidbodyType2D.Dynamic;
			Debug.Log ("Rock is fired");
			return true;
		}
		return false;
	}
	/// <summary>
	/// 冰冻魔法，冻结, 定在空中，可被王子击碎
	/// </summary>
	public  override bool OnFreezed()
	{
		if (state == State.Normal) {
			state = State.Freezing;
			sp.sprite = sprites [1];
			m_rb.velocity = Vector2.zero;
			m_rb.bodyType = RigidbodyType2D.Static;
			Debug.Log ("Rock is freezed");
			return true;
		}
		return false;
	}
	/// <summary>
	/// 反重力,下落速度变慢，无法触发开关，可浮到水面
	/// </summary>
	public override  bool OnAntiGravity()
	{
		if (state == State.Normal) {
			state = State.AntiGing;
			Debug.Log ("Rock is antiG");
			StartCoroutine (AntiGravityEvent ());
			return true;
		}
		return false;
	}


	public override void InteractWithPrince()
	{
		if (state==State.Freezing)
			Destroy (gameObject);
	}

	private IEnumerator AntiGravityEvent()
	{
		m_rb.gravityScale = originGScale/10.0f;
		yield return new WaitForSeconds (3);// 3s 重力效果减半
		m_rb.gravityScale = originGScale;
		state = State.Normal;
		Debug.Log ("rock antiG end");
	}


	//石头类中跟电梯相关的实现，目的是石头叠加计算重量
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll != null) {
			Rock rock = coll.collider.GetComponent<Rock> ();
			if (rock !=null ) {
				if (rock.onElevator == true)
					onElevator = true;
			}

			if (coll.collider.GetComponent<ElevatorPlaten> ())
				onElevator = true;
		}
	}

	/// <summary>
	/// Destroies the on explosion.
	/// </summary>
	public void DestroyOnExplosion()
	{
		
		ps.Play ();
		sp.enabled = false;
		m_rb.simulated = false;
		StartCoroutine (DestroyDelay());
	}

	private IEnumerator DestroyDelay()
	{
		yield return new WaitForSeconds (0.15f);
		Debug.Log ("Corutine is on");
		Destroy (gameObject);
	}
}
