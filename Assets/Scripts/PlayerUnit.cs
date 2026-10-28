using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public enum Weapon 
{
    Sword,

    Lance,

    Axe
}

public class PlayerUnit : MonoBehaviour
{
    private int PlayerMaxHealth = 30;
    public int CurrentPHealth = 0;
    public Weapon activeWeapon;
    private IInteractable currentInteractable;
    [SerializeField] private TextMeshProUGUI PlayerTextComponent;


    public bool enemyAttcked = false;

    public int Damage = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentPHealth = PlayerMaxHealth;
        PlayerTextComponent.SetText(CurrentPHealth + "/" + PlayerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTextComponent.SetText(CurrentPHealth + "/" + PlayerMaxHealth);
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
    }

    public void Attack(InputAction.CallbackContext context) 
    {
        if (context.started && currentInteractable != null)
        {
            enemyAttcked = true;
            Debug.Log("Attacked");
            currentInteractable.Interact(activeWeapon);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable))
        {
            currentInteractable = interactable;
        }
        
    } 
    void OntriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IInteractable interactable) && currentInteractable == interactable)
        {
            currentInteractable = null;
        }
    }
}
