﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Keys : MonoBehaviour {
	
    float timer = 20f;
    bool timer_started;

    float jump_speed = 50f;
    float lateral_speed = 20f;
    bool jumping = false;
    bool double_jumping = false;
    float jumping_height = 7f;
    float jump_starting_y;
    float double_jump_starting_y;
    bool falling = false;
    bool jump_released = true;
    public bool destra = false;
    public bool freezed = false;

    public Animator player_animator;

    float timer_shooting = 0;
    public List<GameObject> pallottole;

    public void Start()
    {
        player_animator = GetComponentInChildren<Animator>();
    }

    public void Update()
    {
        if (timer_started)
        {
            StartCoroutine(start_countdown());
            timer_started = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (!falling && this.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            falling = true;
        }
        if(falling && (Physics2D.Linecast(this.transform.position, transform.position - new Vector3(0, 0.4f, 0), 1 << LayerMask.NameToLayer("Ground")) || Physics2D.Linecast(this.transform.position, transform.position - new Vector3(-this.GetComponent<BoxCollider2D>().size.x / 2, 0.4f, 0), 1 << LayerMask.NameToLayer("Ground")) || Physics2D.Linecast(this.transform.position, transform.position - new Vector3(this.GetComponent<BoxCollider2D>().size.x / 2, 0.4f, 0), 1 << LayerMask.NameToLayer("Ground"))))
        {
            jumping = false;
            falling = false;
            double_jumping = false;
            player_animator.SetBool("jump", false);

        }
        if (jumping && !double_jumping && !(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
        {
            jump_released = true;
        }
		if(GameManager.Istance.get_double_jump() && jumping && jump_released && !double_jumping && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
        {
            falling = false;
            double_jumping = true;
            double_jump_starting_y = transform.position.y;
            jump_released = false;
        }
        if(!jumping && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && !falling)
        {
            if (!jumping && !falling)
            {
                player_animator.SetBool("jump", true);
                SoundManager.PlaySalto();
            }

            jump_starting_y = transform.position.y;
            jumping = true;
            jump_released = false;
        }
        if(jumping && !falling && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && ((transform.position.y - jump_starting_y) < jumping_height || (double_jumping && (transform.position.y - double_jump_starting_y) < jumping_height)))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump_speed);
            jump_released = false;
        }

        if(!freezed)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                SoundManager.PlayPasso(); 
                player_animator.SetFloat("movement", 1);
            }
            else
                player_animator.SetFloat("movement", 0);

            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0 || Input.GetKey(KeyCode.D)) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0 || Input.GetKey(KeyCode.A)))
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(lateral_speed, this.GetComponent<Rigidbody2D>().velocity.y);

                if (!destra)
                    player_animator.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);

                destra = true;
            }
            else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0 || Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0 || Input.GetKey(KeyCode.D)))
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-lateral_speed, this.GetComponent<Rigidbody2D>().velocity.y);

                if (destra)
                    player_animator.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);

                destra = false;
            }
            else if (Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) > 0)
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x * 0.5f, this.GetComponent<Rigidbody2D>().velocity.y);
            }
        }
		else{
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0,this.GetComponent<Rigidbody2D> ().velocity.y	);
            player_animator.SetFloat("movement", 0);
		}

		if (GameManager.Istance.get_accendino())
        {
            player_animator.SetBool("fire_attack", false);

            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKey(KeyCode.JoystickButton5))
            {

                if (timer_shooting > 0.5f)
                {
                    pallottole.Add((GameObject)Instantiate(Resources.Load("PallaDiFuoco"), new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), Quaternion.identity));
                    timer_shooting = 0;
                    SoundManager.PlayFuoco();
                }

            }
            timer_shooting += Time.deltaTime;
        }
        else
        {
            player_animator.SetBool("tail_attack", false);

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {/*
                if (!destra)
                    player_animator.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                else
                    player_animator.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);

                destra = !destra;*/

                player_animator.SetBool("tail_attack", true);

                SoundManager.PlayCodata();
            }
        }

    }

    public void start_timer()
    {
        timer_started = true;
    }

    public IEnumerator start_countdown()
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        //GameManager.Istance.character_2d.GetComponentInChildren<Light>().intensity = 0;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            foreach (GameObject bullet in pallottole)
            {
                Destroy(bullet);
            }

            pallottole.Clear();

            GameManager.Istance.LoadCheckpoint();
        }

        if (coll.gameObject.tag == "Arma")
        {
            if (timer_shooting > 0.5f)
            {
                foreach (GameObject bullet in pallottole)
                {
                    Destroy(bullet);
                }

                pallottole.Clear();

                GameManager.Istance.LoadCheckpoint();

                timer_shooting = 0;
            }



        }
    }
}
