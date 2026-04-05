using UnityEngine;

/// <summary>
/// Card effect that reflects incoming damage back to the attacker for one turn.
/// Used by: Firewall Mirror.
/// </summary>
[CreateAssetMenu(menuName = "Cards/Effects/FirewallMirror")]
public class FirewallMirrorEffect : CardEffect
{
    [Tooltip("Number of turns the reflection lasts.")]
    public int duration;

    public override void Execute(GameObject target)
    {
        var status = target.GetComponent<StatusEffectHandler>();
        if (status != null)
        {
            status.ApplyReflect(duration);
        }
        else
        {
            Debug.LogWarning($"[FirewallMirrorEffect] Target '{target.name}' has no StatusEffectHandler component.");
        }
    }
}
