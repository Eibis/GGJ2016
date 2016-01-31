using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    private static FadeText _this;

	void Start ()
    {
        _this = this;
		string[] stringArray = new string[6];
		Fade (6, "Era un tranquillo e sonnacchioso Giovedì di Maggio...\ntranquillo e sonnacchioso come non se ne vedevano da anni.");
		Fade (6, "Il buon Timmy era seduto sul pavimento della sua camera,\nmeravigliandosi di quanta sonnecchiosità potesse racchiudersi in un solo giorno.");
		Fade (6, "...\nSi annoiava a morte.");
		Fade (6, "\"Potrei provare a evocare un demone dall'aldilà\" ponderò l'intrepido Timmy,\n\"È un modo come un altro di impegnare il tempo...\"");
		Fade (6, "Decise quindi di inaugurare il suo nuovo Demonomicon,\ndelizioso presente ricevuto dal nonno per il suo compleanno.");
		stringArray [5] = "L'impavido Timmy aprì il libro a pagina 1\ne iniziò a leggere con voce sicura la formula magica:";
		foreach (string s in stringArray) {
			Fade (6, s);
		}
    }
	
	void Update ()
    {
	
	}

    public static void Fade(int time, string text)
    {
        _this.GetComponentInChildren<Text>().text = text;
        _this.StartCoroutine(_this.start_fade(time, text));
    }

    IEnumerator start_fade(int time, string text)
    {
        float timer = time;

        Color color = GetComponent<Image>().color;

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            color.a = Mathf.Lerp(1, 0, 1 - timer / time);
            GetComponent<Image>().color = color;

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
