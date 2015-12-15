using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball_Movement : MonoBehaviour {

	public float speed = 45;
	int countLeft;
	int countRight;
	public Text leftText;
	public Text rightText;
	public Text winText;
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed;
		countLeft = 0;
		countRight = 0;
		winText.text = "";
		SetRightText ();
		SetLeftText ();

	}
	
	void Update () {
	
	}
	//checks where the ball hits the paddle
	float hitPosition(Vector2 ballPosition, Vector2 paddlePosition, float paddleHeight) {
		return (ballPosition.y - paddlePosition.y) / paddleHeight;
	}
	void OnCollisionEnter2D(Collision2D collision) {
		//checks left paddle collision to calculate direction of ball
		if (collision.gameObject.name == "Paddle_Left") {
			float newy = hitPosition(transform.position, collision.transform.position,collision.collider.bounds.size.y);
			Vector2 direction = new Vector2(1, newy).normalized;
			GetComponent<Rigidbody2D>().velocity = direction * speed;
		}
		//checks right paddle collision to calculate direction of ball
		if (collision.gameObject.name == "Paddle_Right") {
			float newy = hitPosition(transform.position, collision.transform.position,collision.collider.bounds.size.y);
			Vector2 direction = new Vector2(-1, newy).normalized;
			GetComponent<Rigidbody2D>().velocity = direction * speed;
		}
		//checks left boundry collision and resets ball to center
		if (collision.gameObject.name == "Wall_Left") 
		{
			countRight++;
			SetRightText();
			GetComponent<Rigidbody2D>().position = new Vector2(0,-8);
			GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;

		}
		//checks right boundary collision and resets ball to center
		if (collision.gameObject.name == "Wall_Right") 
		{
			countLeft++;
			SetLeftText();
			GetComponent<Rigidbody2D>().position = new Vector2(0,-8);
			GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
		}
	}
	
	void SetLeftText()
	{
		leftText.text = "Score: " + countLeft.ToString ();
		
		if (countLeft >= 10) 
		{
			winText.text = "Left player wins!";
			Start ();
			
		}
	}
	void SetRightText()
	{
		rightText.text = "Score: " + countRight.ToString ();
		
		if (countRight >= 10) 
		{
			winText.text = "Right player wins!";
			Start ();
			
		}
	}
}
