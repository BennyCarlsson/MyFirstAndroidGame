using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour {

	bool doRotation = false;
	bool rotateBack = false;
	bool walkedOfPlatform = false;
	public Transform cube;
	float rotateZ = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(doRotation){
			if (!rotateBack) {
				if (rotateZ < 90) {
					rotateZ += 30 * Time.deltaTime;
				} else {
					rotateBack = true;
				}
			}
			if (rotateBack && walkedOfPlatform) {
				if(rotateZ > 0){
					rotateZ -= 30 * Time.deltaTime;
				}else{
					rotateBack = false;
					doRotation = false;
				}
			}
			
			Vector3 temp = cube.transform.eulerAngles;
			temp.z = rotateZ;
			cube.transform.eulerAngles = temp;
		}
	}

	void OnCollisionEnter()
	{
		doRotation = true;
		walkedOfPlatform = false;
	}
	void OnCollisionExit()
	{
		walkedOfPlatform = true;
	}

}
