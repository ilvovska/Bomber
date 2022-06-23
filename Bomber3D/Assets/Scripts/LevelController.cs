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
    private GameUI gameUI;
    private bool gameEnded;

    private void Start()
    {
        enemiesCount = enemies.Length;
        player.OnDie += OnPlayerDie;
        foreach (var enemy in enemies)
        {
            enemy.OnDie += OnEnemyDie;
            var follower = enemy as EnemyFollower;
            if (follower)
                follower.SetPlayerTransform(player.transform);
        }
    }

    public void Initialize(GameUI gameUI)
    {
        this.gameUI = gameUI;
        player.Initialize(this.gameUI.Joystick);
        this.gameUI.OnBombClick += OnBombClick;
    }

    private void OnBombClick() => bombPlanter.PlantBomb();

    private void OnPlayerDie()
    {
        if(gameEnded) 
            return;
        
        OnPlayerDead.Invoke();
        EndGame();
    }

    private void OnEnemyDie()
    {
        if(gameEnded) 
            return;
        
        enemiesCount--;
        if (enemiesCount > 0) return;

        OnEnemiesDead.Invoke();
        EndGame();
    }

    private void EndGame()
    {
        gameEnded = true;
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        gameUI.OnBombClick -= OnBombClick;
    }
}