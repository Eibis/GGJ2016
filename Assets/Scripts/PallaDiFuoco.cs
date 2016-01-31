using UnityEngine;
using System.Collections;

public class PallaDiFuoco : MonoBehaviour
{

    // Use this for initialization

    public Rigidbody2D rb;
    bool direction_d;

    float tempo_vita;

    void Awake()
    {
        direction_d = GameManager.Istance.character_2d.GetComponent<Keys>().destra;
        tempo_vita = 0;
    }
    void Start()
    {
        Debug.Log("start f");
        rb = GetComponent<Rigidbody2D>();

        if (direction_d)
            rb.AddForce(transform.right * 40, ForceMode2D.Impulse);
        else
            rb.AddForce(transform.right * -40, ForceMode2D.Impulse);

    }
    void Update()
    {

        if (tempo_vita > 5)
        {
            die();
        }
        tempo_vita += Time.deltaTime;

    }

    void die()
    {
        Destroy(gameObject);
    }
}
