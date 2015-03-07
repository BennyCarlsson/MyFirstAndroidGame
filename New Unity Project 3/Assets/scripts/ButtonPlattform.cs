using UnityEngine;
using System.Collections;

public class buttonPlattform : MonoBehaviour {

	bool btnPressed = false;
	bool btnReleased = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (btnPressed) {
			if (transform.position.y > -0.5f) {
				Vector3 temp = transform.position;
				temp.y -= 3 * Time.deltaTime;
				transform.position = temp;
			}
		} else if (transform.position.y < -0.38f) {
			Vector3 temp = transform.position;
			temp.y += 3 * Time.deltaTime;
			transform.position = temp;
		}
	}

	void OnCollisionEnter()
	{
		btnPressed = true;
	}
	void OnCollisionExit()
	{
		btnPressed = false;
	}
}
