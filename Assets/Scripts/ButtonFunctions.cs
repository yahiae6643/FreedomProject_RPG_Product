using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{

    public Button Attack;
    public Button Flee;
    public Button Heal;
    public GameObject Player;
    public GameObject Enemy;
    private Enemy EnemyStats;
    private Player PlayerStats;
    public GameObject BattleGUI;
    public Text battleInfo;




    // Start is called before the first frame update
    void Start()
    {
        battleInfo.text = "Command?";
        PlayerStats = Player.GetComponent<Player>();
        EnemyStats = Enemy.GetComponent<Enemy>();


        Attack.onClick.AddListener(AttackEnemyHealth);
        Flee.onClick.AddListener(ExitBattle);
        Heal.onClick.AddListener(HealHealth);

        // BattleGUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(EnemyStats.Health <= 0)
        {
            Attack.interactable = true;
            Flee.interactable = true;
            Heal.interactable = true;
        }

    }






    void AttackEnemyHealth()
    {

        StartCoroutine(ButtonDelay());

        EnemyStats.Health -= PlayerStats.weaponDmg;
        battleInfo.text = "You Have Dealt " + PlayerStats.weaponDmg + " DMG";
        PlayerStats.weaponDmg = Random.Range(PlayerStats.lowerDmg, PlayerStats.upperDmg);
        StartCoroutine(FlashEnemy());


        StartCoroutine(AttackDelay(2));



    }

    void HealHealth()
    {
        if(PlayerStats.Mana >= 5 && PlayerStats.Health < PlayerStats.HealthCap)
        {

            StartCoroutine(ButtonDelay());
            int HH = (int) Random.Range(1, 5);
            PlayerStats.Health += HH;
            battleInfo.text = "You Have Heal " + HH + " HP";
            if(PlayerStats.Health > PlayerStats.HealthCap)
            {
                PlayerStats.Health = PlayerStats.HealthCap;
            }
            PlayerStats.Mana -= 5;

            StartCoroutine(AttackDelay(2));
        }









    }

    private IEnumerator FlashEnemy()
    {
        Enemy.GetComponent<enemyGenerator>().EnemyImage.enabled = false;
        yield return new WaitForSeconds(0.1F);
        Enemy.GetComponent<enemyGenerator>().EnemyImage.enabled = true;
        yield return new WaitForSeconds(0.1F);
        Enemy.GetComponent<enemyGenerator>().EnemyImage.enabled = false;
        yield return new WaitForSeconds(0.1F);
        Enemy.GetComponent<enemyGenerator>().EnemyImage.enabled = true;
    }

    private IEnumerator AttackDelay(int seconds)
    {
        yield return new WaitForSeconds(seconds);

        PlayerStats.Health -= EnemyStats.naturalDmg;
        battleInfo.text = "Enemy Has Dealt " + EnemyStats.naturalDmg + " DMG";
        if(EnemyStats.mType == "Slime")
        {
            EnemyStats.lowerDmg = 2;
            EnemyStats.upperDmg = 5;
            EnemyStats.naturalDmg = Random.Range(EnemyStats.lowerDmg,EnemyStats.upperDmg);

        }
        else if(EnemyStats.mType == "Wolfman")
        {
            EnemyStats.lowerDmg = 6;
            EnemyStats.upperDmg = 9;
            EnemyStats.naturalDmg = Random.Range(EnemyStats.lowerDmg,EnemyStats.upperDmg);
        }
        else
        {
            EnemyStats.lowerDmg = 9;
            EnemyStats.upperDmg = 12;
            EnemyStats.naturalDmg = Random.Range(EnemyStats.lowerDmg,EnemyStats.upperDmg);
        }

        yield return new WaitForSeconds(2);


    }



    private IEnumerator ButtonDelay()
    {
        Attack.interactable = false;
        Flee.interactable = false;
        Heal.interactable = false;

        yield return new WaitForSeconds(5);

        Attack.interactable = true;
        Flee.interactable = true;
        Heal.interactable = true;
    }



    void ExitBattle()
    {

        Enemy.GetComponent<enemyGenerator>().inBattle = false;
        BattleGUI.SetActive(false);

        if(EnemyStats.mType == "Slime")
        {
            EnemyStats.Health = Random.Range(10, 15);
        }
        else if(EnemyStats.mType == "Wolfman")
        {
            EnemyStats.Health = Random.Range(15, 20);
        }
        else
        {
            EnemyStats.Health = Random.Range(20, 30);
        }

        Player.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        Player.GetComponent<Rigidbody2D>().constraints &= ~RigidbodyConstraints2D.FreezePositionY;

        battleInfo.text = "Command?";
    }
}
