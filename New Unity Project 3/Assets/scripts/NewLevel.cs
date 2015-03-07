using UnityEngine;
using System.Collections;

public class NewLevel : MonoBehaviour {
	public string lvltoLoad;
	void OnTriggerEnter(Collider info)
	{
		if (info.name == "Player") {
			Application.LoadLevel(lvltoLoad);
		}
	}
}
