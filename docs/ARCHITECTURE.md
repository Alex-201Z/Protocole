# Architecture Overview

The project uses a modular architecture.

## Main Systems

| System        | Responsibility                                      |
|---------------|-----------------------------------------------------|
| Card System   | Define card data and card effects                   |
| Deck System   | Manage draw pile, hand, discard pile, and reshuffle |
| Combat System | Manage turn flow, bandwidth, player and enemy actions|
| Enemy AI      | Drive enemy behaviour each turn                     |
| Run System    | Sequence combats, rewards, and the boss fight       |
| UI System     | Display game state to the player                    |

## Principles

- Each system must be **loosely coupled**.
- Communication between systems should use **events** when possible.
- Unity **ScriptableObjects** should be used for all card data.
- Prefer **composition over inheritance**.

## Folder Structure

```
Assets/
  Scripts/
    Cards/          # CardData, CardEffect, concrete effects
    Deck/           # DeckManager, HandManager, DiscardPile
    Combat/         # TurnManager, BandwidthSystem, PlayerController
    Enemy/          # EnemyAI, Health
    Run/            # RunManager
  Cards/            # ScriptableObject assets (.asset files)
  Prefabs/          # Unity prefabs
  UI/               # UI prefabs and scripts
Scenes/             # Unity scene files
docs/               # Project documentation
```

## Card System Design Pattern

```
CardData          ← ScriptableObject — stores name, cost, effect reference
CardEffect        ← abstract ScriptableObject — defines Execute(target)
AttackEffect      ← concrete CardEffect — deals damage
DefenseEffect     ← concrete CardEffect — grants shield
UtilityEffect     ← concrete CardEffect — modifies bandwidth/stats
ControlEffect     ← concrete CardEffect — applies status effects
```

Adding a new card **never requires new code** — create a new `CardData` asset and
assign an existing `CardEffect` asset.

## Event Flow (Combat)

```
TurnManager
  → PlayerController.StartTurn()
      → BandwidthSystem.ResetBandwidth()
      → HandManager.DrawCards()
  → PlayerController.EndTurn()
  → EnemyAI.TakeTurn()
      → EnemyAI.PerformAttack()
  → (repeat)
```
