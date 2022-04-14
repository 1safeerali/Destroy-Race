using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlePcube1 : MonoBehaviour
{
    public float speed = 50f;
    public ParticleSystem ParticlePcube1;

    // Start is called before the first frame update
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
    void start()
    {
        //  Instantiate(gameObject,tran)
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")

        {

            Destroy();
        }
    }
    public void Destroy()
    {
        Instantiate(ParticlePcube1, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
