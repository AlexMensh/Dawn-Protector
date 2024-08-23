using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Enemies _enemies;
    [SerializeField] private LoseTrigger _loseTrigger;
    [SerializeField] private StartScreen _startScreen;

    private void Awake()
    {
        if (_enemies == null)
            _enemies = _enemies.GetComponent<Enemies>();
        
        if (_loseTrigger == null)
            _loseTrigger = _loseTrigger.GetComponent<LoseTrigger>();
        
        if (_startScreen == null)
            _startScreen = _startScreen.GetComponent<StartScreen>();
    }

    private void OnEnable()
    {
        _enemies.PlayerWon += Win;
        _loseTrigger.PlayerLost += Lose;
        _startScreen.StartButtonClicked += StartGame;
    }

    private void OnDisable()
    {
        _enemies.PlayerWon -= Win;
        _loseTrigger.PlayerLost -= Lose;
        _startScreen.StartButtonClicked -= StartGame;
    }
    
    private void Start()
    {
        Time.timeScale = 0;
    }

    private void StartGame()
    {
        _playerInput.SetInputActive(true);
        _startScreen.Close();
        Time.timeScale = 1;
    }
    
    private void Win()
    {
        Debug.Log("Player Win");
    }
    
    private void Lose()
    {
        Debug.Log("Game Over");
    }
}
