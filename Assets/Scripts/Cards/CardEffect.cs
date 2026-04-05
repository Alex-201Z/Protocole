using UnityEngine;

/// <summary>
/// Abstract base class for all card effects.
/// Each concrete effect is a ScriptableObject asset that can be shared across cards.
/// To add a new card type, create a new class that inherits from CardEffect.
/// </summary>
public abstract class CardEffect : ScriptableObject
{
    /// <summary>
    /// Executes the card effect on the given target GameObject.
    /// </summary>
    /// <param name="target">The GameObject affected by this card (e.g. an enemy or the player).</param>
    public abstract void Execute(GameObject target);
}
