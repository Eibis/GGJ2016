using UnityEngine;
using System.Collections;

public class StopPlayerInTheDark : MonoBehaviour {

	public GameObject Demon;

	void OnTriggerEnter2D(Collider2D coll) {

		if((coll.gameObject == Demon) && (GameManager.Istance.get_luce() == false))
		{
			Demon.GetComponent<Keys>().freezed = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		Demon.GetComponent<Keys>().freezed = false;
	}

	void Update () {
		if (GameManager.Istance.get_luce())
			Demon.GetComponent<Keys>().freezed = false;
	}
}
