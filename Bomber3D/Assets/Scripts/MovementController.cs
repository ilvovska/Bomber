using System.Collections;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float moveTime;
    [SerializeField] private LayerMask layers;


    public bool IsMoving => isMoving;
    private bool isMoving;

    public bool Move(Direction.Type direction)
    {
        if (isMoving) return false ;

        var newPosition = transform.position + Direction.DirectionToVector3(direction);

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
}