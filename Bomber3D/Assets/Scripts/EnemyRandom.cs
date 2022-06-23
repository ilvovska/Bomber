using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class EnemyRandom : Enemy
{
    [SerializeField] private Movement movement;

    private Random random;
    private List<Direction.Type> directions;

    private void Start()
    {
        random = new Random();
        directions = Enum.GetValues(typeof(Direction.Type))
            .Cast<Direction.Type>()
            .ToList();
    }

    private void Update()
    {
        if (movement.IsMoving)
            return;

        bool moved;
        var untriedDirections = new List<Direction.Type>(directions);

        do
        {
            var directionIndex = random.Next(untriedDirections.Count);
            moved = movement.Move(untriedDirections[directionIndex]);
            untriedDirections.RemoveAt(directionIndex);
        } while (!moved && untriedDirections.Count > 0);
    }
}