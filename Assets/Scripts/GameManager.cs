using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public Camera camera3d;
    public Camera camera2d;

    public static GameManager Istance { get { return _this; } }
    private static GameManager _this;
    public bool is_3d = true;

    public List<Pickable> object_picked;

	// Use this for initialization
	void Start () {
        _this = this;
        object_picked = new List<Pickable>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = GameManager.Istance.camera3d.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2.25f))
            {
                Pickable pickable = hit.collider.gameObject.GetComponent<Pickable>();

                if (pickable)
                {
                    pickable.hit();
                }
            }
        }
    }
}
