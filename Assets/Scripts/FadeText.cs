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
        timers[0] = 7.0f;

        stringArray[1] = "Il buon Timmy era seduto sul pavimento della sua camera,\nmeravigliandosi di quanta sonnecchiosità potesse racchiudersi in un solo giorno.";
        timers[1] = 7.0f;

        stringArray[2] = "...\nDevo completare il rituale, per colpa dei compiti non posso guardare l'ultima puntata dei Rockemon."+
            "Forse mettendo uno dei miei strumenti da disegno preferiti nel pentacolo il demone verrà in mio soccorso.";
        timers[2] = 11.0f;

        stringArray[4] = "Decise quindi di inaugurare il suo nuovo Demonomicon,\ndelizioso presente ricevuto dal nonno per il suo compleanno.";
        timers[3] = 7.0f;

        stringArray[5] = "L'impavido Timmy aprì il libro a pagina 1\ne iniziò a leggere con voce sicura la formula magica:";
        timers[4] = 7.0f;

        Fade();
    }

    void Level2()
    {
        stringArray = new string[6];
        timers = new float[6];

        stringArray[0] = "Re dei demoni: \"Questa volta è il tuo turno, sei stato evocato da un altro mondo e per quanto lo odi, non puoi farne a meno, è il fato di tutti i demoni cornuti."+
            "Ora va, a lavoro compiuto riceverai un bellissimo nuovo corno, da aggiungere alla tua collezione o magari incollarlo da qualche parte sul tuo corpo.";
        timers[0] = 3.0f;
        
        Fade();
    }

    void Level3()
    {
        stringArray = new string[0];
        timers = new float[0];
        
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

                if(timer < timers[i] * 2f / 3f)
                {
                    c.a = lerpAlpha(timers[i] / 3f); // Mathf.Lerp(1, 0, 1f - (timer / 2f) / (timers[i] / 2f));
                    GetComponentInChildren<Text>().color = c;
                }

                if (Input.anyKeyDown)
                    break;

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

            c_.a = lerpAlpha(2f);
            GetComponent<Image>().color = c_;

            if (timer_ < 0)
                break;

            yield return null;
        }

        gameObject.SetActive(false);
    }


    float lerpAlpha(float duration)
    {
        float lerp  = Mathf.PingPong(Time.time, duration) / duration;

        return Mathf.Lerp(0.0f, 1.0f, lerp);
    }
}
