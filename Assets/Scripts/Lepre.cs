using UnityEngine;
using System.Collections;

public class Lepre : Pickable {

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
        GameManager.Istance.set_accendino();

        Debug.Log("eccolo");
    }

    public new void rimuovi()
    {
        base.rimuovi();
        GameManager.Istance.reset_accendino();
    }
}
