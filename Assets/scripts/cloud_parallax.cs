using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_parallax : MonoBehaviour
{
    public Camera cam;
    public float speedParallax;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        transform.position = new Vector3(transform.position.x - speedParallax, transform.position.y, transform.position.z);

        if (transform.position.x < ((cam.transform.position.x - width / 2)) - 200) {
            transform.position = new Vector3(((cam.transform.position.x + width / 2)) + 200, transform.position.y, transform.position.z);
        }
    }
}
