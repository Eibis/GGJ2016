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

	private bool builder_up = false;
	private bool immortality = false;

    private bool accendino = false;

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

		reset_luce ();
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
                    Lava [] temp = (Lava[])FindObjectsOfType<Lava>();

                    if (temp != null && temp.Length > 0)
                        lavas = temp;

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
		character_2d.transform.position = new Vector3 (checkpoint.position.x,checkpoint.position.y, 40);
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

	public void set_Builder()
	{
		builder_up = true;
	}

	public void reset_Builder()
	{
		builder_up = false;
	}

	public bool get_Builder()
	{
		return builder_up;
	}

	public void set_Immortality()
	{
		immortality = true;
	}

	public void reset_Immortality()
	{
		immortality = false;
	}

    public void set_accendino()
    {
        accendino = true;

        character_2d.GetComponent<Keys>().fireballing = true;
    }
    public void reset_accendino()
    {
        accendino = false;

        character_2d.GetComponent<Keys>().fireballing = false;

    }

    public bool get_accendino()
    {
        return accendino;
    }
	public bool get_Immortality()
	{
		return immortality;
	}

    public void set_double_jump()
    {
        double_jump = !double_jump;

        character_2d.GetComponent<Keys>().double_jump_enabled = double_jump;
    }

    public void set_luce()
    {
        SpriteRenderer[] sprites = scene2d.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.material.shader = Shader.Find("Sprites/Default");
        }
    }

	public void reset_luce()
	{
		SpriteRenderer[] sprites = scene2d.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer sprite in sprites)
		{
			sprite.material.shader = Shader.Find ("Sprites/Diffuse");
		}
	}
}
