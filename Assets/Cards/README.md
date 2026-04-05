# Assets/Cards

This folder contains Unity ScriptableObject assets for every card in Neon Protocol.

## Naming convention

`[CardName].asset` — e.g. `PingAttack.asset`, `Encryption.asset`

## How to create a card (no code required)

1. Right-click inside this folder in the Unity Project window.
2. Choose **Create → Cards → Card Data**.
3. Fill in `cardName`, `cost`, and assign a `CardEffect` asset.

## How to create a card effect asset

1. Right-click inside `Assets/Cards` (or a sub-folder).
2. Choose **Create → Cards → Effects → [Effect Type]**.
3. Assign the resulting asset to a `CardData`'s `effect` field.

## MVP Card List

| Name              | Cost | Effect Type    | Value  |
|-------------------|------|----------------|--------|
| Ping Attack       | 1    | Attack         | 6 dmg  |
| Packet Burst      | 2    | Attack         | 8 dmg  |
| Virus Injection   | 3    | Attack         | 10 dmg |
| Encryption        | 1    | Defense        | 6 shld |
| Firewall Mirror   | 2    | FirewallMirror | 1 turn |
| Backdoor          | 1    | Backdoor       | -3 def |
| Bandwidth Boost   | 0    | Utility        | +2 bw  |
| System Freeze     | 2    | Control(Stun)  | 1 turn |
| Data Leak         | 1    | Control(DoT)   | 3/turn |
