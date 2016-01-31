using UnityEngine;
using System.Collections;

public class Masso : MonoBehaviour {

	Vector3 starting_pos;

	void Start() {
		starting_pos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Istance.get_Builder() == true) {
			this.transform.position = starting_pos + new Vector3 (0, 20, 0);
		} else
			this.transform.position = starting_pos;
	}

}
