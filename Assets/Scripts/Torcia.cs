using UnityEngine;
using System.Collections;

public class Torcia : Pickable {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public new void aggiungi()
    {
        base.aggiungi();
        GameManager.Istance.character_2d.GetComponent<Light>().intensity = 1;
    }

    public new void rimuovi()
    {
        base.rimuovi();

        GameManager.Istance.character_2d.GetComponent<Light>().intensity = 0;
    }
}
