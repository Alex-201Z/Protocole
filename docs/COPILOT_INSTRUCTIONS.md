# Copilot Instructions — Neon Protocol

You are assisting with the development of **Neon Protocol**, a cyberpunk hacking-themed
tactical deck-builder for Android and iOS built in Unity (C#).

## Rules

1. Follow the architecture described in `docs/ARCHITECTURE.md`.
2. Write clean, modular C# code — one responsibility per class.
3. Avoid tightly coupling systems; prefer event-based communication.
4. Prefer composition over inheritance.
5. Use `ScriptableObject` assets for all card and enemy data.
6. Write simple, readable code — clarity over cleverness.
7. Always explain generated code with brief comments.

## Context Files

- `docs/PROJECT_CONTEXT.md` — game design, MVP scope, card list, dev order.
- `docs/ARCHITECTURE.md` — system breakdown, folder structure, design patterns.

## Key Conventions

- Card data lives in `CardData` ScriptableObjects under `Assets/Cards/`.
- Card effects inherit from the abstract `CardEffect` ScriptableObject.
- The `DeckManager` owns the draw pile and discard pile.
- The `TurnManager` drives the combat loop (`PlayerTurn → EnemyTurn → repeat`).
- `BandwidthSystem` is the mana equivalent — reset at the start of each player turn.
- `RunManager` sequences combats, rewards, and the boss fight.

## MVP Boundaries

The MVP includes: deck system, card combat, 20 cards, 3 enemy types, 1 boss,
simple run structure.

The MVP does **not** include: PvP, base building, player marketplace, multiplayer.

Do not generate code outside the MVP scope unless explicitly asked.
