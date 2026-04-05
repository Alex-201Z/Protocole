using UnityEngine;
using System.Collections;

/// <summary>
/// Simple MVP enemy AI. Each turn the enemy performs one attack.
/// Checks for stun and damage-over-time via StatusEffectHandler before acting.
///
/// Enemy types in the MVP:
///   - Firewall  (low attack, high defense)
///   - Scanner   (moderate attack, applies debuffs)
///   - Guardian  (high attack, high HP)
/// The differences are driven by data (HP, attackDamage) on the same script.
/// </summary>
public class EnemyAI : MonoBehaviour
{
    [Header("Stats")]
    [Tooltip("Damage dealt to the player each turn.")]
    public int attackDamage = 5;

    [Header("References")]
    [Tooltip("The player's Health component.")]
    public Health playerHealth;

    private StatusEffectHandler _status;

    private void Awake()
    {
        _status = GetComponent<StatusEffectHandler>();
    }

    /// <summary>
    /// Coroutine for a full enemy turn.
    /// Ticks status effects, skips if stunned, then attacks.
    /// </summary>
    public IEnumerator PlayTurn()
    {
        // Tick status effects (DoT damage, decrement stun/reflect)
        _status?.TickEffects();

        if (_status != null && _status.IsStunned)
        {
            Debug.Log($"[EnemyAI] {name} is stunned — skipping turn.");
            yield break;
        }

        PerformAttack();

        // Small delay so the attack feels intentional in the UI
        yield return new WaitForSeconds(0.5f);
    }

    /// <summary>
    /// Deals attackDamage to the player.
    /// Handles reflect: if the player is reflecting, damage hits the enemy instead.
    /// </summary>
    private void PerformAttack()
    {
        var playerStatus = playerHealth.GetComponent<StatusEffectHandler>();
        if (playerStatus != null && playerStatus.IsReflecting)
        {
            Debug.Log($"[EnemyAI] {name}'s attack was reflected!");
            GetComponent<Health>()?.TakeDamage(attackDamage);
        }
        else
        {
            playerHealth.TakeDamage(attackDamage);
            Debug.Log($"[EnemyAI] {name} attacked player for {attackDamage} damage.");
        }
    }
}
