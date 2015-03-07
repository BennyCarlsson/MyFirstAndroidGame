using UnityEngine;
using System.Collections;

public class BoingControll : MonoBehaviour {

	float maxHeight;
	float minHeight;
	float rayLength = 0.45f;
	// Use this for initialization
	void Start () {

		maxHeight = transform.position.y;
		minHeight = (maxHeight - 0.7f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Physics.Raycast (transform.position, Vector3.up, rayLength) && transform.position.y > minHeight){
			Vector3 temp = transform.position;
			temp.y -= (1.2f * Time.deltaTime);
			transform.position = temp;
			PlayerController.jumpSpeedBonus = 10f;
		}else if (!Physics.Raycast (transform.position, Vector3.up, rayLength) && transform.position.y < maxHeight) {
			Vector3 temp = transform.position;
			temp.y += (1.9f  * Time.deltaTime);
			transform.position = temp;
			PlayerController.jumpSpeedBonus = 0f;
		}
	}
}




















