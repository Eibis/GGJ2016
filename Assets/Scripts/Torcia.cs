using UnityEngine;
using System.Collections;

public class Torcia : Pickable {

    bool batterie = true;

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

        if (batterie)
        {
            GameManager.Istance.character_2d.GetComponent<Keys>().start_timer();
			GameManager.Istance.set_luce();
        }
        
    }

    public new void rimuovi()
    {
        base.rimuovi();
		GameManager.Istance.reset_luce();
    }
}
