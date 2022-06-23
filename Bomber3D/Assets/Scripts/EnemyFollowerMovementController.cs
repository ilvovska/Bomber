using UnityEngine;

public class EnemyFollowerMovementController : Enemy
{
    [SerializeField] private MovementController movementController;
    [SerializeField] private Transform player;

    private void Update()
    {
        if (movementController.IsMoving) return;
        
        var direction = (transform.position - player.position).normalized;
        movementController.Move(Direction.Vector2ToDirection(direction));
    }
}