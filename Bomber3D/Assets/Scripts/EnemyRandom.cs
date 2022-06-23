using System;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class EnemyRandom : Enemy
{
    [SerializeField] private Movement movement;

    private Random random;

    private void Start()
    {
        random = new Random();
    }

    private void Update()
    {
        if (movement.IsMoving) return;

        bool moved;
        var directions = Enum.GetValues(typeof(Direction.Type))
            .Cast<Direction.Type>()
            .ToList();
        
        do
        {
            var directionIndex = random.Next(directions.Count);
            moved = movement.Move(directions[directionIndex]);
            directions.RemoveAt(directionIndex);
        } while (!moved && directions.Count > 0);
    }
}