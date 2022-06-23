using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveTime;
    [SerializeField] private LayerMask layers;

    private readonly Dictionary<Direction, Vector3> directionVectors = new Dictionary<Direction, Vector3>()
    {
        { Direction.Hour1, new Vector3(0.5f, 0, 0.866f) },
        { Direction.Hour3, new Vector3(1, 0, 0) },
        { Direction.Hour5, new Vector3(0.5f, 0, -0.866f) },
        { Direction.Hour7, new Vector3(-0.5f, 0, -0.866f) },
        { Direction.Hour9, new Vector3(-1, 0, 0) },
        { Direction.Hour11, new Vector3(-0.5f, 0, 0.866f) },
    };

    public bool IsMoving => isMoving;
    private bool isMoving;

    public bool Move(Direction direction)
    {
        if (isMoving) return false ;

        var newPosition = transform.position + directionVectors[direction];

        if (Physics.Linecast(transform.position, newPosition, layers)) return false;

        StartCoroutine(Movement(newPosition));
        return true;
    }

    private IEnumerator Movement(Vector3 newPosition)
    {
       isMoving = true;
        var timer = 0f;

        while (timer < moveTime)
        {
            timer += Time.deltaTime;
            transform.position = (newPosition - transform.position) * timer / moveTime + transform.position;
            yield return null;
        }

        transform.position = newPosition;
        isMoving = false;
    }

    public enum Direction
    {
        Hour1 = 0,
        Hour3 = 1,
        Hour5 = 2,
        Hour7 = 3,
        Hour9 = 4,
        Hour11 = 5,
    }
}
