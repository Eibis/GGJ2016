using UnityEngine;
using System.Collections;

public class FadeText : MonoBehaviour
{
    private static FadeText _this;

	void Start ()
    {
        _this = this;

        start_fade(3, "teeest");
    }
	
	void Update ()
    {
	
	}

    public static void Fade(int time, string text)
    {
        _this.StartCoroutine(_this.start_fade(time, text));
    }

    IEnumerator start_fade(int time, string text)
    {
        float timer = time;

        while (timer > 0)
        {
            timer -= Time.deltaTime;

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
