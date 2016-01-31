using UnityEngine;
using System.Collections;

public class Tazza : Pickable {

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
	}

	public new void rimuovi()
	{
		base.rimuovi();
	}
}