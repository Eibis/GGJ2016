using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public string next_level = "";

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(next_level);
    }
}
