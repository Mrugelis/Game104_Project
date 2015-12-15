using UnityEngine;
using System.Collections;

public class Paddle_Movement : MonoBehaviour {
	public float speed = 45;
	public string axis = "Vertical";
	void FixedUpdate(){
		float y = Input.GetAxisRaw (axis);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, y) * speed;

	}

}
