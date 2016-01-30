using UnityEngine;
using System.Collections;

public class PallaDiFuoco : MonoBehaviour {

	// Use this for initialization
    float thrust = 0.4f;
    
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if(gameObject.GetComponent<Keys>().destra)

            rb.AddForce(transform.right*1000,ForceMode2D.Impulse);
        else
            rb.AddForce(transform.right * -1000,ForceMode2D.Impulse);

    }
    void Update()
    {

    }
}
