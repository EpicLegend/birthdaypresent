using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class prec_bom : MonoBehaviour
{

    public ParticleSystem first;

    public ParticleSystem[] second;
    public ParticleSystem[] third;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {

        audio = GetComponent<AudioSource>();

        first.Stop();
        for (int i = 0; i < second.Length; i++)
        {
            second[i].Stop();
        }
        for (int i = 0; i < third.Length; i++)
        {
            third[i].Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "precent")
        {
            first.Play();


            audio.Play();
            Invoke("SecondPart", 0.15f);
            Invoke("ThirdPart", 1.0f);
            Invoke("ExitGame", 3.50f );


        }
    }

    void  SecondPart() {
        for (int i = 0; i < second.Length; i++)
        {
            second[i].Play();
        }
    }

    void ThirdPart()
    {
        for (int i = 0; i < third.Length; i++)
        {
            third[i].Play();
        }
    }

    void ExitGame() {
        Debug.Log("Exit");
        Application.Quit();
    }

}
