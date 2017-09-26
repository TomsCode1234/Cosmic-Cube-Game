using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMat : MonoBehaviour {

    AudioSource Clickedbtn;
    AudioSource StartGameSound;

    void Awake()
    {
        Clickedbtn = GameObject.Find("Main UI").GetComponent<AudioSource>();
        StartGameSound = GameObject.Find("Start UI").GetComponent<AudioSource>();
    }

	public void Changecol(string HitCol)
    {
        Clickedbtn.Play();
        Debug.Log("Hit");
        if (HitCol == "Yellow")
        {
            Debug.Log("Yellow");
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        if (HitCol == "Red")
        {
            Debug.Log("Red");
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (HitCol == "Blue")
        {
            Debug.Log("Blue");
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (HitCol == "Green")
        {
            Debug.Log("Green");
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    public void playSound()
    {
        StartGameSound.Play();
    }
}
