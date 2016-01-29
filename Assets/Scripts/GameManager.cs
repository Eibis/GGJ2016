using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Camera camera3d;
    public Camera camera2d;

    public static GameManager Istance { get { return _this; } }
    private static GameManager _this;

	// Use this for initialization
	void Start () {
        _this = this;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
