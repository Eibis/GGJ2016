using UnityEngine;
using System.Collections;

public class Pickable : MonoBehaviour {

    private Vector3 initial_position;
    protected bool moved = false;

    public Vector3 ritual_position;

	void Start ()
    {

        initial_position = transform.localPosition;

        gameObject.tag = "Pickable";

	}

    public void hit()
    {
        if (moved)
        {
            rimuovi();
        }
        else
        {
            aggiungi();
        }

        moved = !moved;
    }

    public void aggiungi()
    {
        transform.localPosition = ritual_position;
        GameManager.Istance.object_picked.Add(this);
    }

    public void rimuovi()
    {
        transform.localPosition = initial_position;
        GameManager.Istance.object_picked.Remove(this);
    }
}
