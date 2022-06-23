using UnityEngine;
using UnityEngine.UI;

public class BombPlanter : MonoBehaviour
{
    [SerializeField] private BombController bombPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private Button button;

    private int bombCount;
    private int bombMaxCount=1;

    private void Start()
    {
        button.onClick.AddListener(PlantBomb);
    }

    private void PlantBomb()
    {
        if (bombCount >= bombMaxCount) return;
        var bomb = Instantiate(bombPrefab, player.position, Quaternion.identity);
        bomb.Initialize(() => bombCount--);

        bombCount++;
    }
}