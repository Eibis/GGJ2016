using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
    public GameObject Demon;
    public GameObject bg;
    float bg_lateral_speed = 0.1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float startingX = transform.position.x;
        this.transform.position = new Vector3(Mathf.Max(Demon.transform.position.x,0),
											  this.transform.position.y,
											  this.transform.position.z);
        bg.transform.position = new Vector3(bg.transform.position.x + ((startingX - transform.position.x) * bg_lateral_speed), bg.transform.position.y, bg.transform.position.z);
    }
}
