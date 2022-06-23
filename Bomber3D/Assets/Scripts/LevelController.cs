using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public event Action OnPlayerDead;
    public event Action OnEnemiesDead;
    
    [SerializeField] private Player player;
    [SerializeField] private Enemy[] enemies;
    [SerializeField] private BombPlanter bombPlanter;

    private int enemiesCount;
    
    private void Start()
    {
        enemiesCount = enemies.Length;
        player.OnDie += OnPlayerDie;
        foreach (var enemy in enemies)
            enemy.OnDie += OnEnemyDie;
    }

    public void Initialize(GameUIController gameUIController)
    {
        player.Initialize(gameUIController.Joystick);
        gameUIController.OnBombClick += OnBombClick;
    }

    private void OnBombClick()
    {
        bombPlanter.PlantBomb();
    }

    private void OnPlayerDie()
    {
        OnPlayerDead.Invoke();
        EndGame();
    }

    private void OnEnemyDie()
    {
        enemiesCount--;
        if (enemiesCount > 0) return;

        OnEnemiesDead.Invoke();
        EndGame();
    }

    private void EndGame()
    {
        Destroy(gameObject);
    }
}