# Wavefire Hunter or Hunted

## Overview

Welcome to **Wavefire Hunter or Hunted**, an action-packed game that combines intense shooting gameplay with strategic waves of enemies. As a player, you'll dive into a world filled with relentless foes, where quick reflexes and precision shooting are your keys to survival.

## Design Patterns Used

### Singleton

Several classes in the game use the Singleton design pattern, ensuring that there is only one instance of these classes throughout the game. Some examples include:

- `GameSceneManager`
- `EventSystem`
- `PlayerService`
- `BulletService`
- `EnemyService`
- `ScoreManager`

### Object Pooling

The game implements object pooling to efficiently manage and reuse game objects, reducing the overhead of creating and destroying instances during gameplay. Notable object poolers include:

- `EnemyObjectPooler`
- `BulletObjectPooler`

### State Machine

The Enemy State Machine utilizes the State design pattern to manage and transition between various states for enemy behavior. States include `Idle`, `Chasing`, and `Attacking`, providing a structured approach to enemy AI.

### MVC Architecture

The game employs the Model-View-Controller (MVC) architectural pattern to organize and separate concerns within the codebase. Key components following MVC include:

- **Player**: Handles player-related logic and interactions.
- **Enemy**: Manages enemy behaviors, states, and interactions.
- **Bullet**: Controls bullet mechanics, collisions, and recycling.
- **Gun**: Manages the player's gun, shooting mechanics, and reloading.

### Observer Pattern

The Observer design pattern is employed through an Event System to facilitate communication between different parts of the game. Events such as enemy death, score updates, etc. are observed by relevant components.

## Other Concepts

### ScriptableObjects

- **PlayerScriptableObject**: Stores data for player configurations.
- **EnemyScriptableObject**: Stores data for enemy configurations.
- **BulletScriptableObject**: Contains bullet-related attributes.
- **GunScriptableObject**: Holds gun-related parameters.

### Interfaces

- **IDamageable**: Implemented by entities that can take damage, such as the player and enemies.

### OOP (Object-Oriented Programming)

The game extensively utilizes principles of object-oriented programming to create modular, reusable, and maintainable code.

## How to Play

1. **Objective**: Survive waves of enemies and achieve the highest score possible.

2. **Controls**:
   - Move: WASD or arrow keys.
   - Aim: Mouse cursor.
   - Shoot: Left mouse button.
   - Reload: Automatically triggered after firing the maximum allowed bullets.

3. **Gameplay**:
   - Enemies spawn in waves, becoming progressively challenging.
   - Eliminate enemies to earn points.
   - Avoid enemy attacks and survive as long as possible.

4. **Scoring**:
   - Score increases with each defeated enemy.

5. **Game Over**:
   - The game ends when the player's health reaches zero.
   - The final score is displayed, and players can restart the game.

## Gameplay Video

[![Wavefire Hunter or Hunted Gameplay](https://img.youtube.com/vi/2FhSCsQ9FTE/0.jpg)](https://www.youtube.com/watch?v=2FhSCsQ9FTE)

Check out the gameplay video on YouTube to get a glimpse of the thrilling action in **Wavefire Hunter or Hunted**. See how waves of enemies challenge the player's skills and witness the intense shooting gameplay.

[Watch Gameplay Video](https://www.youtube.com/watch?v=2FhSCsQ9FTE)

## Have a blast playing Wavefire Hunter or Hunted! Good luck, hunter!
