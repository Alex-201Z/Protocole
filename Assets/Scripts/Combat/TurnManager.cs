using UnityEngine;
using System.Collections;

/// <summary>
/// Drives the combat loop: Player Turn → Enemy Turn → repeat.
/// Attach to a Combat scene manager GameObject.
/// </summary>
public class TurnManager : MonoBehaviour
{
    [Header("References")]
    public PlayerController playerController;
    public EnemyAI enemyAI;

    /// <summary>True while a combat encounter is in progress.</summary>
    public bool CombatActive { get; private set; }

    private void Start()
    {
        StartCombat();
    }

    /// <summary>
    /// Begins a new combat encounter.
    /// </summary>
    public void StartCombat()
    {
        CombatActive = true;
        StartCoroutine(CombatLoop());
    }

    /// <summary>
    /// Ends the current combat encounter (called when the enemy is defeated).
    /// </summary>
    public void EndCombat()
    {
        CombatActive = false;
        Debug.Log("[TurnManager] Combat ended.");
    }

    /// <summary>
    /// Main combat loop. Runs player and enemy turns until combat ends.
    /// </summary>
    private IEnumerator CombatLoop()
    {
        while (CombatActive)
        {
            // --- Player turn ---
            yield return StartCoroutine(playerController.PlayTurn());

            if (!CombatActive) break;

            // --- Enemy turn ---
            yield return StartCoroutine(enemyAI.PlayTurn());
        }
    }
}
