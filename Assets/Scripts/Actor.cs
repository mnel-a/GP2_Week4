using System.Diagnostics; 
using UnityEngine;


// PUBLIC, PRIVATE, PROTECTED
// Public = anyone can edit
// Private =  only you can edit
// Protected = Parent and derived child 

// VIRTUAL vs ABSTRACT vs OVERRIDE
// Virtual = default rules with room to personalize
// Abstract =  mandatory blank canvas / 
//      every game object has a rule action ex. abstract.move() /
//      prevents anyone from accidentaly attaching script to any game object
// Override = called using method name / 

// CANT BE ATTACHED TO ANY GAME OBJECT
public abstract class Actor : MonoBehaviour
{
    // Protected instead of Private:
    // keeps the maxhealth hiddden from unrelated outside script
    // allows child classes to read and adjust
    [Header("Base Actor Atributes")]
    [SerializeField] protected float maxHealth = 100f;
    protected float currentHealth;
    [SerializeField] protected float moveSpeed = 3;

    // Awake marked as virtual:
    // ensures child classes can initialize their own variable in their own awake
    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    // Every enemy attacks is different, we declare this method as abstract
    public abstract void PerformAttack();
    
    // Unlike attack we make it as virtual so child classes can use standard health suctraction formula
    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth -= maxHealth;
        UnityEngine.Debug.Log($"{gameObject.name} took {damageAmount} damage");
    }

    protected virtual void Die()
    {
        UnityEngine.Debug.Log($"{gameObject.name} has died");
        Destroy(gameObject);
    }

}
