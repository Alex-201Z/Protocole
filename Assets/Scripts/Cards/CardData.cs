using UnityEngine;

/// <summary>
/// Stores all static data for a single card.
/// Create card assets via Assets > Cards > Card Data in the Unity editor.
/// Adding a new card never requires new code — just create a new asset.
/// </summary>
[CreateAssetMenu(menuName = "Cards/Card Data")]
public class CardData : ScriptableObject
{
    [Tooltip("Display name shown to the player.")]
    public string cardName;

    [Tooltip("Bandwidth (mana) cost to play this card.")]
    public int cost;

    [Tooltip("The effect executed when this card is played.")]
    public CardEffect effect;
}
