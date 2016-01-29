using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {

    private Vector3 initial_position;
    bool moved = false;

    public Vector3 ritual_position; 
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
                if (hit.collider.gameObject.GetComponent<Pickable>())
                { 
                    if(moved)
                    {
                        transform.position = initial_position;
                        GameManager.Istance.object_picked.Remove(this);
                    }
                    else
                    {
                        transform.position = ritual_position;
                        GameManager.Istance.object_picked.Add(this);
                    }
                    moved = !moved;
                    Debug.Log("clicked");
                }
            }
        }

    }

    
}
