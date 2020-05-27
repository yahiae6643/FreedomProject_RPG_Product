using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class pMovement : MonoBehaviour
{

    private float speed = 5;
    private Rigidbody2D myRigidbody2D;
    private Vector3 change;
    private Animator playerAnimator;
    public int steps = 0;
    public int stepsReduced;
    public GameObject EnemyScriptSource;
    private enemyGenerator EnemyScript;

    // Start is called before the first frame update
    void Start()
    {
        stepsReduced = steps/30;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        EnemyScript = EnemyScriptSource.GetComponent<enemyGenerator>();

    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        UpdateDirectionalMovement();




    }

    void UpdateDirectionalMovement()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            playerAnimator.SetFloat("moveX",change.x);
            playerAnimator.SetFloat("moveY",change.y);
            playerAnimator.SetBool("moving",true);

            if(!EnemyScript.inBattle){
                steps++; 
            }
            stepsReduced = steps/30;
            
        } else {
            playerAnimator.SetBool("moving",false);
        }
    }

    void MoveCharacter()
    {
        myRigidbody2D.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    }
}
