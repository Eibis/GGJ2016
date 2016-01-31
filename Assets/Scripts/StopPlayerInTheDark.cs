using UnityEngine;
using System.Collections;

public class StopPlayerInTheDark : MonoBehaviour {

	public GameObject Demon;

	void OnTriggerEnter2D(Collider2D coll) {
		
		if(coll.gameObject == Demon )
		{
			Demon.GetComponent<Keys> ().freezed = true;
		}
	}
}
