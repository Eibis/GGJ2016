using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (GameManager.Istance.get_Immortality() == true)
			this.tag = "Untagged";
		else
			this.tag = "Enemy";
	}
}