using UnityEngine;

public class BombPlanter : MonoBehaviour
{
    [SerializeField] private BombController bombPrefab;
    [SerializeField] private Transform player;

    private int bombCount;
    private int bombMaxCount=1;

    public void PlantBomb()
    {
        if (bombCount >= bombMaxCount) return;
        var bomb = Instantiate(bombPrefab, player.position, Quaternion.identity);
        bomb.Initialize(() => bombCount--);

        bombCount++;
    }
}