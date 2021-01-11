using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playerimage : MonoBehaviour
{

    public bool button;
    public bool Left;
    public bool Right;
    public bool quit;
    private void Start()
    {
       // Collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        
    }
  

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.name == "Button")
        {
            button = true;
            Debug.Log("collsion");
            other.gameObject.GetComponent<Image>().color = Color.grey; 
        }
        if (other.gameObject.name == "Left")
        {
            Left = true;
           // Debug.Log("collsion");
            other.gameObject.GetComponent<Image>().color = Color.red;
        }
        if (other.gameObject.name == "Right")
        {
            Right = true;
            //Debug.Log("collsion");
            other.gameObject.GetComponent<Image>().color = Color.red;
        }

        if (other.gameObject.name == "Quit")
        {
            quit = true;
            //Debug.Log("collsion");
            other.gameObject.GetComponent<Image>().color = Color.red;
        }
    }


    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.name == "Button")
        {
            button = true;
           
        }
        if (other.gameObject.name == "Left")
        {
            Left = true;

        }
        if (other.gameObject.name == "Right")
        {
            Right = true;

        }

        if (other.gameObject.name == "Quit")
        {
            quit = true;

        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Button")
        {
            button = false;
            other.gameObject.GetComponent<Image>().color = Color.white;
        }
        if (other.gameObject.name == "Left")
        {
            Left = false;
            other.gameObject.GetComponent<Image>().color = Color.white;
        }
        if (other.gameObject.name == "Right")
        {
            Right = false;
            other.gameObject.GetComponent<Image>().color = Color.white;
        }

        if (other.gameObject.name == "Quit")
        {
            quit = false;
            other.gameObject.GetComponent<Image>().color = Color.white;
        }
    }


}
