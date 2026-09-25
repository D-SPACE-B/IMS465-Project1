using UnityEngine;

public class EnemyUnit : MonoBehaviour, IInteractable
{
    public Weapon activeWeapon;
    private bool broken = false;
    [SerializeField] private bool armored = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
