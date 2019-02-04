using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
    
    

public class PlayerController2 : MonoBehaviour {

    public float speed;
    public Text countText; 
    public Text winText;
    public Text livesText;
    public Text scoreText;

    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;

    void Start ()
    {
       rb = GetComponent<Rigidbody>();

       count = 0;
       score = 0;
       lives = 3;

       SetCountText ();
       winText.text = "";

       livesText.text = "Lives: " + lives.ToString ();
    }


    void FixedUpdate ()
    {
       float moveHorizontal = Input.GetAxis ("Horizontal");
       float moveVertical = Input.GetAxis ("Vertical");
      
       Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

       rb.AddForce (movement * speed);

       if (Input.GetKey("escape"))
             Application.Quit();
     }


     void OnTriggerEnter(Collider other)
     {
	if(other.gameObject==null || gameObject==null)
		return;

         if (other.gameObject.CompareTag("Pick up"))
         {
             other.gameObject.SetActive (false);
             count = count + 1;
             score++;
             SetCountText (); 
         }  

         if(score==12)
         {
            SceneManager.LoadScene(1);
         }

         if (other.gameObject.CompareTag("Enemy"))
         {
             other.gameObject.SetActive (false);
             count = count + 1;
             score--;
             lives--;
	     if(lives==0)
             {
               winText.text = "Game Over";
               //Destroy(GetComponent<Rigidbody>());
               Destroy(other.gameObject); 
               Destroy(gameObject);
             }

             livesText.text = "Lives: " + lives.ToString ();
             SetCountText ();
         
         }  
      }   
      
    void SetCountText ()
    {
        scoreText.text = "Score: " + score.ToString (); 
        countText.text = "Count: " + count.ToString (); 
        if (score >= 8)

        {
           winText.text = "You Win!";
        }
    }
}
