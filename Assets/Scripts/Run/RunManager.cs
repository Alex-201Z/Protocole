using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Manages the structure of a run:
///   Combat → Reward → Combat → Reward → Boss
///
/// Sequence:
///   1. StartRun()
///   2. Repeat: StartCombat() → WaitForCombatEnd() → GiveReward()
///   3. StartBoss()
/// </summary>
public class RunManager : MonoBehaviour
{
    [Header("Run Configuration")]
    [Tooltip("Number of normal combats before the boss.")]
    public int combatCount = 5;

    [Header("Card Rewards")]
    [Tooltip("Pool of cards that can be offered as rewards.")]
    public List<CardData> rewardPool;

    [Tooltip("Number of cards offered as a reward after each combat.")]
    public int rewardChoices = 3;

    [Header("References")]
    public TurnManager turnManager;
    public DeckManager deckManager;

    private int _currentCombat;

    private void Start()
    {
        StartRun();
    }

    /// <summary>
    /// Starts a new run from the beginning.
    /// </summary>
    public void StartRun()
    {
        _currentCombat = 0;
        Debug.Log("[RunManager] Run started.");
        StartCoroutine(RunSequence());
    }

    /// <summary>
    /// Drives the run: normal combats followed by the boss.
    /// </summary>
    private IEnumerator RunSequence()
    {
        while (_currentCombat < combatCount)
        {
            _currentCombat++;
            Debug.Log($"[RunManager] Starting combat {_currentCombat} of {combatCount}.");

            yield return StartCoroutine(StartCombat());
            yield return StartCoroutine(GiveReward());
        }

        yield return StartCoroutine(StartBoss());
    }

    /// <summary>
    /// Starts a combat encounter and waits for it to finish.
    /// </summary>
    private IEnumerator StartCombat()
    {
        turnManager.StartCombat();
        yield return new WaitUntil(() => !turnManager.CombatActive);
        Debug.Log("[RunManager] Combat complete.");
    }

    /// <summary>
    /// Presents card reward choices to the player.
    /// In the MVP the reward is logged; hook this up to the UI system later.
    /// </summary>
    private IEnumerator GiveReward()
    {
        List<CardData> offered = GetRewardChoices();
        Debug.Log($"[RunManager] Reward offered: {string.Join(", ", offered.ConvertAll(c => c.cardName))}");

        // TODO: Show reward UI and wait for player selection.
        // For now, automatically add the first card to the deck.
        if (offered.Count > 0)
            AddCardToDeck(offered[0]);

        yield return null;
    }

    /// <summary>
    /// Starts the boss combat encounter.
    /// </summary>
    private IEnumerator StartBoss()
    {
        Debug.Log("[RunManager] Starting boss fight!");
        // TODO: Load boss scene / spawn boss enemy.
        yield return StartCoroutine(StartCombat());
        Debug.Log("[RunManager] Boss defeated — run complete!");
    }

    /// <summary>
    /// Returns a random selection of cards from the reward pool.
    /// </summary>
    private List<CardData> GetRewardChoices()
    {
        List<CardData> pool = new List<CardData>(rewardPool);
        List<CardData> choices = new List<CardData>();

        for (int i = 0; i < rewardChoices && pool.Count > 0; i++)
        {
            int index = Random.Range(0, pool.Count);
            choices.Add(pool[index]);
            pool.RemoveAt(index);
        }

        return choices;
    }

    /// <summary>
    /// Adds a chosen card to the player's draw pile.
    /// </summary>
    private void AddCardToDeck(CardData card)
    {
        deckManager.drawPile.Add(card);
        Debug.Log($"[RunManager] '{card.cardName}' added to deck.");
    }
}
