using UnityEngine;

/// <summary>
/// Card effect that deals direct damage to the target.
/// Used by: Ping Attack, Packet Burst, Virus Injection.
/// </summary>
[CreateAssetMenu(menuName = "Cards/Effects/Attack")]
public class AttackEffect : CardEffect
{
    [Tooltip("Amount of damage dealt to the target.")]
    public int damage;

    public override void Execute(GameObject target)
    {
        var health = target.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
        else
        {
            Debug.LogWarning($"[AttackEffect] Target '{target.name}' has no Health component.");
        }
    }
}
