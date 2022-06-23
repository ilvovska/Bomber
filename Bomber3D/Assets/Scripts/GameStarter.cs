using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private LevelController levelControllerPrefab;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private MenuUI menuUI;

    private void Start()
    {
        menuUI.OnStartClick += StartGame;
    }

    private void StartGame()
    {
        var levelController = Instantiate(levelControllerPrefab);
        levelController.Initialize(gameUI);
        levelController.OnPlayerDead += OnPlayerDead;
        levelController.OnEnemiesDead += OnEnemiesDead;
        
        menuUI.gameObject.SetActive(false);
        gameUI.gameObject.SetActive(true);
    }

    private void EndGame(bool winGame)
    {
        menuUI.gameObject.SetActive(true);
        menuUI.SetWinText(winGame);
        gameUI.gameObject.SetActive(false);
    }
    
    private void OnEnemiesDead() => EndGame(true);

    private void OnPlayerDead() => EndGame(false);
}