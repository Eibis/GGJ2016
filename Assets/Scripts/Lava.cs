using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour
{
    private Vector3 startPos, toPos;
    private float timeStart;
    public Vector3 distance;
    public AnimationCurve curve;

    void Start ()
    {
        startPos = transform.position;

        foreach(Transform t in transform)
        {
            t.gameObject.AddComponent<Lava>();
        }

        StartCoroutine(start_lava_animation());
	}

    IEnumerator start_lava_animation()
    {
        if (transform.childCount > 0)
        {
            while (true)
            {

                foreach (Transform t in transform)
                    transform.GetChild(Random.Range(0, transform.childCount)).gameObject.SetActive(true);

                transform.GetChild(Random.Range(0, transform.childCount)).gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);
            }
        }
        else
            yield return null;
    }

    public float speed = 1;
    public float amplitude = 2;
    public int octaves = 4;
    public Vector3 vel;

    Vector3 destination;
    int currentTime = 0;

    void FixedUpdate()
    {
        // if number of frames played since last change of direction > octaves create a new destination
        if (currentTime > octaves)
        {
            currentTime = 0;
            destination = generateRandomVector(amplitude);
        }

        // smoothly moves the object to the random destination
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, destination, ref vel, speed);

        currentTime++;
    }

    // generates a random vector based on a single amplitude for x y and z
    Vector3 generateRandomVector(float amp)
    {
        Vector3 result = new Vector3();
        for (int i = 0; i < 3; i++)
        {
            float x = Random.Range(-amp, amp);
            result[i] = x;
        }
        return result;
    }
}
