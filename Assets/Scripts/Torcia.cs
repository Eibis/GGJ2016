using UnityEngine;
using System.Collections;

public class Torcia : Pickable {

    public new void hit()
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
    public new void aggiungi()
    {
        base.aggiungi();
        GameManager.Istance.character_2d.GetComponentInChildren<Light>().intensity = 1;
    }

    public new void rimuovi()
    {
        base.rimuovi();
        GameManager.Istance.character_2d.GetComponentInChildren<Light>().intensity = 0;
    }
}
