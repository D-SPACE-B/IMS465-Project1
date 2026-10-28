using UnityEngine;
using System.Collections;
using TMPro;

public class EnemyUnit : MonoBehaviour, IInteractable
{
    private int EnemyMaxHealth = 24;
    public int CurrentEHealth = 0;
    public Weapon activeWeapon;
    private bool broken = false;

    public bool PlayerAttackOver = false;

    public PlayerUnit Player;
    [SerializeField] private bool armored = false;
    [SerializeField] private TextMeshProUGUI EnemyTextComponent;

    public int Damage = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentEHealth = EnemyMaxHealth;
        EnemyTextComponent.SetText(CurrentEHealth + "/" + EnemyMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (activeWeapon == Weapon.Sword)
        {
            Damage = 5;
        }
        else if (activeWeapon == Weapon.Lance)
        {
            Damage = 6;
        }
        else
        {
            Damage = 7;
        }
        EnemyTextComponent.SetText(CurrentEHealth + "/" + EnemyMaxHealth);
        HealthChange();

        
        
    }

    public void Interact(Weapon weaponType) 
    {
        Debug.Log("Enemy Attacked");

        if (CheckBreak(weaponType)) 
        {
            broken = true;
            Debug.Log("Enemy Broken");
        }
        else 
        {
            Debug.Log("Enemy Not Broken");
            StartCoroutine(EnemyTurn());
            //AttackPlayer();
            
        }
    }

    private bool CheckBreak(Weapon weaponType)
    {
        if (!armored)
        {
        if (weaponType == Weapon.Axe)
        {
            if (activeWeapon == Weapon.Lance) 
            {
                return true;
            }
        }
        else if (weaponType == Weapon.Lance)
        {
            if (activeWeapon == Weapon.Sword)
            {
                return true;
            }
        }
        else if (weaponType == Weapon.Sword)
        {
            if (activeWeapon == Weapon.Axe)
            {
                return true;
            }
        }
                return false;
        }

        return false;


    }

    private void HealthChange()
    {
        if (Player.enemyAttcked)
        {
            CurrentEHealth -= Player.Damage;
            Player.enemyAttcked = false;
            PlayerAttackOver = true;
        }
    }


    IEnumerator EnemyTurn()
    {
        Debug.Log("My turn");
        yield return new WaitForSeconds(2f);
        AttackPlayer();

    }
    

    private void AttackPlayer()
    {
        if (PlayerAttackOver)
        {
            Debug.Log("Player Attacked");
            Player.CurrentPHealth -= Damage;
            PlayerAttackOver = false;

        }
    }
    
}
