using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Camera camera = GameObject.FindObjectOfType<Camera>();
        //float y = this.transform.position.y;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (Time.deltaTime * 40), this.transform.position.z);
        //Debug.Log((camera.WorldToScreenPoint(this.transform.position).y - camera.pixelHeight));
        //Debug.Log(this.transform.position.y);
        //Debug.Log(camera.pixelHeight);
        if ((this.transform.position.y - camera.pixelHeight) >= 0)
        {
            LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
            levelManager.LoadLevel("Menu");
        }
    }
}
