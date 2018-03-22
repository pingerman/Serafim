using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public enum State
{
    Start,
    SelectLevel,
    SelectCharacter,
    Modal,
    Play
}
