using SimpleInputNamespace;
using UnityEngine;

public class Player : Deadly
{
    [SerializeField] private Movement movement;
    [SerializeField] private int enemyLayer;

    private Joystick joystick;

    public void Initialize(Joystick joystick) => this.joystick = joystick;

    private void Update()
    {
        if (!movement.IsMoving && joystick.Value.magnitude > 0.5)
            movement.Move(Direction.Vector2ToDirection(joystick.Value));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == enemyLayer)
           Destroy(gameObject);
    }
}
