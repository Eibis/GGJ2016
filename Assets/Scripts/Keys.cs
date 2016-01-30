using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {

	int jumpSpeed = 150;
    float lateral_speed = 0.5f;
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey ("right")) {
			Vector3 position = this.transform.position;
			position.x += lateral_speed;
			this.transform.position = position;
		}
		if (Input.GetKey ("left")) {
			Vector3 position = this.transform.position;
			position.x -= lateral_speed;
			this.transform.position = position;
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground" && (Input.GetKey("up"))) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpSpeed, ForceMode2D.Impulse);
		}
	}
}
