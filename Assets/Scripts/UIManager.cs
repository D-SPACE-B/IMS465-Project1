using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject ArmorSprite;
    [SerializeField] private GameObject BreakText;

    [SerializeField] private GameObject PS;
    [SerializeField] private GameObject PL;
    [SerializeField] private GameObject PA;
    [SerializeField] private GameObject ES;
    [SerializeField] private GameObject EL;
    [SerializeField] private GameObject EA;

    // private float fadeDuration = 2f;

    public PlayerUnit PUnit;
    public EnemyUnit EUnit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!EUnit.armored)
        {
            ArmorSprite.SetActive(false);
        }

        HideBreakText();
        HideWeapons();
        ShowActiveWeapon();
    }

    public void ShowBreakText()
    {
        BreakText.SetActive(true);
        Invoke("HideBreakText", 2.0f);
    }

    void HideBreakText()
    {
        BreakText.SetActive(false);
    }

    void HideWeapons()
    {
        PS.SetActive(false);
        PL.SetActive(false);
        PA.SetActive(false);
        ES.SetActive(false);
        EL.SetActive(false);
        EA.SetActive(false);
    }

    void ShowActiveWeapon()
    {
        if (PUnit.activeWeapon == Weapon.Sword)
        {
            PS.SetActive(true);
        }
        else if (PUnit.activeWeapon == Weapon.Lance)
        {
            PL.SetActive(true);
        }
        else
        {
            PA.SetActive(true);
        }

        if (EUnit.activeWeapon == Weapon.Sword)
        {
            ES.SetActive(true);
        }
        else if (EUnit.activeWeapon == Weapon.Lance)
        {
            EL.SetActive(true);
        }
        else
        {
            EA.SetActive(true);
        }
        
    }

}
