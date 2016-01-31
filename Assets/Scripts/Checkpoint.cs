using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        //transform.position = other.transform.position;
        GameManager.Istance.checkpoint = transform;
    }
}
