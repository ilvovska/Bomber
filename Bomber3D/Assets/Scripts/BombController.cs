using System;
using System.Collections;
using UnityEngine;

public class BombController : MonoBehaviour, IExplodable
{
   [SerializeField] private LayerMask layerMask;
    [SerializeField] private float exploseTime;

    private float radius=1;
    private bool exploded;

    public void Initialize(Action onExplode)
    {
        StartCoroutine(Explosion(onExplode));
    }

    private IEnumerator Explosion(Action onExplode)
    {
        yield return new WaitForSeconds(exploseTime);

        Explode();
        onExplode.Invoke();
    }

    public void Explode()
    {
        if (exploded) return;

        exploded = true;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        foreach (var hitCollider in hitColliders)
        {
            hitCollider.SendMessage("Explode");
        }
        
        Destroy(gameObject);
    }
}