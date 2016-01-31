using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuInputController : MonoBehaviour {
    public GameObject selector;
    public GameObject[] buttons;
    public string[] scenes;
    public Sprite[] selectedimages;
    public Sprite[] unSelectedimages;
    public LevelManager levelManager;
    private int selected;
    private float repeater;

	public AudioClip audioBeep; 

	private int oldSelectedForSound = 0;

	// Use this for initialization
	void Start ()
    {
        selected = 0;
        setIndex(selected);

    }
	
	// Update is called once per frame
	void Update ()
    {
        //gestione movimento selector e cambiamento indice di selezione
	    if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            repeater = Time.time;
            selected++;
            if(selected >= buttons.Length)
            {
                selected = 0;
            }
            setIndex(selected);
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < -0.1f)
        {
            if((Time.time - repeater) > 0.15)
            {
                repeater = Time.time;
                selected++;
                if(selected >= buttons.Length)
                {
                    selected = 0;
                }
                setIndex(selected);
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            repeater = Time.time;
            selected--;
            if(selected < 0)
            {
                selected = buttons.Length - 1;
            }
            setIndex(selected);
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0.1f)
        {
            if((Time.time - repeater) > 0.15)
            {
                repeater = Time.time;
                selected--;
                if(selected < 0)
                {
                    selected = buttons.Length - 1;
                }
                setIndex(selected);
            }
        }
        //gestione della selezione di una delle opzioni da tastiera
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if(scenes[selected] != "Quit")
            {
                levelManager.LoadLevel(scenes[selected]);
            }
            else
            {
                levelManager.QuitRequest();
            }
        }
    }

    public void setIndex(int index)
    {
        selected = index;
        buttons[oldSelectedForSound].GetComponent<Image>().sprite = unSelectedimages[oldSelectedForSound];
        buttons[index].GetComponent<Image>().sprite = selectedimages[index];
        oldSelectedForSound = selected;
    }
}
