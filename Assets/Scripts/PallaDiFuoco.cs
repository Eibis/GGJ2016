using UnityEngine;
using System.Collections;

public class PallaDiFuoco : MonoBehaviour {

	// Use this for initialization
    float thrust = 0.4f;
    
    public Rigidbody2D rb;

    void Start()
    {
        Debug.Log("start");
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0f, 10f, 0f);

        if(gameObject.GetComponent<Keys>().destra)

            rb.AddForce(transform.right*500);
        else
            rb.AddForce(transform.right * -500);

    }
    void Update()
    {

    }
}
