using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class EnemyRandomMovementController : Enemy
{
    [SerializeField] private MovementController movementController;

    private Random random;

    private void Start()
    {
        random = new Random();
    }

    private void Update()
    {
        if (movementController.IsMoving) return;

        bool moved;
        var directions = Enum.GetValues(typeof(Direction.Type))
            .Cast<Direction.Type>()
            .ToList();
        
        do
        {
            var directionIndex = random.Next(directions.Count);
            moved = movementController.Move(directions[directionIndex]);
            directions.RemoveAt(directionIndex);
        } while (!moved && directions.Count > 0);
    }
}