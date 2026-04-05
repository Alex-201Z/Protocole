using UnityEngine;

/// <summary>
/// Card effect that reduces the target's defense stat.
/// Used by: Backdoor.
/// </summary>
[CreateAssetMenu(menuName = "Cards/Effects/Backdoor")]
public class BackdoorEffect : CardEffect
{
    [Tooltip("Amount by which the target's defense is reduced.")]
    public int defenseReduction;

    public override void Execute(GameObject target)
    {
        var health = target.GetComponent<Health>();
        if (health != null)
        {
            health.ReduceDefense(defenseReduction);
        }
        else
        {
            Debug.LogWarning($"[BackdoorEffect] Target '{target.name}' has no Health component.");
        }
    }
}
