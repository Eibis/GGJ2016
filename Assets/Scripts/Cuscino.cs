using UnityEngine;
using System.Collections;

public class Cuscino : Pickable {

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
		GameManager.Istance.set_Immortality();
	}

	public new void rimuovi()
	{
		base.rimuovi();
		GameManager.Istance.reset_Immortality();
	}
}
