using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	float movementSpeed = 5f;
	public static float jumpSpeed = 7f;
	public static float jumpSpeedBonus = 0;
	float distToGround;
	bool doubleJumpAvailable = false;
	private Animator animator;
	public bool jumpBtnPressed = false;
	public bool moveLeft = false;
	public bool moveRight = false;
	Image walkRightBtnImage;
	Image walkLeftBtnImage;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		distToGround = GetComponent<Collider>().bounds.extents.y + 0.1f;

		//walk buttons for chagning color
		GameObject walkRightBtn = GameObject.Find ("walkRightBtn");
		walkRightBtnImage = walkRightBtn.transform.GetComponent<Image>();
		GameObject walkLeftBtn = GameObject.Find ("walkLeftBtn");
		walkLeftBtnImage = walkLeftBtn.transform.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		MovePlayer ();
	}

	void MovePlayer()
	{
		float movement = Input.GetAxis ("Horizontal") * movementSpeed;
		PlayerWalk (movement);

		if (moveRight) {
			movement = 5;
			PlayerWalk (movement);
		}
		if (moveLeft) {
			movement = -5;
			PlayerWalk (movement);
		}

		if (Input.GetKeyDown (KeyCode.W) ||  jumpBtnPressed) 
		{
			if(IsGrounded())
			{
				Jump();
				doubleJumpAvailable = true;
			}
			else if(doubleJumpAvailable)
			{
				Jump();
				doubleJumpAvailable = false;
			}
		}else if(!IsGrounded()){
			animator.SetTrigger ("playerFalling");
		}else if (movement != 0) {
			animator.SetTrigger ("playerWalk");
		}else if(IsGrounded())
		{
			animator.SetTrigger("playerIdle");
		}
		Quaternion rotationTemp = transform.rotation;
		if (movement > 0) { //facing left standard
			rotationTemp.y = 0;
			transform.rotation = rotationTemp;
		} else if(movement < 0){ //facing right
			rotationTemp.y = 180;
		}
		transform.rotation = rotationTemp;
	}
	public void PlayerWalk(float movement)
	{
		Vector3 temp = transform.position;
		temp.x += movement * Time.deltaTime;
		transform.position = temp;
	}
	public void setJumpBtn()
	{
		jumpBtnPressed = true;
	}
	void Jump()
	{
		animator.SetTrigger ("playerJump");
		jumpBtnPressed = false;
		Vector3 temp2 =GetComponent<Rigidbody>().velocity;
		temp2.y = (jumpSpeed+jumpSpeedBonus);
		GetComponent<Rigidbody>().velocity = temp2;
	}
	bool IsGrounded()
	{
		return Physics.Raycast (transform.position, -Vector3.up, distToGround);
	}
	public void setMoveLeft(bool left)
	{	if (left) {
			walkLeftBtnImage.color = Color.white;
		} else {
			walkLeftBtnImage.color = Color.blue;
		}

		moveLeft = left;
	}
	public void setMoveRight(bool right)
	{
		if (right) {
			walkRightBtnImage.color = Color.white;
		} else {
			walkRightBtnImage.color = Color.blue;
		}

		moveRight = right;
	}
}
