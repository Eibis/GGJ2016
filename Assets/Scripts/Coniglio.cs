using UnityEngine;
using System.Collections;

public class Coniglio : Pickable {

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
		GameManager.Istance.set_double_jump ();
    }

    public new void rimuovi()
    {
        base.rimuovi();
		GameManager.Istance.reset_double_jump ();
    }
}
