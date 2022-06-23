using SimpleInputNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : Deadly
{
    [SerializeField] private Movement movement;

    private Joystick joystick;

    public void Initialize(Joystick joystick) => this.joystick = joystick;

    private void Update()
    {
        if (!movement.IsMoving && joystick.Value.magnitude > 0.5)
            movement.Move(Direction.Vector2ToDirection(joystick.Value));
    }
}
