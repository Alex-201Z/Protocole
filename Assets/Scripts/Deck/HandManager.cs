using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Manages the player's current hand of cards.
/// Draws cards from DeckManager and exposes events so the UI can react.
/// </summary>
public class HandManager : MonoBehaviour
{
    [Tooltip("Maximum number of cards the player can hold.")]
    public int maxHandSize = 5;

    /// <summary>Cards currently in the player's hand.</summary>
    public List<CardData> hand = new List<CardData>();

    /// <summary>Fired whenever the hand changes (draw or discard).</summary>
    public UnityEvent onHandChanged;

    private DeckManager _deck;

    private void Awake()
    {
        _deck = GetComponent<DeckManager>();
        if (_deck == null)
            Debug.LogError("[HandManager] DeckManager not found on the same GameObject.");
    }

    /// <summary>
    /// Draws the specified number of cards from the deck into the hand,
    /// up to maxHandSize.
    /// </summary>
    public void DrawCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (hand.Count >= maxHandSize)
            {
                Debug.Log("[HandManager] Hand is full.");
                break;
            }

            CardData card = _deck.DrawCard();
            if (card == null) break;

            hand.Add(card);
        }

        onHandChanged.Invoke();
    }

    /// <summary>
    /// Removes a card from the hand and sends it to the discard pile.
    /// </summary>
    public void DiscardCard(CardData card)
    {
        if (hand.Remove(card))
        {
            _deck.Discard(card);
            onHandChanged.Invoke();
        }
    }

    /// <summary>
    /// Discards all cards currently in hand.
    /// Called at the end of the player's turn.
    /// </summary>
    public void DiscardHand()
    {
        foreach (CardData card in hand)
            _deck.Discard(card);

        hand.Clear();
        onHandChanged.Invoke();
    }
}
