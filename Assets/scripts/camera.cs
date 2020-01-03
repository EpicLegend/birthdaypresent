using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float damping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public bool faceLeft;
    private Transform player;
    private int lastX;


    public Transform playerObj;
    public Transform left;
    public Transform right;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer(faceLeft);

    }

    public void FindPlayer(bool playerFaceLeft)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lastX = Mathf.RoundToInt(playerObj.position.x);
        if (playerFaceLeft)
        {
            transform.position = new Vector3(playerObj.position.x - offset.x, 30, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(playerObj.position.x + offset.x, 30, transform.position.z);
        }
    }

    void Update()
    {
        if (player)
        {
            
            if (playerObj.position.x > left.position.x && playerObj.position.x < right.position.x) {
                
                int currentX = Mathf.RoundToInt(playerObj.position.x);

                if (currentX > lastX)
                    faceLeft = false; 
                else if (currentX < lastX) 
                    faceLeft = true;

                lastX = Mathf.RoundToInt(playerObj.position.x);

                Vector3 target;
                if (faceLeft)
                {
                    target = new Vector3(playerObj.position.x - offset.x, 30, transform.position.z);
                }
                else
                {
                    target = new Vector3(playerObj.position.x + offset.x, 30, transform.position.z);
                }
                Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
                transform.position = currentPosition;
            }
            
        }
    }
}
