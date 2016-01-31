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

        rb = GetComponent<Rigidbody2D>();

        Transform tmp_transform = GetComponentInChildren<Transform>();

        tmp_transform.position = transform.position;

        Rigidbody2D tmp = GetComponentInChildren<Rigidbody2D>();

        if (direction_d)
        {
            rb.AddForce(transform.right * 40, ForceMode2D.Impulse);
            tmp.AddForce(transform.right * 40, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(transform.right * -40, ForceMode2D.Impulse);
            tmp.AddForce(transform.right * -40, ForceMode2D.Impulse);

        }

    }
    void Update()
    {

        if (tempo_vita > 5)
        {
            die();
        }
        tempo_vita += Time.deltaTime;

        Transform tmp = gameObject.GetComponentInChildren<Transform>();

        Debug.Log(tmp.position.z);

    }

    void die()
    {
       // Destroy(gameObject);
    }
}
