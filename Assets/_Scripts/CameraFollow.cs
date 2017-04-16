using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour {

	public Transform target;
	public bool followY;

	public float smoothTime;
	private Vector3 delta;
	private float fixedY;

	void Start()
	{
		delta = transform.position - target.position;
		fixedY = transform.position.y;

	}
	void FixedUpdate () {

		Vector3 currentV = Vector3.zero;
		Vector3 tar = target.position+delta;

		//不想在y方向移动镜头
		if(!followY)
			tar.y = fixedY;

		transform.position = Vector3.SmoothDamp (transform.position,tar, ref  currentV, smoothTime);
	}
}
