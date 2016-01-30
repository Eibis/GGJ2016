﻿using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {
	
    float timer = 20f;
    bool timer_started;

    float jump_speed = 50f;
    float lateral_speed = 20f;
    bool jumping = false;
    bool double_jumping = false;
    float jumping_height = 5f;
    float jump_starting_y;
    float double_jump_starting_y;
    bool falling = false;
    bool jump_released = true;
    bool double_jump_enabled = false;
    bool destra = false;

    public void Update()
    {
        if (timer_started)
        {
            StartCoroutine(start_countdown());
            timer_started = false;
        }
        //GameManager.Istance.object_picked.Contains(find);
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if(jumping && Physics2D.Linecast(this.transform.position, transform.position - new Vector3(0, 0.1f, 0), 1 << LayerMask.NameToLayer("Ground")))
        {
            jumping = false;
            falling = false;
            double_jumping = false;

        }
        if(!falling && jumping && this.GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            falling = true;
        }
        if(jumping && !double_jumping && !(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
        {
            jump_released = true;
        }
        if(double_jump_enabled && jumping && jump_released && !double_jumping && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)))
        {
            falling = false;
            double_jumping = true;
            double_jump_starting_y = transform.position.y;
            jump_released = false;
        }
        if(!jumping && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && this.GetComponent<Rigidbody2D>().velocity.y >= 0)
        {
            jump_starting_y = transform.position.y;
            jumping = true;
            jump_released = false;
        }
        if(jumping && !falling && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && ((transform.position.y - jump_starting_y) < jumping_height || (double_jumping && (transform.position.y - double_jump_starting_y) < jumping_height)))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump_speed);
            jump_released = false;
        }

        if((Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0 || Input.GetKey(KeyCode.D)) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0 || Input.GetKey(KeyCode.A)))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(lateral_speed, this.GetComponent<Rigidbody2D>().velocity.y);
            destra = true;
        }
        else if((Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0 || Input.GetKey(KeyCode.A)) && !(Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0 || Input.GetKey(KeyCode.D)))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-lateral_speed, this.GetComponent<Rigidbody2D>().velocity.y);
            destra = false;
        }
        else if(Mathf.Abs(this.GetComponent<Rigidbody2D>().velocity.x) > 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x * 0.5f, this.GetComponent<Rigidbody2D>().velocity.y);
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
        GameManager.Istance.character_2d.GetComponentInChildren<Light>().intensity = 0;
    }

}
