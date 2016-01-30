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

    public Transform checkpoint;

    private bool lava_active = true;
    private bool lava_to_active = true;

    private bool double_jump = false;
    private bool fireballing = false;

    public Lava[] lavas;

    // Use this for initialization
    void Start ()
    {
        _this = this;
        object_picked = new List<Pickable>();
        
        if (is_3d)
        {
            scene3d.SetActive(true);
            scene2d.SetActive(false);
        }
        else
        {
            scene3d.SetActive(false);
            scene2d.SetActive(true);
        }

        checkpoint = transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.JoystickButton1)) && is_3d)
        { 
            Ray ray = GameManager.Istance.camera3d.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 2.25f))
            {

                if (hit.collider.CompareTag("Pickable"))
                {
                    hit.collider.SendMessage("hit");
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

                if (lava_active != lava_to_active)
                {
                    lavas = (Lava[])FindObjectsOfType<Lava>();

                    if (lavas != null)
                        set_lava_int();
                }
            }
            else
            {
                is_3d = true;
                scene3d.SetActive(true);
                scene2d.SetActive(false);
            }
        }
    }

    public void LoadCheckpoint()
    {
        character_2d.transform.position = checkpoint.position;
    }

    public void set_lava()
    {
        lava_to_active = !lava_active;
    }

    public void set_lava_int()
    {
        lava_active = !lava_active;

        lava_to_active = lava_active;

        if (lava_active)
        {
            foreach (Lava lava in lavas)
            {
                lava.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Lava lava in lavas)
            {
                lava.gameObject.SetActive(false);
            }
        }
    }

    public void set_double_jump()
    {
        double_jump = !double_jump;

        character_2d.GetComponent<Keys>().double_jump_enabled = double_jump;
    }
}
