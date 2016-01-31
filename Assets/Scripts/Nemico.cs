using UnityEngine;
using System.Collections;

public class Nemico : MonoBehaviour
{

    int lateral_speed = 5;
    Vector3 wrld;
    float half_sz;
    bool isGrounded;
    bool verso_destra;
    float appena_cambiato = 0;
    Animator animator;

    void Start()
    {
        verso_destra = true;
        animator = GetComponentInChildren<Animator>();
    }


    // Update is called once per frame
    public void Update()
    {
        animator.SetBool("attacking", false);

        float x;
        if (!verso_destra)
            x = 1;
        else
            x = -1;

        isGrounded = Physics2D.Linecast(this.transform.position, transform.position - new Vector3(x, 1.5f, 0), 1 << LayerMask.NameToLayer("Ground"));

        if (!isGrounded)
        {
            verso_destra = !verso_destra;
            
            if (verso_destra)
                animator.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
            else
                animator.transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
        }


        if (verso_destra)
        {
            transform.position += Vector3.right * lateral_speed * Time.deltaTime;

        }
        else
        {

            transform.position -= Vector3.right * lateral_speed * Time.deltaTime;

        }

        appena_cambiato += Time.deltaTime;


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("attacking", true);
        }

        if (collision.gameObject.tag == "Muro" && !isGrounded)
        {
            if (appena_cambiato > 1f)
            {
                appena_cambiato = 0;
            }
            else
            {
                if (verso_destra)
                {
                    verso_destra = !verso_destra;

                }
                else
                {
                    verso_destra = !verso_destra;
                }
            }
        }

        if (collision.gameObject.tag == "Arma")
        {
            Die();

            Destroy(collision.gameObject);
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Arma")
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    /* public void OnDrawGizmos()
     {
         float x;
         if (!verso_destra)
             x = 2;
         else
             x = -2;
         Gizmos.color = Color.red;
         Gizmos.DrawLine(this.transform.position, transform.position - new Vector3(x, 1.5f, 0));
     }
     */
}
