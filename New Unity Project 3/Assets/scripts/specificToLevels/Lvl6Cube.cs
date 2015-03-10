using UnityEngine;
using System.Collections;

public class Lvl6Cube : MonoBehaviour {

	public Transform text;
	bool alreadyFalling = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -20 && !alreadyFalling) {
			alreadyFalling = true;
			StartCoroutine(Boxen());
		}
	}

	IEnumerator Boxen()
	{
		text.GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds(3);
		text.GetComponent<Renderer>().enabled = false;
		transform.position = new Vector3 (0,20,0);
		alreadyFalling = false;
	}
}
