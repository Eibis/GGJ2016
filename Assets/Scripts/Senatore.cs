using UnityEngine;
using System.Collections;

public class Senatore : MonoBehaviour {
    public float amplitude = 1f;
    public float speed = 1f;
    public bool horizontal = true;
    private float start_x, start_y;

	// Use this for initialization
	void Start () {
        start_x = transform.position.x;
        start_y = transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        if(horizontal)
        {
            this.transform.position = new Vector3(start_x + Mathf.Sin(Time.time * speed) * amplitude, start_y, this.transform.position.z);
        }
        else
        {
            this.transform.position = new Vector3(start_x, start_y + Mathf.Sin(Time.time * speed) * amplitude, this.transform.position.z);
        }
	}
}
