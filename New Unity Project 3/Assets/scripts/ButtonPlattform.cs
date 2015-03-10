using UnityEngine;
using System.Collections;

public class ButtonPlattform : MonoBehaviour {
	
	bool btnPressed = false;
	bool standingOnPlatform = false;
	public Transform cube;
	bool doCubeRotation = false;
	float cubeRotationSpeed = 50f;
	bool cubeRotateBack = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlatFormButtonController ();
		CubeRotationController ();
	}
	void CubeRotationController()
	{
		if (doCubeRotation) {
			if (cube.transform.eulerAngles .z < 90) {
				Vector3 temp = cube.transform.eulerAngles;
				temp.z += cubeRotationSpeed * Time.deltaTime;
				cube.transform.eulerAngles = temp;
			} else {
				doCubeRotation = false;
				cubeRotateBack = true;
				Vector3 temp = cube.transform.eulerAngles;
				temp.z = 90;
				cube.transform.eulerAngles = temp;
			}
		}else if (!doCubeRotation && !standingOnPlatform && cubeRotateBack) 
		{
			if(cube.transform.eulerAngles .z > 0 && cube.transform.eulerAngles .z < 359)
			{
				Vector3 temp = cube.transform.eulerAngles;
				temp.z -= cubeRotationSpeed * Time.deltaTime;
				cube.transform.eulerAngles = temp;
			}else{
				Vector3 temp = cube.transform.eulerAngles;
				temp.z = 0;
				cube.transform.eulerAngles = temp;
				cubeRotateBack = false;
			}
		}
	}
	void PlatFormButtonController()
	{
		if (btnPressed) {
			doCubeRotation = true;
			if (transform.position.y > -0.5f) {
				Vector3 temp = transform.position;
				temp.y -= 1 * Time.deltaTime;
				transform.position = temp;
			}else if(!standingOnPlatform){
				StartCoroutine(SetBtnPressedFalse());
			}
		} else if (transform.position.y < -0.38f) {
			Vector3 temp = transform.position;
			temp.y += 1 * Time.deltaTime;
			transform.position = temp;
		}
	}
	IEnumerator SetBtnPressedFalse()
	{
		yield return new WaitForSeconds(1);
		if (!standingOnPlatform) {
			btnPressed = false;
		}
	}

	void OnCollisionEnter()
	{
		btnPressed = true;
		standingOnPlatform = true;
	}
	void OnCollisionExit()
	{
		standingOnPlatform = false;
	}
}
