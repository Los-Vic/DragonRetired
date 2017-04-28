using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DragonBones;
using UnityEngine.SceneManagement;

public class HpManager : MonoBehaviour {

	private int hp;
	public Text hpText;

	// Use this for initialization
	void Start () {
		hp = 3;
	}
	
	// Update is called once per frame
	void Update () {

		hpText .text = hp.ToString ();

	}
	void LateUpdate()
	{
		if (hp < 1) {
			hp = 3;
			StartCoroutine (LevelManager.Instance.PlayDie ());
		//	LevelManager.Instance.BackToLastCheckPoint ();
		}
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
		if (i == -1&&hp>0)
			StartCoroutine (PlayHit ());
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

}
