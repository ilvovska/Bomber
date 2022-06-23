using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class EnemyRandomMovementController : MonoBehaviour
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
        var directions = Enum.GetValues(typeof(MovementController.Direction))
            .Cast<MovementController.Direction>()
            .ToList();
        
        do
        {
            var directionIndex = random.Next(directions.Count);
            moved = movementController.Move(directions[directionIndex]);
            directions.RemoveAt(directionIndex);
        } while (!moved && directions.Count > 0);
    }
}