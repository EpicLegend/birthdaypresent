using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activateBom : MonoBehaviour
{
    public int speed;
    private bool start = false;
    public Text count;
    private Animator anim;

    public GameObject obj;

    public

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
    }
     
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "boom")
        {
            anim.SetBool("active", true);
            Destroy(obj, 0.15f);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player_box")
        {
            if (Input.GetKey(KeyCode.E) && count.text == "0")
            {
                start = true;
            }
        }
    }
}
