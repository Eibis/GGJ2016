using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    private static FadeText _this;

	void Start ()
    {
        _this = this;

        Fade(3, "teeest");
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

            color.a = Mathf.Lerp(1, 0, time / timer);
            GetComponent<Image>().color = color;

            yield return null;
        }

        gameObject.SetActive(false);
    }
}
