using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    Menu = 0,
    PlayingMode = 1,
    Victory = 2,
    Lose = 3
}
public class GameManager : Singleton<GameManager>
{
    
    private GameState state;

    // Start is called before the first frame update
    private void Awake()
    {
        ChangeState(GameState.Menu);
    }
    public void ChangeState(GameState gameState)
    {
        state = gameState;
    }
    public bool isState (GameState gameState)
    {
        return state == gameState;  
    }

}

