using SimpleInputNamespace;
using UnityEngine;

public class Player : Deadly
{
    [SerializeField] private MovementController movementController;

    private Joystick joystick;

    public void Initialize(Joystick joystick) => this.joystick = joystick;

    private void Update()
    {
        if (!movementController.IsMoving && joystick.Value.magnitude > 0.5)
            movementController.Move(Direction.Vector2ToDirection(joystick.Value));
    }
}
