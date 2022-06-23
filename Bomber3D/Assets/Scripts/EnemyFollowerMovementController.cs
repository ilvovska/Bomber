using UnityEngine;

public class EnemyFollowerMovementController : MonoBehaviour
{
    [SerializeField] private MovementController movementController;
    [SerializeField] private Transform player;

    private void Update()
    {
        if (movementController.IsMoving) return;
        
        var direction = (player.position - transform.position).normalized;
        var axis = (int)(Vector2.Angle(new Vector2(direction.x, direction.z), Vector2.up) / 60);
        var right = direction.x > 0;

        switch (axis)
        {
            case 0:
                movementController.Move(right ? MovementController.Direction.Hour1 : MovementController.Direction.Hour11);
                break;
            case 1:
                movementController.Move(right ? MovementController.Direction.Hour3 : MovementController.Direction.Hour9);
                break;
            case 2:
                movementController.Move(right ? MovementController.Direction.Hour5 : MovementController.Direction.Hour7);
                break;
        }
    }
}