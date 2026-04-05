# Neon Protocol

A cyberpunk hacking-themed tactical deck-builder for Android and iOS, built in Unity (C#).

## Quick Start

1. Open the project in Unity.
2. Read [`docs/PROJECT_CONTEXT.md`](docs/PROJECT_CONTEXT.md) for the game design and MVP scope.
3. Read [`docs/ARCHITECTURE.md`](docs/ARCHITECTURE.md) for the system architecture.
4. Follow the dev order in `PROJECT_CONTEXT.md` — build systems before content.

## Repository Structure

```
Assets/
  Scripts/
    Cards/      # CardData, CardEffect, and all concrete effects
    Deck/       # DeckManager, HandManager
    Combat/     # TurnManager, BandwidthSystem, PlayerController
    Enemy/      # EnemyAI, Health, StatusEffectHandler
    Run/        # RunManager
  Cards/        # ScriptableObject card assets (.asset files)
  Prefabs/      # Unity prefabs
  UI/           # UI prefabs and scripts
Scenes/         # Unity scene files
docs/
  PROJECT_CONTEXT.md      # Game design, MVP scope, card list
  ARCHITECTURE.md         # System breakdown and design patterns
  COPILOT_INSTRUCTIONS.md # Rules for GitHub Copilot assistance
```

## GitHub Copilot

This project is configured for GitHub Copilot assistance.
See [`docs/COPILOT_INSTRUCTIONS.md`](docs/COPILOT_INSTRUCTIONS.md) for the rules Copilot follows.
