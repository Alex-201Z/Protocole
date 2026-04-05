using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the draw pile and discard pile.
/// Handles drawing cards and reshuffling the discard pile back into the draw pile.
/// </summary>
public class DeckManager : MonoBehaviour
{
    [Tooltip("Cards currently available to be drawn.")]
    public List<CardData> drawPile = new List<CardData>();

    [Tooltip("Cards that have been played or discarded this run.")]
    public List<CardData> discardPile = new List<CardData>();

    /// <summary>
    /// Draws the top card from the draw pile.
    /// Automatically reshuffles the discard pile if the draw pile is empty.
    /// Returns null if both piles are empty.
    /// </summary>
    public CardData DrawCard()
    {
        if (drawPile.Count == 0)
        {
            if (discardPile.Count == 0)
            {
                Debug.LogWarning("[DeckManager] Both draw pile and discard pile are empty.");
                return null;
            }
            Reshuffle();
        }

        CardData card = drawPile[0];
        drawPile.RemoveAt(0);
        return card;
    }

    /// <summary>
    /// Moves a card from the hand to the discard pile.
    /// </summary>
    public void Discard(CardData card)
    {
        discardPile.Add(card);
    }

    /// <summary>
    /// Shuffles the discard pile back into the draw pile.
    /// </summary>
    private void Reshuffle()
    {
        drawPile.AddRange(discardPile);
        discardPile.Clear();
        ShuffleDeck(drawPile);
        Debug.Log("[DeckManager] Reshuffle complete.");
    }

    /// <summary>
    /// Randomises the order of the given list in place (Fisher-Yates shuffle).
    /// Note: Unity's Random.Range(int, int) is exclusive of the upper bound,
    /// so passing 'i + 1' makes the range inclusive of index i.
    /// </summary>
    private void ShuffleDeck(List<CardData> pile)
    {
        for (int i = pile.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (pile[i], pile[j]) = (pile[j], pile[i]);
        }
    }
}
