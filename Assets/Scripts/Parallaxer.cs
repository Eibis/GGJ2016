using UnityEngine;
using System.Collections;

public class Parallaxer : MonoBehaviour {

	public float percent_out = 0.1f;
	public GameObject ForeGround;
	public GameObject Camera;
	public float x_offset;
	public float y_offset;
	public bool parallax_y = true;
	float starting_x;
	float starting_y;
	float last_camera_x_pos;

	void Start() {
		starting_x = ForeGround.GetComponent<Renderer>().bounds.min.x + this.GetComponent<Renderer>().bounds.size.x / 2 + x_offset;
		starting_y = ForeGround.GetComponent<Renderer>().bounds.min.y + this.GetComponent<Renderer>().bounds.size.y / 2 + y_offset;
		this.transform.position = new Vector3 (starting_x, starting_y, this.transform.position.z);

		last_camera_x_pos = Camera.transform.position.x;
	}
		

	// Update is called once per frame
	void LateUpdate () {
		float x_update = percent_out * (Camera.transform.position.x - last_camera_x_pos);
		last_camera_x_pos = Camera.transform.position.x;
		this.transform.position -= new Vector3 (x_update, 0);  

	}
}
