using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	private int Health;
	private int goldDrop;
	private int expDrop;
	public Sprite[] monsterSprites;
	public GameObject BattleGUI;
	public Button Attack;
	public Button Flee;
	public Text healthDisplay;
	public GameObject Player;




// 
    // Start is called before the first frame update
    void Start()
    {
    	// GetComponent<enemyGenerator>().inBattle = false;

        Health = Random.Range(10,15);
        goldDrop = Random.Range(3,8);
        expDrop = Random.Range(1,9);
        Attack.onClick.AddListener(AttackEnemyHealth);
    	Flee.onClick.AddListener(ExitBattle);
    	healthDisplay.text = "HP: " + Health;
    }

    // Update is called once per frame
    void Update()
    {
    	
        if(Health <= 0){
        	GetComponent<enemyGenerator>().inBattle = false;
        	BattleGUI.SetActive(false);
        	Health = Random.Range(10,15);
        	healthDisplay.text = "HP: " + Health;
        	Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        }
    }

    void AttackEnemyHealth(){
    	Health-=Random.Range(1,5);
    	healthDisplay.text = "HP: " + Health;
    	Debug.Log(Health);
    }

    void ExitBattle(){
    	GetComponent<enemyGenerator>().inBattle = false;
    	BattleGUI.SetActive(false);
    	Health = Random.Range(10,15);
    	healthDisplay.text = "HP: " + Health;
    	Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }
}
