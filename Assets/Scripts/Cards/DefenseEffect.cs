using UnityEngine;

/// <summary>
/// Card effect that grants shield (damage absorption) to the target.
/// Used by: Encryption.
/// </summary>
[CreateAssetMenu(menuName = "Cards/Effects/Defense")]
public class DefenseEffect : CardEffect
{
    [Tooltip("Amount of shield granted.")]
    public int shieldAmount;

    public override void Execute(GameObject target)
    {
        var health = target.GetComponent<Health>();
        if (health != null)
        {
            health.AddShield(shieldAmount);
        }
        else
        {
            Debug.LogWarning($"[DefenseEffect] Target '{target.name}' has no Health component.");
        }
    }
}
