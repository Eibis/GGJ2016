using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {
	int jump_speed = 150;
    int lateral_speed = 30;
    Vector3 wrld;
	float half_sz;

	void Start() {
		wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
		half_sz = this.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x/2;
	}

	// Update is called once per frame
	void FixedUpdate () {
        
		if (Input.GetKey ("right")) {
			transform.position += Vector3.right * lateral_speed * Time.deltaTime;
		}
		if (Input.GetKey ("left")) {
			transform.position -= Vector3.right * lateral_speed * Time.deltaTime;
		}

		if (this.transform.position.x < (- wrld.x + half_sz))
			this.transform.position = new Vector3(-wrld.x + half_sz,
												  this.transform.position.y,
											      this.transform.position.z);
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ground" && (Input.GetKey("up"))) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * jump_speed, ForceMode2D.Impulse);
		}
	}


}
