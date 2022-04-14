using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlespalsh : MonoBehaviour
{
    public int value;
    [SerializeField] Color particlecolor;
    public float speed = 50f;
    public ParticleSystem particleSystem1;
  //  public ParticleSystem Destroyer;

    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
       // transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
   void start()
    {
        //transform.Rotate(0f, 0f, speed * Time.deltaTime);

        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.material.color = particlecolor;
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")

        {
            
            Destroy();
        }
    }
    public Color GetColor()
    {
        return particlecolor;
    }
    public void Destroy()
    {
      //  Instantiate(Destroyer, transform.position, Quaternion.identity);
        Instantiate(particleSystem1, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
