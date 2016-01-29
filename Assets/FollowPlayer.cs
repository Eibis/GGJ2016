using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
    public GameObject Demon;
	
	// Update is called once per frame
	void FixedUpdate()
    {
        this.transform.position = new Vector3(Demon.transform.position.x, this.transform.position.y, this.transform.position.z);
	}
}
