using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    private static FadeText _this;
    string[] stringArray;
    float[] timers;

    void Start ()
    {
        _this = this;
        Level1();
    }
	
    void Level1()
    {
        stringArray = new string[6];
        timers = new float[6];

        stringArray[0] = "Era un tranquillo e sonnacchioso Giovedì di Maggio...\ntranquillo e sonnacchioso come non se ne vedevano da anni.";
        timers[0] = 3.0f;

        stringArray[1] = "Il buon Timmy era seduto sul pavimento della sua camera,\nmeravigliandosi di quanta sonnecchiosità potesse racchiudersi in un solo giorno.";
        timers[1] = 6.0f;

        stringArray[2] = "...\nSi annoiava a morte.";
        timers[2] = 3.0f;

        stringArray[3] = "\"Potrei provare a evocare un demone dall'aldilà\" ponderò l'intrepido Timmy,\n\"È un modo come un altro di impegnare il tempo...\"";
        timers[3] = 5.0f;

        stringArray[4] = "Decise quindi di inaugurare il suo nuovo Demonomicon,\ndelizioso presente ricevuto dal nonno per il suo compleanno.";
        timers[4] = 5.0f;

        stringArray[5] = "L'impavido Timmy aprì il libro a pagina 1\ne iniziò a leggere con voce sicura la formula magica:";
        timers[5] = 7.0f;

        Fade();
    }

    void Level2()
    {
        stringArray = new string[6];
        timers = new float[6];

        stringArray[0] = "Era un tranquillo e sonnacchioso Giovedì di Maggio...\ntranquillo e sonnacchioso come non se ne vedevano da anni.";
        timers[0] = 3.0f;

        stringArray[1] = "Il buon Timmy era seduto sul pavimento della sua camera,\nmeravigliandosi di quanta sonnecchiosità potesse racchiudersi in un solo giorno.";
        timers[1] = 6.0f;

        stringArray[2] = "...\nSi annoiava a morte.";
        timers[2] = 3.0f;

        stringArray[3] = "\"Potrei provare a evocare un demone dall'aldilà\" ponderò l'intrepido Timmy,\n\"È un modo come un altro di impegnare il tempo...\"";
        timers[3] = 5.0f;

        stringArray[4] = "Decise quindi di inaugurare il suo nuovo Demonomicon,\ndelizioso presente ricevuto dal nonno per il suo compleanno.";
        timers[4] = 5.0f;

        stringArray[5] = "L'impavido Timmy aprì il libro a pagina 1\ne iniziò a leggere con voce sicura la formula magica:";
        timers[5] = 7.0f;

        Fade();
    }

    void Level3()
    {
        stringArray = new string[6];
        timers = new float[6];

        stringArray[0] = "Era un tranquillo e sonnacchioso Giovedì di Maggio...\ntranquillo e sonnacchioso come non se ne vedevano da anni.";
        timers[0] = 3.0f;

        stringArray[1] = "Il buon Timmy era seduto sul pavimento della sua camera,\nmeravigliandosi di quanta sonnecchiosità potesse racchiudersi in un solo giorno.";
        timers[1] = 6.0f;

        stringArray[2] = "...\nSi annoiava a morte.";
        timers[2] = 3.0f;

        stringArray[3] = "\"Potrei provare a evocare un demone dall'aldilà\" ponderò l'intrepido Timmy,\n\"È un modo come un altro di impegnare il tempo...\"";
        timers[3] = 5.0f;

        stringArray[4] = "Decise quindi di inaugurare il suo nuovo Demonomicon,\ndelizioso presente ricevuto dal nonno per il suo compleanno.";
        timers[4] = 5.0f;

        stringArray[5] = "L'impavido Timmy aprì il libro a pagina 1\ne iniziò a leggere con voce sicura la formula magica:";
        timers[5] = 7.0f;

        Fade();
    }

    public static void Fade()
    {
        _this.StartCoroutine(_this.start_fade());
    }

    IEnumerator start_fade()
    {
        for(int i = 0; i < stringArray.Length; i++)
        {
            float timer = timers[i];

            Color c = GetComponentInChildren<Text>().color;

            GetComponentInChildren<Text>().text = stringArray[i];

            while (timer > 0)
            {
                timer -= Time.deltaTime;

                if(timer < timers[i] / 2)
                { 
                    c.a = Mathf.Lerp(1, 0, 1 - timer / timers[i]);
                    GetComponentInChildren<Text>().color = c;
                }

                yield return null;
            }

            c.a = 1f;
            GetComponentInChildren<Text>().color = c;
        }

        float timer_ = 2f;

        Color c_ = GetComponent<Image>().color;

        while (timer_ > 0)
        {
            timer_ -= Time.deltaTime;

            c_.a = Mathf.Lerp(1, 0, 1 - timer_ / 3.0f);
            GetComponent<Image>().color = c_;

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
