using UnityEngine;

public class Explodable : MonoBehaviour, IExplodable
{
    public void Explode() => Destroy(gameObject);
}