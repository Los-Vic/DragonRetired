﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//王子控制器
public class PrinceController : MonoBehaviour {

	public float horizontalForce; // 水平移动作用力
	public Vector2 launchDir;//凝胶作用力方向
	public float launchForce;//凝胶作用力大小
	public float climbVelocity;//在梯子上移动的速度

	private Rigidbody2D m_rb;
	public bool onGround;
	public bool onLadder;


	// Use this for initialization
	void Start () {
		m_rb = GetComponent<Rigidbody2D> ();
		onLadder = false;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.J))
			GetComponent<Prince> ().Interact ();
	}

	void FixedUpdate () {

		if (!onLadder) {
			m_rb.bodyType = RigidbodyType2D.Dynamic;
			onGround = CheckGround ();

			//Debug.Log (Input.GetAxis ("Horizontal").ToString());
			//在地面上才可以控制
			if (onGround) {
				float h = Input.GetAxis ("Horizontal");
				HorizontalMove (h);
				GetComponent<Prince> ().TurnAround (h);
			}
		} else
			MovementOnLadder ();
	}


	//控制水平移动
	public void HorizontalMove(float h)
	{
		m_rb.AddForce (horizontalForce * h * Vector2.right);
	}

	/// <summary>
	/// 凝胶作用
	/// </summary>
	/// <param name="isLeft">凝胶的作用方向是否是向左</param>
	public void GelLaunch(bool isLeft)
	{
		int sign;
		Vector2 dir = launchDir.normalized;

		if (isLeft)
			sign = -1;
		else
			sign = 1;

		dir.x *= sign;

		m_rb.velocity = Vector2.zero;
		m_rb.AddForce (dir*launchForce,ForceMode2D.Impulse);

	}

	private bool CheckGround()
	{
		Collider2D[] colls = Physics2D.OverlapCircleAll (transform.position+new Vector3(0,-0.5f,0),0.1f,LayerMask.GetMask("AbstractGrid","Default"));

		foreach (Collider2D coll in colls) {
			if (coll.gameObject != gameObject && coll.GetComponent<Gel>() == null)
				return true;
		}

		return false;
	}

	/// <summary>
	/// 在梯子上时的移动
	/// </summary>
	private void MovementOnLadder()
	{
		if (m_rb.bodyType == RigidbodyType2D.Dynamic) {
			m_rb.velocity = Vector2.zero;
			m_rb.bodyType = RigidbodyType2D.Kinematic;
		} else {
			if (Input.GetKey (KeyCode.W)) 
				transform.position +=  Vector3.up * climbVelocity * Time.fixedDeltaTime;
			else 
				if(Input.GetKey(KeyCode.S))
					transform.position -=  Vector3.up * climbVelocity * Time.fixedDeltaTime;
		}
	}
}
