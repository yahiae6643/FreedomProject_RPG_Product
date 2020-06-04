using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;

    public Button woodBuy;
    public Button ironBuy;
    public Button grassBuy;
    public Button demonBuy;

    public bool haveWood;
    public bool haveIron;
    public bool haveGrass;
    public bool haveDemon;

    public Text wT;
    public Text iT;
    public Text gT;
    public Text dT;

    void Start()
    {
    	haveWood = haveIron = haveGrass = haveDemon = false;
        woodBuy.onClick.AddListener(wBuy);
        ironBuy.onClick.AddListener(iBuy);
        grassBuy.onClick.AddListener(gBuy);
        demonBuy.onClick.AddListener(dBuy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void wBuy(){
    	if(Player.GetComponent<Player>().Gold >= 10 && !haveWood){
    		Player.GetComponent<Player>().Gold-=10;
    		Player.GetComponent<Player>().lowerDmg = 3;
    		Player.GetComponent<Player>().upperDmg = 7;
    		Player.GetComponent<Player>().weaponDmg = Random.Range(Player.GetComponent<Player>().lowerDmg,Player.GetComponent<Player>().upperDmg);
    		haveWood = true;
    	} else if(haveWood){
    		Player.GetComponent<Player>().Gold+=10;
    		Player.GetComponent<Player>().lowerDmg = 1;
    		Player.GetComponent<Player>().upperDmg = 5;
    		Player.GetComponent<Player>().weaponDmg = Random.Range(Player.GetComponent<Player>().lowerDmg,Player.GetComponent<Player>().upperDmg);
    		haveWood = false;
    		wT.text = "Sold!";
    	} else {
    		wT.text = "No";
    	}
    }

    void iBuy(){
    	if(Player.GetComponent<Player>().Gold >= 30 && !haveIron){
    		Player.GetComponent<Player>().Gold-=30;
    		Player.GetComponent<Player>().lowerDmg = 7;
    		Player.GetComponent<Player>().upperDmg = 12;
    		Player.GetComponent<Player>().weaponDmg = Random.Range(Player.GetComponent<Player>().lowerDmg,Player.GetComponent<Player>().upperDmg);
    		haveIron = true;
    	} else if(haveIron){
    		Player.GetComponent<Player>().Gold+=30;
    		Player.GetComponent<Player>().lowerDmg = 1;
    		Player.GetComponent<Player>().upperDmg = 5;
    		Player.GetComponent<Player>().weaponDmg = Random.Range(Player.GetComponent<Player>().lowerDmg,Player.GetComponent<Player>().upperDmg);
    		haveIron = false;
    		iT.text = "Sold!";
    		
    	} else {
    		iT.text = "No";
    	}
    }

    void gBuy(){
    	if(Player.GetComponent<Player>().Gold >= 50 && !haveGrass){
    		Player.GetComponent<Player>().Gold-=50;
    		Player.GetComponent<Player>().lowerDmg = 12;
    		Player.GetComponent<Player>().upperDmg = 15;
    		Player.GetComponent<Player>().weaponDmg = Random.Range(Player.GetComponent<Player>().lowerDmg,Player.GetComponent<Player>().upperDmg);
    		haveGrass = true;
    	} else if(haveGrass){
    		Player.GetComponent<Player>().Gold+=50;
    		Player.GetComponent<Player>().lowerDmg = 1;
    		Player.GetComponent<Player>().upperDmg = 5;
    		Player.GetComponent<Player>().weaponDmg = Random.Range(Player.GetComponent<Player>().lowerDmg,Player.GetComponent<Player>().upperDmg);
    		haveGrass = false;
    		gT.text = "Sold!";
    	} else {
    		gT.text = "No";
    	}
    }

    void dBuy(){
    	if(Player.GetComponent<Player>().Gold >= 120 && !haveDemon){
    		Player.GetComponent<Player>().Gold-=120;
    		Player.GetComponent<Player>().lowerDmg = 15;
    		Player.GetComponent<Player>().upperDmg = 30;
    		Player.GetComponent<Player>().weaponDmg = Random.Range(Player.GetComponent<Player>().lowerDmg,Player.GetComponent<Player>().upperDmg);
    		haveDemon = true;
    	} else if(haveDemon){
    		Player.GetComponent<Player>().Gold+=120;
    		Player.GetComponent<Player>().lowerDmg = 1;
    		Player.GetComponent<Player>().upperDmg = 5;
    		Player.GetComponent<Player>().weaponDmg = Random.Range(Player.GetComponent<Player>().lowerDmg,Player.GetComponent<Player>().upperDmg);
    		haveDemon = false;
    		dT.text = "Sold!";
    	} else {
    		dT.text = "No";
    	}
    }
}
