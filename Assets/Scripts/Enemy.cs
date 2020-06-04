using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int Health;

    public int goldDrop;
    public int expDrop;
    public Sprite[] monsterSprites;
    public GameObject BattleGUI;

    public GameObject winScreen;
    public Text goldText;
    public Text expText;
    public Text newLvl;

    public Text healthDisplay;
    public GameObject Player;
    private Player PlayerStats;
    public Text battleInfo;
    public int naturalDmg;
    public int upperDmg;
    public int lowerDmg;

    public Button Attack;
    public Button Flee;
    public string mType;




    //
    // Start is called before the first frame update
    void Start()
    {


        lowerDmg = 2;
        upperDmg = 5;
        naturalDmg = Random.Range(lowerDmg, upperDmg);
        PlayerStats = Player.GetComponent<Player>();
        mType = "Slime";
        Health = Random.Range(10, 15);
        goldDrop = Random.Range(3, 8);
        expDrop = Random.Range(1, 5);
        healthDisplay.text = "HP: " + Health;
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "HP: " + Health;

        if(Health <= 0)
        {
            Attack.interactable = false;
            Flee.interactable = false;

            if(mType == "Slime")
            {
                Health = Random.Range(10, 15);

                goldDrop = Random.Range(3, 8);
                expDrop = Random.Range(1, 5);

                PlayerStats.Exp += expDrop;
                PlayerStats.Gold += goldDrop;


                goldText.text = "Earned " + goldDrop + " Gold";
                expText.text = "Earned " + expDrop + " Exp";
            }
            else if(mType == "Wolfman")
            {
                Health = Random.Range(15, 20);

                goldDrop = Random.Range(8, 12);
                expDrop = Random.Range(3, 6);

                PlayerStats.Exp += expDrop;
                PlayerStats.Gold += goldDrop;

                goldText.text = "Earned " + goldDrop + " Gold";
                expText.text = "Earned " + expDrop + " Exp";


            }
            else
            {
                Health = Random.Range(20, 30);

                goldDrop = Random.Range(12, 24);
                expDrop = Random.Range(6, 12);

                PlayerStats.Exp += expDrop;
                PlayerStats.Gold += goldDrop;

                goldText.text = "Earned " + goldDrop + " Gold";
                expText.text = "Earned " + expDrop + " Exp";


            }

            GetComponent<enemyGenerator>().inBattle = false;





            BattleGUI.SetActive(false);

            Player.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            Player.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionY;

            battleInfo.text = "Command?";


            // newLvl.text = "You are Lvl " + PlayerStats.Level;

            StartCoroutine(DisplayRewardScreen());



            Attack.interactable = true;
            Flee.interactable = true;





            for(int i = 0; i < PlayerStats.expRequired.Length; i++)
            {
                if(PlayerStats.Exp >= PlayerStats.expRequired[i])
                {
                    PlayerStats.Level = i + 1;
                    PlayerStats.Health = PlayerStats.HealthCap = 20 + i * 5;
                    PlayerStats.Mana = 20 + i * 5;
                    newLvl.text = "You are Lvl " + PlayerStats.Level;

                }

            }

        }
    }

    private IEnumerator DisplayRewardScreen()
    {

        winScreen.SetActive(true);

        yield return new WaitForSeconds(4);

        winScreen.SetActive(false);

        Attack.interactable = true;
        Flee.interactable = true;



    }

}
