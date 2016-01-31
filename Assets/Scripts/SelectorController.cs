using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectorController : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler 
{
    public MenuInputController menuInputController;
    public int buttonIndex;

	public AudioClip beep;

    public void OnPointerEnter(PointerEventData eventData)
    {
        menuInputController.setIndex(buttonIndex);
    }

	public void OnPointerClick(PointerEventData eventData)
	{
		
	}

}
