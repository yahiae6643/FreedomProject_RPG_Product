using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class pDetection : MonoBehaviour
{
    public bool playerInRange; // Checks if player object is next to enemy
    private Rigidbody2D myRigidbody2D; // Rigidbody of Player
   
    


    void Start()
    {
        
        myRigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        myRigidbody2D.freezeRotation = true;
       


    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        GameObject other = col.gameObject;

        if (other.CompareTag("Enemy"))
        {
            myRigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll; // Freezes player when making contact with enemy
            playerInRange = true; // Player is next to enemy
            Debug.Log(playerInRange);

            
            


           
        }
    }


    public void OnCollisionExit2D(Collision2D col)
    {

        GameObject other = col.gameObject;

        if (other.CompareTag("Enemy"))
        {
           
            myRigidbody2D.constraints = RigidbodyConstraints2D.None;
            playerInRange = false; // Player is not next to enemy
            Debug.Log(playerInRange);

            


        }
    }
}
