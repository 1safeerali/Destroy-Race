using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishline : MonoBehaviour
{
   [SerializeField] ParticleSystem finishline1 ;
    // public ParticleSystem finishline1 = null;
    //  public ParticleSystem finishline2;
    // Start is called before the first frame update
    void awake()
    {

      
    }

    // Update is called once per frame
    //  void Update()
    // {
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")

        {
            finishlineparticle();


        }
    }
    //    }

    void finishlineparticle()
    {
        Instantiate(finishline1);
       // Destroy(gameObject);
       
    } 
    
        
    

    //ParticleSystem part = GetComponent<ParticleSystem>();
    //  part.Play();




}
