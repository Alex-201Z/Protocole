using UnityEngine;
using System.Collections;

/// <summary>
/// Represents the player during combat.
/// Handles starting the player's turn, playing cards, and ending the turn.
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public HandManager handManager;
    public BandwidthSystem bandwidthSystem;
    public TurnManager turnManager;

    [Tooltip("Number of cards drawn at the start of each turn.")]
    public int cardsDrawnPerTurn = 5;

    /// <summary>True while the player is taking their turn.</summary>
    public bool IsPlayerTurn { get; private set; }

    /// <summary>
    /// Coroutine for a full player turn.
    /// Starts the turn, waits for the player to end it, then cleans up.
    /// </summary>
    public IEnumerator PlayTurn()
    {
        StartTurn();

        // Wait until the UI calls EndTurn(), which sets IsPlayerTurn = false
        yield return new WaitUntil(() => !IsPlayerTurn);
    }

    /// <summary>
    /// Initialises the player turn: reset bandwidth and draw cards.
    /// </summary>
    private void StartTurn()
    {
        IsPlayerTurn = true;
        bandwidthSystem.ResetBandwidth();
        handManager.DrawCards(cardsDrawnPerTurn);
        Debug.Log("[PlayerController] Player turn started.");
    }

    /// <summary>
    /// Called by UI when the player presses "End Turn".
    /// </summary>
    public void EndTurn()
    {
        if (!IsPlayerTurn) return;

        IsPlayerTurn = false;
        handManager.DiscardHand();
        Debug.Log("[PlayerController] Player turn ended.");
    }

    /// <summary>
    /// Plays a card from the hand against the target.
    /// Spends the card's bandwidth cost and executes its effect.
    /// </summary>
    public void PlayCard(CardData card, GameObject target)
    {
        if (!IsPlayerTurn)
        {
            Debug.LogWarning("[PlayerController] Cannot play cards outside of player turn.");
            return;
        }

        if (!bandwidthSystem.SpendBandwidth(card.cost)) return;

        card.effect.Execute(target);
        handManager.DiscardCard(card);
    }
}
