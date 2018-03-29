using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, определяющий состояние игровой сессии
/// </summary>
public class GameState : Singleton<GameState>
{
    private State gameState;

    public State GetState()
    {
        return gameState;
    }

    public void SetState(State state)
    {
        gameState = state;
    }
}

