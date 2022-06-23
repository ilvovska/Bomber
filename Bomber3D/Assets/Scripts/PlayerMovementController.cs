using SimpleInputNamespace;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private MovementController movementController;
    [SerializeField] private Joystick joystick;

    private void Update()
    {
        if (joystick.Value.magnitude > 0.5)
            movementController.Move(Direction.Vector2ToDirection(joystick.Value));
    }
}
