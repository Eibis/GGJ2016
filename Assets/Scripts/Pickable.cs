using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {

    private Vector3 initial_position;
    bool moved = false; 

	// Use this for initialization
	void Start () {

        initial_position = transform.position;

	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = GameManager.Istance.camera3d.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                moved = !moved;
                Debug.Log("clicked");
            }
        }

    }

    
}
