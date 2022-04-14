using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorWall : MonoBehaviour
{
  
    [SerializeField] Color newcolor;

   
    void Start()
    {
        //GetColor();
        Renderer rend = GetComponent<Renderer>();
        // rend.material.color = newcolor;
        rend.material.color = newcolor;
        //Color tempColor = newcolor;
        //  Renderer rend = gameObject.GetComponent<Renderer>();
        //rend.material.color = newcolor;
        // re//nd.material.SetColor("_colColor.a = .5f;



    }

    public Color  GetColor()
    {
        FindObjectOfType<AudioManager>().Play("colorwall");
        return newcolor;
    }   
} 
