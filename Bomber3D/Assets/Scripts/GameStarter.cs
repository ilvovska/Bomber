using System;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private LevelController levelControllerPrefab;
    [SerializeField] private GameUIController gameUIController;
    [SerializeField] private MenuController menuController;

    private void Start()
    {
        menuController.OnStartClick += StartGame;
    }

    private void StartGame()
    {
        var levelController = Instantiate(levelControllerPrefab);
        levelController.Initialize(gameUIController);
        levelController.OnPlayerDead += OnPlayerDead;
        levelController.OnEnemiesDead += OnEnemiesDead;
        
        menuController.gameObject.SetActive(false);
        gameUIController.gameObject.SetActive(true);
    }

    private void EndGame(bool winGame)
    {
        menuController.gameObject.SetActive(true);
        menuController.SetWinText(winGame);
        gameUIController.gameObject.SetActive(false);
    }
    
    private void OnEnemiesDead() => EndGame(true);

    private void OnPlayerDead() => EndGame(false);
}