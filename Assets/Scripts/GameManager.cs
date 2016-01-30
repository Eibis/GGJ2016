using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public Camera camera3d;
    public Camera camera2d;

    public GameObject scene3d;
    public GameObject scene2d;

    public static GameManager Istance { get { return _this; } }
    private static GameManager _this;
    public bool is_3d = true;
    public GameObject character_2d;
    public GameObject character_3d;
    public List<Pickable> object_picked;

    public GameObject inventory;

	// Use this for initialization
	void Start ()
    {
        _this = this;
        object_picked = new List<Pickable>();
        scene3d.SetActive(true);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton1))
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

        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            if (is_3d)
            {
                is_3d = false;
                scene3d.SetActive(false);
                scene2d.SetActive(true);
            }
            else
            {
                is_3d = true;
                scene3d.SetActive(true);
                scene2d.SetActive(false);
            }
        }
    }
}
