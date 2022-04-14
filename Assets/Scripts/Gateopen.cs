using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateopen : MonoBehaviour
   
{
   

    public Transform RotarL, RotarR;
    float speed = 40f;
    bool Rotate = false;
   
   

    // Update is called once per frame
    void Update()
    {
      
        if (Rotate)
        {
            
            if (RotarR.eulerAngles.z <= 90)
            {
               // transform.Rotate(0f, 0f, speed * Time.deltaTime);
                 RotarR.Rotate(Vector3.forward * speed * Time.deltaTime);
                
            }
           if (RotarR.eulerAngles.z <= 90)
            {
                RotarL.Rotate(Vector3.back* speed * Time.deltaTime);
            }
        }
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rotate = true;
           
           // Destroy(gameObject);
        }
       


  
    }
}
