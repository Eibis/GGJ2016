using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public GameObject Demon;
    public GameObject bg;
	public GameObject Foreground_liv1;

    // Update is called once per frame
    void LateUpdate()
    {
		float new_left_bounded_x_position = Mathf.Max(Demon.transform.position.x, Foreground_liv1.GetComponent<Renderer> ().bounds.min.x + this.GetComponent<Camera> ().orthographicSize * Screen.width / Screen.height);
		float new_x_position = Mathf.Min (new_left_bounded_x_position, Foreground_liv1.GetComponent<Renderer> ().bounds.max.x - this.GetComponent<Camera> ().orthographicSize * Screen.width / Screen.height);
		this.transform.position = new Vector3(new_x_position,
											  this.transform.position.y,
											  this.transform.position.z);
     }
}
