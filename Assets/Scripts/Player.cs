using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Health;
    public int HealthCap;
    public int Gold;
    public int Exp;
    public int Level;
    public int Mana;
    public int[] expRequired;

    public Text playerHealth;
    public Text playerGold;
    public Text playerExp;
    public Text playerLevel;
    public Text playerMana;


    public GameObject ShopGUI;

    public int weaponDmg;
    public int lowerDmg;
    public int upperDmg;

    public GameObject Enemy;
    public GameObject dScreen;

    // Start is called before the first frame update
    void Start()
    {
        expRequired = new int[10];

        Level = 0;
        HealthCap = Health = 20;
        Mana = 20;
        Gold = 0;
        Exp = 0;
        lowerDmg = 1;
        upperDmg = 5;
        weaponDmg = Random.Range(lowerDmg,upperDmg);
        ShopGUI.SetActive(false);

        for(int i = 0; i < expRequired.Length; i++){
        	expRequired[i] = (int) Mathf.Pow(2,i);
        }
        dScreen.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    	if(Health <= 0){
    		// Destroy(gameObject);
    		dScreen.SetActive(true);
    	}



        playerHealth.text = "HP: " + Health;
        playerMana.text = "MP: " + Mana;
        playerGold.text = "GOLD: " + Gold;
        playerExp.text = "EXP: " + Exp;
        playerLevel.text = "LVL: " + Level;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ShopKeeper" && !Enemy.GetComponent<enemyGenerator>().inBattle)
        {
        	ShopGUI.SetActive(true);
            Debug.Log("In Range");
            this.GetComponent<pMovement>().steps = 0;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "ShopKeeper" && !Enemy.GetComponent<enemyGenerator>().inBattle)
        {
        	ShopGUI.SetActive(false);
            Debug.Log("Not In Range");
        }
    }
}
