using UnityEngine;
using System.Collections;

public class StopPlayerInTheDark : MonoBehaviour {

	public GameObject Demon;

	void OnTriggerEnter2D(Collider2D coll) {
		Debug.Log ("Culo");
		if(coll.gameObject == Demon )
		{
			Demon.GetComponent<Keys>().enabled = false;
		}
	}
}
