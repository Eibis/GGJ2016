using UnityEngine;
using System.Collections;

public class FadeText : MonoBehaviour
{
    public static FadeText Instance {
        get
        {
            return _this;
        }
    }

    private static FadeText _this;

	void Start ()
    {
        _this = this;
	}
	
	void Update ()
    {
	
	}

    public static void Fade()
    {

    }
}
