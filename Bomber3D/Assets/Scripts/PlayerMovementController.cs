using SimpleInputNamespace;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private MovementController movementController;
    [SerializeField] private Joystick joystick;

    private void Update()
    {
        if (joystick.Value.magnitude > 0.5)
        {
            var axis = (int)(Vector2.Angle(joystick.Value, Vector2.up) / 60);
            var right = joystick.Value.x > 0;

            switch (axis)
            {
                case 0:
                    movementController.Move(right ? MovementController.Direction.Hour1 : MovementController.Direction.Hour11);
                    break;
                case 1:
                    movementController.Move(right ? MovementController.Direction.Hour3 : MovementController.Direction.Hour9);
                    break;
                case 2:
                    movementController.Move(right ? MovementController.Direction.Hour5 : MovementController.Direction.Hour7);
                    break;
            }
        }
    }
}
