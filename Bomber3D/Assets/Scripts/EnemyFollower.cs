using UnityEngine;

public class EnemyFollower : Enemy
{
    [SerializeField] private Movement movement;

    private Transform player;

    private void Update()
    {
        if (movement.IsMoving) return;

        var direction = (player.position - transform.position).normalized;
        movement.Move(Direction.Vector2ToDirection(new Vector2(direction.x, direction.z)));
    }

    public void SetPlayerTransform(Transform playerTransform) => player = playerTransform;
}