using UnityEngine;
using System.Collections;

public class Bottiglia : Pickable
{
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
        GameManager.Istance.reset_lava();
    }

    public new void rimuovi()
    {
        base.rimuovi();
        GameManager.Istance.set_lava();
    }
}
