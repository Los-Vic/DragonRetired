using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DragonBones;
using UnityEngine.SceneManagement;

public class HpManager : MonoBehaviour {

	private int hp;
	public Image[] images;

	// Use this for initialization
	void Start () {
		hp = 3;
		foreach (Image im in images) {
			im.enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {


	}
	void LateUpdate()
	{

	}
	public int Hp
	{
		get{
			return hp;
		}
		set{
			hp = value;
		}
	}
	public void HpAdd(int i)
	{
		hp += i;
		//Debug.LogWarning (hp);

		for (int j = 0; j < 3; j++) {
			if (j < hp)
				images [j].enabled = true;
			else
				images [j].enabled = false;
		}

		if (i == -1&&hp>0)
			StartCoroutine (PlayHit ());
		if (hp < 1) {
			StartCoroutine (LevelManager.Instance.PlayDie ());
			//	LevelManager.Instance.BackToLastCheckPoint ();
		}
	}


	IEnumerator PlayHit()
	{
		PrinceController pc = FindObjectOfType<PrinceController> ();
		UnityArmatureComponent uac = pc.GetComponent<UnityArmatureComponent> ();
		PrinceAnimator pa = pc.GetComponent<PrinceAnimator> ();

		pc.enabled = false;
		pa.enabled = false;
		uac.animation.GotoAndPlayByFrame ("gethit", 0, 1);

		yield return new WaitForSeconds (0.8f);
		pc.enabled = true;
		pa.enabled = true;
	}
	public void ResetHp()
	{
		hp = 3;
		foreach (Image im in images) {
			im.enabled = true;
		}

	}
}
