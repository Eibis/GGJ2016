using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {

    private Vector3 initial_position;
    bool moved = false;

    public Vector3 ritual_position; 

	void Start ()
    {

        initial_position = transform.position;

	}

    public void hit()
    {
        if (moved)
        {
            transform.localPosition = initial_position;
            GameManager.Istance.object_picked.Remove(this);
        }
        else
        {
            transform.localPosition = ritual_position;
            GameManager.Istance.object_picked.Add(this);
        }

        moved = !moved;
    }
    
}
