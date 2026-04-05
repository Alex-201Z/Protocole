using UnityEngine;

/// <summary>
/// Card effect that applies a status (stun or damage-over-time) to the target.
/// Used by: System Freeze (stun), Data Leak (damage over time).
/// </summary>
[CreateAssetMenu(menuName = "Cards/Effects/Control")]
public class ControlEffect : CardEffect
{
    public enum ControlType { Stun, DamageOverTime }

    [Tooltip("Type of control effect to apply.")]
    public ControlType controlType;

    [Tooltip("Number of turns the effect lasts.")]
    public int duration;

    [Tooltip("Damage per turn (only used when controlType is DamageOverTime).")]
    public int damagePerTurn;

    public override void Execute(GameObject target)
    {
        var status = target.GetComponent<StatusEffectHandler>();
        if (status == null)
        {
            Debug.LogWarning($"[ControlEffect] Target '{target.name}' has no StatusEffectHandler component.");
            return;
        }

        switch (controlType)
        {
            case ControlType.Stun:
                // System Freeze: skip the enemy's next turn
                status.ApplyStun(duration);
                break;
            case ControlType.DamageOverTime:
                // Data Leak: deal damage at the start of each enemy turn
                status.ApplyDamageOverTime(damagePerTurn, duration);
                break;
        }
    }
}
