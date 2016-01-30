using UnityEngine;
using System.Collections;

public class Parallaxer : MonoBehaviour {

	public float emptySize = 1.0f;
	public GameObject ForeGround;
	public float x_offset;
	public float y_offset;

	void Start() {
		float starting_x = ForeGround.GetComponent<Renderer> ().bounds.min.x + this.GetComponent<Renderer> ().bounds.size.x / 2 + x_offset;
		float starting_y = ForeGround.GetComponent<Renderer> ().bounds.min.y + this.GetComponent<Renderer> ().bounds.size.y / 2 + y_offset;
		this.transform.position = new Vector2 (starting_x, starting_y);   
	}

	// Update is called once per frame
	void Update () {
	
	}
}
