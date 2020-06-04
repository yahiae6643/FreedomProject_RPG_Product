using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy EnemyScript;

    public GameObject Player;

    public GameObject BattleGUI;
    public Image EnemyImage;

    private pMovement playerSteps;

    public bool inBattle;

    public Text enemyType;

   

    void Start()
    {
    	inBattle = false;
    	EnemyScript = GetComponent<Enemy>();
        playerSteps = Player.GetComponent<pMovement>();
        BattleGUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Steps: " + playerSteps.stepsReduced);

        enemyType.text = GetComponent<Enemy>().mType;

        

        if(playerSteps.stepsReduced > 1 && playerSteps.stepsReduced%15 == 0){
            EnemyImage.enabled = true;
        	inBattle = true;
        	playerSteps.steps = 0;
            if(Player.GetComponent<Player>().Level < 5){
                    GetComponent<Enemy>().mType = "Slime";
                    EnemyImage.sprite = EnemyScript.monsterSprites[Random.Range(0,3)];
                    GetComponent<Enemy>().lowerDmg = 2;
                    GetComponent<Enemy>().upperDmg = 5;
                    GetComponent<Enemy>().naturalDmg = Random.Range(GetComponent<Enemy>().lowerDmg, GetComponent<Enemy>().upperDmg);
                    GetComponent<Enemy>().Health = Random.Range(10,15);

                } else if(Player.GetComponent<Player>().Level >= 5 && Player.GetComponent<Player>().Level < 10){
                    EnemyImage.sprite = EnemyScript.monsterSprites[Random.Range(3,6)];
                     GetComponent<Enemy>().mType = "Wolfman";
                     GetComponent<Enemy>().lowerDmg = 6;
                     GetComponent<Enemy>().upperDmg = 9;
                     GetComponent<Enemy>().naturalDmg = Random.Range(GetComponent<Enemy>().lowerDmg, GetComponent<Enemy>().upperDmg);
                     GetComponent<Enemy>().Health = Random.Range(15,20);
                } else {
                    GetComponent<Enemy>().mType = "Brute";
                    EnemyImage.sprite = EnemyScript.monsterSprites[Random.Range(6,9)];
                    GetComponent<Enemy>().lowerDmg = 9;
                    GetComponent<Enemy>().upperDmg = 12;
                    GetComponent<Enemy>().naturalDmg = Random.Range(GetComponent<Enemy>().lowerDmg, GetComponent<Enemy>().upperDmg);
                    GetComponent<Enemy>().Health = Random.Range(20,30);
                }
        	
        	BattleGUI.SetActive(true);
        	Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; 
        } 
    }
}
