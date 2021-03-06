﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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

    private bool double_jump = false;

	private bool builder_up = false;
	private bool immortality = false;
	private bool light = false;

    private bool accendino = false;
    private bool coniglio = false;

    public Lava[] lavas;

    public GameObject crosshair;

    // Use this for initialization
    void Start ()
    {
        _this = this;
        object_picked = new List<Pickable>();
        
        if (is_3d)
        {
            scene3d.SetActive(true);
            scene2d.SetActive(false);
            crosshair.SetActive(true);

            SoundManager.PlayStanza();


        }
        else
        {
            scene3d.SetActive(false);
            scene2d.SetActive(true);
            crosshair.SetActive(false);

            Scene check_scene = SceneManager.GetActiveScene();

            if (check_scene.name == "Level1" || check_scene.name == "Level3")
            {
                SoundManager.PlayIntroDemoniaco();
            }
            else
            {
                SoundManager.PlayIntroGhiaccio();
            }
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
                crosshair.SetActive(false);

                Scene check_scene = SceneManager.GetActiveScene();

                if (check_scene.name == "Level1" || check_scene.name == "Level3")
                {
                    SoundManager.PlayIntroDemoniaco();
                    SoundManager.PlayDemonio();
                }
                else
                {
                    SoundManager.PlayIntroGhiaccio();
                    SoundManager.PlayGhiaccio();
                }
            }
            else
            {
                is_3d = true;
                scene3d.SetActive(true);
                scene2d.SetActive(false);
                crosshair.SetActive(true);
                SoundManager.PlayStanza();
                
            }
        }
    }

    public void LoadCheckpoint()
    {
        SoundManager.PlayMorte();
		character_2d.transform.position = new Vector3 (checkpoint.position.x,checkpoint.position.y, 40);
    }

    public void set_lava()
    {
		foreach (Lava lava in lavas)
		{
			lava.gameObject.SetActive(true);
		}
    }

	public void reset_lava()
	{
		foreach (Lava lava in lavas)
		{
			lava.gameObject.SetActive(false);
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

    public void set_coniglio()
    {
        coniglio = !coniglio;
        if (coniglio)
        {
            set_double_jump();
        }
    }


    public bool get_coniglio()
    {
        return accendino;
    }

    public void set_accendino()
    {
        accendino = true;
    }

    public void reset_accendino()
    {
        accendino = false;
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
        double_jump = true;
    }

	public void reset_double_jump()
	{
		double_jump = false;
	}

	public bool get_double_jump()
	{
		return double_jump;
	}

    public void set_luce()
    {
		light = true;

		scene2d.transform.FindChild("PointLights").gameObject.SetActive(false);
		scene2d.transform.FindChild("Directional light").gameObject.SetActive(true);

    }

	public void reset_luce()
	{
		light = false;
		SpriteRenderer[] sprites = scene2d.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer sprite in sprites)
		{
			sprite.material.shader = Shader.Find ("Sprites/Diffuse");
		}

        if(scene2d.transform.FindChild("PointLights") != null)
		    scene2d.transform.FindChild("PointLights").gameObject.SetActive(true);

        if (scene2d.transform.FindChild("Directional light") != null)
            scene2d.transform.FindChild("Directional light").gameObject.SetActive(false);

	}

	public bool get_luce() {
		return this.light;
	}
}
