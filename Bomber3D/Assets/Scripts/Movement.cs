using System;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveTime;
    [SerializeField] private LayerMask layers;

    public bool IsMoving => isMoving;
    private bool isMoving;

    public bool Move(Direction.Type direction)
    {
        if (isMoving) 
            return false;

        var newPosition = transform.position + Direction.DirectionToVector3(direction);

        if (Physics.Linecast(transform.position, newPosition, layers)) 
            return false;

        Move(newPosition);
        return true;
    }

    private async void Move(Vector3 newPosition)
    {
        isMoving = true;
        transform.DOMove(newPosition, moveTime);
        await Task.Delay(TimeSpan.FromSeconds(moveTime));

        isMoving = false;
    }
}