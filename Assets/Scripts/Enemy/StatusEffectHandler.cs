using UnityEngine;

/// <summary>
/// Handles status effects applied to a combatant:
///   - Stun (skip turn)
///   - Damage Over Time (e.g. Data Leak)
///   - Reflect (return damage to attacker, e.g. Firewall Mirror)
/// Attach alongside a Health component.
/// </summary>
public class StatusEffectHandler : MonoBehaviour
{
    private int _stunTurnsRemaining;
    private int _dotDamagePerTurn;
    private int _dotTurnsRemaining;
    private int _reflectTurnsRemaining;

    /// <summary>True when the entity is stunned and must skip its turn.</summary>
    public bool IsStunned => _stunTurnsRemaining > 0;

    /// <summary>True when the entity will reflect damage back to its attacker.</summary>
    public bool IsReflecting => _reflectTurnsRemaining > 0;

    // ── Status application ────────────────────────────────────────────────────

    /// <summary>Applies a stun effect for the given number of turns.</summary>
    public void ApplyStun(int turns)
    {
        _stunTurnsRemaining = Mathf.Max(_stunTurnsRemaining, turns);
        Debug.Log($"[StatusEffectHandler] {name} stunned for {turns} turn(s).");
    }

    /// <summary>Applies a damage-over-time effect.</summary>
    public void ApplyDamageOverTime(int damagePerTurn, int turns)
    {
        _dotDamagePerTurn = damagePerTurn;
        _dotTurnsRemaining = Mathf.Max(_dotTurnsRemaining, turns);
        Debug.Log($"[StatusEffectHandler] {name} will take {damagePerTurn} DoT for {turns} turn(s).");
    }

    /// <summary>Applies a reflect effect for the given number of turns.</summary>
    public void ApplyReflect(int turns)
    {
        _reflectTurnsRemaining = Mathf.Max(_reflectTurnsRemaining, turns);
        Debug.Log($"[StatusEffectHandler] {name} reflecting damage for {turns} turn(s).");
    }

    // ── Per-turn tick (called by TurnManager at the start of each turn) ───────

    /// <summary>
    /// Ticks all active status effects for the entity.
    /// Call this at the start of the entity's turn.
    /// </summary>
    public void TickEffects()
    {
        // Damage over time
        if (_dotTurnsRemaining > 0)
        {
            var health = GetComponent<Health>();
            health?.TakeDamage(_dotDamagePerTurn);
            _dotTurnsRemaining--;
        }

        // Decrement stun
        if (_stunTurnsRemaining > 0)
            _stunTurnsRemaining--;

        // Decrement reflect
        if (_reflectTurnsRemaining > 0)
            _reflectTurnsRemaining--;
    }
}
