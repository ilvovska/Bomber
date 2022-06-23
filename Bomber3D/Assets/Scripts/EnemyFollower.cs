using UnityEngine;

public class EnemyFollower : Enemy
{
    [SerializeField] private Movement movement;
    [SerializeField] private Transform player;

    private void Update()
    {
        if (movement.IsMoving) return;
        
        var direction = (transform.position - player.position).normalized;
        movement.Move(Direction.Vector2ToDirection(direction));
    }
}