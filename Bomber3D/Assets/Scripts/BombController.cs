using System;
using System.Threading.Tasks;
using UnityEngine;

public class BombController : MonoBehaviour, IExplodable
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float exploseTime;

    private float radius = 1;
    private bool exploded;
    private Action onExplode;

    public async Task Initialize(Action onExplode)
    {
        this.onExplode = onExplode;
        await Task.Delay(TimeSpan.FromSeconds(exploseTime));
        Explode();
    }

    public void Explode()
    {
        if (exploded) return;

        exploded = true;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.GetComponent<IExplodable>()?.Explode();
        }
        
        onExplode.Invoke();
        Destroy(gameObject);
    }
}