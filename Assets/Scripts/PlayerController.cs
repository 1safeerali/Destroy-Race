using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
    
      [SerializeField] Color myColor;
    private Rigidbody rb;
    private Vector3 lastMousePos;
    public float sensitivity = .60f, clampDelta = 42f;
     public float bounds = 4;    
    public float speed = 5f;
    public bool canMove;
    Renderer rend;
    //float Rotate = 5f;
    private Animator anim;
    //[SerializeField] GameObject stepRayupper;
   // [SerializeField] GameObject stepRaylower;
  //  [SerializeField] float stepHeight = 0.3f;
 //   [SerializeField] float stepSmooth = 0.1f;
    [HideInInspector]
    public bool  gameOver, finish;
    public GameObject winpanel;
    public GameObject GameOverpanal;

    void Awake()
    {
        
       
       // rend = GetComponent<Renderer>();
       // rend.enabled = true;
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
       //not nee now: stepRayupper.transform.position = new Vector3(stepRayupper.transform.position.x, stepHeight,stepRayupper.transform.position.z);
    
        SetColor(myColor);
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -bounds, bounds), transform.position.y, transform.position.z);

        if (canMove)

            transform.position += FindObjectOfType<CameraMovement>().camVel;


       /*if (!canMove && gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
        }
        else */if (!canMove && !finish)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<GameManager>().RemoveUI();

               //if needed make true after gameover it will move
               canMove = true;

            }
        }
    }

   void FixedUpdate()
    {
       

        if (canMove)
        {
            if (Input.GetMouseButton(0))
            {

               // check();
              Vector3 vector = lastMousePos -Input.mousePosition;
                 lastMousePos = Input.mousePosition;
               
                vector  = new Vector3(vector.x,vector.y)*speed;
                Vector3 moveForce = Vector3.ClampMagnitude(vector, clampDelta);
                 rb.AddForce( -moveForce * sensitivity - rb.velocity / 5f, ForceMode.VelocityChange);

            }
        }
        // anim.SetBool("jumpattack", false);
        anim.SetBool("Run", canMove);
        rb.velocity.Normalize();

       // Stepclimb();

    }

   void SetColor(Color colorIn)
   {
        myColor = colorIn;
       foreach (var  rend in GetComponentsInChildren<Renderer>(true)){
            rend.material.color = myColor;
        }
        //rend.material.SetColor("_color", myColor);
       // rend.material.color = myColor;
        /*  for (int i=0; i < rend.Length; i++)
          {
              rend[i].material.set
          }
          //rend.material.color = GetColor();*/
    }
 
    private void GameOver()
    {
       // GameObject shatterShpere = Instantiate(breakablePlayer, transform.position, Quaternion.identity);
       // foreach (Transform o in shatterShpere.transform)
      //  {
        //    o.GetComponent<Rigidbody>().AddForce(Vector3.forward * 5, ForceMode.Impulse);
      //  }
        anim.SetBool("death", true);
        FindObjectOfType<AudioManager>().Play("deathsound");
        anim.SetBool("Run", false);
        canMove = false;
        gameOver = true;
       // GetComponent<MeshRenderer>().enabled = false;
      //  GetComponent<Collider>().enabled = false;
        Time.timeScale = .3f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        // GameManager.Instance.OpenLosePanel();
       
    }

    IEnumerator NextLevel()
    {
        finish = true;
       
        yield return new WaitForSeconds(1);
        winpanel.SetActive(true);
        
    }


    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "Enemy")
           
        {
            if(!gameOver) GameOver();
            GameOverpanal.SetActive(true);
        }
        if (target.gameObject.tag == "Respawn")

        {
         //respown true or false 
        }

        if (target.gameObject.tag == "Attack")

        {
             FindObjectOfType<AudioManager>().Play("cheer");
            canMove = false;
            anim.SetBool("jumpattack", true);
            anim.SetBool("Run", false);
        }

    }

    void OnTriggerEnter(Collider target)
    {
      /*  if(target.tag == "Distroy")
        {
          //  Transform otherTransform = target.transform.parent;//these maye be 
            if (myColor == //otherTransform.//GetComponent<particlespalsh>().GetColor()){
              // Game
            }
        }*/

        if(target.gameObject.name == "Finish")
        {
            StartCoroutine(NextLevel());

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ColorWall")
        {
            
             SetColor(other.gameObject.GetComponent<colorWall>().GetColor());  
        }

    }
  

/*    void Stepclimb()
    {
        RaycastHit hitlower;
        if(Physics.Raycast(stepRaylower.transform.position,transform.TransformDirection(Vector3.forward),out hitlower, 0.1f))
        {
            RaycastHit hitupper;
            if (Physics.Raycast(stepRaylower.transform.position, transform.TransformDirection(Vector3.forward), out hitupper, 0.2f))
            {
                rb.position -= new Vector3(0f, -stepSmooth, 0f);
            }
        }
    }*/

}
