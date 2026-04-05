using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages the player's bandwidth (mana) pool.
/// Bandwidth is reset at the start of each player turn.
/// </summary>
public class BandwidthSystem : MonoBehaviour
{
    [Tooltip("Maximum bandwidth available each turn.")]
    public int maxBandwidth = 3;

    /// <summary>Bandwidth remaining this turn.</summary>
    public int CurrentBandwidth { get; private set; }

    /// <summary>Fired whenever bandwidth changes so the UI can update.</summary>
    public UnityEvent onBandwidthChanged;

    /// <summary>
    /// Resets bandwidth to the maximum at the start of a player turn.
    /// </summary>
    public void ResetBandwidth()
    {
        CurrentBandwidth = maxBandwidth;
        onBandwidthChanged.Invoke();
    }

    /// <summary>
    /// Tries to spend the given amount of bandwidth.
    /// Returns true if there was enough bandwidth; false otherwise.
    /// </summary>
    public bool SpendBandwidth(int amount)
    {
        if (amount > CurrentBandwidth)
        {
            Debug.Log("[BandwidthSystem] Not enough bandwidth.");
            return false;
        }

        CurrentBandwidth -= amount;
        onBandwidthChanged.Invoke();
        return true;
    }

    /// <summary>
    /// Adds extra bandwidth (e.g. from Bandwidth Boost card).
    /// Does not exceed maxBandwidth.
    /// </summary>
    public void AddBandwidth(int amount)
    {
        CurrentBandwidth = Mathf.Min(CurrentBandwidth + amount, maxBandwidth);
        onBandwidthChanged.Invoke();
    }
}
