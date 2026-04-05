# Neon Protocol — Project Context

## Project Type
Mobile tactical deck-builder game.

## Engine
Unity

## Language
C#

## Target Platforms
Android / iOS

## Game Summary
Neon Protocol is a cyberpunk hacking-themed tactical deck-builder.

Players infiltrate corporate servers using a deck of hacking programs (cards).
Combat is turn-based.

Runs are short (10–15 minutes).

## Core Gameplay Loop

1. Player starts a run
2. Player enters combat
3. Player draws cards
4. Player plays cards using bandwidth (mana)
5. Enemy AI acts
6. Combat ends
7. Player receives card reward
8. Repeat until boss

## MVP Scope

The MVP includes:

- deck system
- card combat
- 20 cards
- 3 enemy types
- 1 boss
- simple run structure

The MVP DOES NOT include:

- PvP
- base building
- player marketplace
- multiplayer

## Design Pillars

1. Tactical depth
2. Short mobile sessions
3. Clear cyberpunk theme
4. Easy to understand mechanics

## Card List (MVP — 20 cards)

### Attack
| Name             | Description        |
|------------------|--------------------|
| Ping Attack      | Deal 6 damage      |
| Packet Burst     | Deal 8 damage      |
| Virus Injection  | Deal 10 damage     |

### Defense
| Name              | Description             |
|-------------------|-------------------------|
| Encryption        | Gain 6 shield           |
| Firewall Mirror   | Reflect incoming damage |

### Utility
| Name              | Description              |
|-------------------|--------------------------|
| Backdoor          | Reduce enemy defense     |
| Bandwidth Boost   | Gain extra mana this turn|

### Control
| Name              | Description              |
|-------------------|--------------------------|
| System Freeze     | Skip the enemy's turn    |
| Data Leak         | Apply damage over time   |

## Dev Order (IMPORTANT)

Build systems in this order to avoid wasted effort:

1. Card data
2. Deck system
3. Combat loop
4. Enemy AI
5. Rewards
6. Run structure

Do **not** build UI or content before the core systems are stable.
