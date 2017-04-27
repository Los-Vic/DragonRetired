using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	public void ButtonStartGame(int id)
	{
		LevelManager.Instance.ToScene(id);
	}
}
