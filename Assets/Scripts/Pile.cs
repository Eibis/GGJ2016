using UnityEngine;
using System.Collections;

public class Pile : Pickable {

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
        GameManager.Istance.set_luce();
    }

    public new void rimuovi()
    {
        base.rimuovi();
        GameManager.Istance.set_luce();
    }
}
