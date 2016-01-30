using UnityEngine;
using System.Collections;

public class Keys : MonoBehaviour {
	int jump_speed = 150;
    int lateral_speed = 30;
    Vector3 wrld;
	float half_sz;
    bool isGrounded;
    float old_y = 0;
    float timer = 20f;
    bool timer_started;

    void Start() {
		wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
		half_sz = this.transform.GetChild(0).GetComponent<Renderer>().bounds.size.x/2;
        old_y = this.transform.position.y;
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

        isGrounded = old_y>=this.transform.position.y && Physics2D.Linecast(this.transform.position, transform.position - new Vector3(0, 0.2f, 0), 1 << LayerMask.NameToLayer("Ground"));
		if (Input.GetKey ("right") || Input.GetAxis("Horizontal") > 0) {
			transform.position += Vector3.right * lateral_speed * Time.deltaTime;
		}
		if (Input.GetKey ("left") || Input.GetAxis("Horizontal") < 0) {
			transform.position -= Vector3.right * lateral_speed * Time.deltaTime;
		}

		if (this.transform.position.x < (- wrld.x + half_sz))
			this.transform.position = new Vector3(-wrld.x + half_sz,
												  this.transform.position.y,
											      this.transform.position.z);
        if (isGrounded && (Input.GetKey("up") || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W)))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jump_speed, ForceMode2D.Impulse);
        }
        old_y = this.transform.position.y;
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
            
            if (timer < 3 && timer > 0)
                GameManager.Istance.character_2d.GetComponentInChildren<Light>().intensity = 0;
            else
                GameManager.Istance.character_2d.GetComponentInChildren<Light>().intensity = 1;

            yield return null;
        }

        GameManager.Istance.character_2d.GetComponentInChildren<Light>().intensity = 0;


    }

}
