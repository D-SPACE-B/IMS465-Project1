using UnityEngine;
using UnityEngine.InputSystem;

public enum Weapon 
{
    Sword,

    Lance,

    Axe
}

public class PlayerUnit : MonoBehaviour
{
    public Weapon activeWeapon;
    private IInteractable currentInteractable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(InputAction.CallbackContext context) 
    {
        if (context.started && currentInteractable != null)
        {
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
