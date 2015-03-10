using UnityEngine;
using System.Collections;

public class newPlayerControll : MonoBehaviour {
	float movementSpeed = 5f;
	float distToGround;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		float movement = Input.GetAxis ("Horizontal") * movementSpeed;
		Vector3 temp = transform.position;
		temp.x += movement * Time.deltaTime;
		transform.position = temp;

		//jump
		if (Input.GetKeyDown (KeyCode.W))
	    {
			//if (IsGrounded ()) 
			//{
				Vector3 temp2 =GetComponent<Rigidbody>().velocity;
				temp2.y = (50);
				GetComponent<Rigidbody>().velocity = temp2;
			//}
		}
	}

	bool IsGrounded()
	{
		return Physics.Raycast (transform.position, -Vector3.up, distToGround);
	}
}
