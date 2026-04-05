using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Tracks hit points and shield for any combatant (player or enemy).
/// Fires events so the UI can react without direct coupling.
/// </summary>
public class Health : MonoBehaviour
{
    [Tooltip("Maximum hit points.")]
    public int maxHP = 30;

    /// <summary>Current hit points.</summary>
    public int CurrentHP { get; private set; }

    /// <summary>Current shield value (absorbed before HP).</summary>
    public int CurrentShield { get; private set; }

    /// <summary>Current defense reduction applied to incoming damage.</summary>
    public int Defense { get; private set; }

    /// <summary>Fired when HP or shield changes.</summary>
    public UnityEvent onHealthChanged;

    /// <summary>Fired when the entity reaches 0 HP.</summary>
    public UnityEvent onDeath;

    private void Awake()
    {
        CurrentHP = maxHP;
    }

    /// <summary>
    /// Applies damage, absorbing shield first, then HP.
    /// Defense reduces the incoming damage.
    /// </summary>
    public void TakeDamage(int amount)
    {
        int effective = Mathf.Max(0, amount - Defense);

        if (CurrentShield > 0)
        {
            int absorbed = Mathf.Min(CurrentShield, effective);
            CurrentShield -= absorbed;
            effective -= absorbed;
        }

        CurrentHP -= effective;
        CurrentHP = Mathf.Max(CurrentHP, 0);
        onHealthChanged.Invoke();

        if (CurrentHP <= 0)
            onDeath.Invoke();
    }

    /// <summary>
    /// Adds shield to the entity (does not exceed maxHP equivalent).
    /// </summary>
    public void AddShield(int amount)
    {
        CurrentShield += amount;
        onHealthChanged.Invoke();
    }

    /// <summary>
    /// Reduces the entity's defense by the given amount (minimum 0).
    /// </summary>
    public void ReduceDefense(int amount)
    {
        Defense = Mathf.Max(0, Defense - amount);
        onHealthChanged.Invoke();
    }
}
