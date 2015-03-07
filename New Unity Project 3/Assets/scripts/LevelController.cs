using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -10) {
			Application.LoadLevel("Level1");
		}
	}
	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
