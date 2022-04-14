using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
     private Transform Player;
    // public float deltaZ;
    //public bool lookAtTarget = false;
    //GameObject Player;

   public float cameraSpeed = 6;
    public Vector3 offset;
    public Vector3 camVel;
    public float bounds = 5;
    void Awake()
    {
        Player = GameObject.Find("Player").transform;
        //deltaZ = transform.position.z - target.position.z;
    }
   void Update()
    {
       // transform.position = new Vector3.(Input.GetAxisRaw("mouse X")*bounds*Time.deltaTime,Input.GetAxisRaw("mouse Y")*bounds* Time.deltaTime, 0f);
        if (FindObjectOfType<PlayerController>().canMove)
            transform.position += Vector3.forward * cameraSpeed ;
        camVel = Vector3.forward * cameraSpeed ;
          transform.position = Vector3.MoveTowards(transform.position, new Vector3(Player.position.x + offset.x ,
         Player.position.y + offset.y, Player.position.z + offset.z), 25 * Time.deltaTime);
        
    }
   
}
