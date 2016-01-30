using UnityEngine;
using System.Collections;

public class PallaDiFuoco : MonoBehaviour {

    // Use this for initialization

    public Rigidbody2D rb;
    bool direction_d;
    void Awake()
    {
        direction_d = GameManager.Istance.character_2d.GetComponent<Keys>().destra;
    }
    void Start()
    {
        Debug.Log("start f");
        rb = GetComponent<Rigidbody2D>();
        
        if(direction_d)
            rb.AddForce(transform.right*40,ForceMode2D.Impulse);
        else
            rb.AddForce(transform.right * -40,ForceMode2D.Impulse);

    }
    void Update()
    {

    }
}
