using System;
using UnityEngine;

public class Deadly : MonoBehaviour
{
    public event Action OnDie;

    private void OnDestroy()
    {
        OnDie?.Invoke();
    }
}