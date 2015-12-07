using UnityEngine;


public class GameManager : MonoBehaviour {

    public enum GameState
    {
        PAUSED,
        IN_GAME,
    }

    public static GameState CurrentGameState = GameState.PAUSED;

    public static GameManager SSingleton = null;

    public static GameManager Instance
    {
        get { return SSingleton ?? (SSingleton = new GameObject("GameManager").AddComponent<GameManager>()); }
        
    }

    void Awake()
    {
        if (SSingleton)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            SSingleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        CurrentGameState = GameState.IN_GAME;
    }



	
}
