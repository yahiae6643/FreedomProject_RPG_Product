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

        if(playerSteps.stepsReduced > 1 && playerSteps.stepsReduced%15 == 0){
        	inBattle = true;
        	playerSteps.steps = 0;
        	EnemyImage.sprite = EnemyScript.monsterSprites[Random.Range(0,EnemyScript.monsterSprites.Length)];
        	BattleGUI.SetActive(true);
        	Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; 
        } 
    }
}
