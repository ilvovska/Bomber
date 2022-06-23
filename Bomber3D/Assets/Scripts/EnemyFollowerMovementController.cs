using UnityEngine;

public class EnemyFollowerMovementController : MonoBehaviour
{
    [SerializeField] private MovementController movementController;
    [SerializeField] private Transform player;

    private void Update()
    {
        if (movementController.IsMoving) return;
        
        var direction = (player.position - transform.position).normalized;
        movementController.Move(Direction.Vector2ToDirection(direction));
    }
}