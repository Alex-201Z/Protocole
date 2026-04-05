using UnityEngine;

/// <summary>
/// Card effect that modifies the player's available bandwidth (mana) this turn.
/// Used by: Bandwidth Boost.
/// </summary>
[CreateAssetMenu(menuName = "Cards/Effects/Utility")]
public class UtilityEffect : CardEffect
{
    [Tooltip("Extra bandwidth granted to the player this turn.")]
    public int bandwidthBonus;

    public override void Execute(GameObject target)
    {
        var bandwidth = target.GetComponent<BandwidthSystem>();
        if (bandwidth != null)
        {
            bandwidth.AddBandwidth(bandwidthBonus);
        }
        else
        {
            Debug.LogWarning($"[UtilityEffect] Target '{target.name}' has no BandwidthSystem component.");
        }
    }
}
