using System;
using SimpleInputNamespace;
using UnityEngine;
using UnityEngine.UI;

public class GameUI: MonoBehaviour
{
    public event Action OnBombClick;

    [SerializeField] private Button bombButton;
    [SerializeField] private Joystick joystick;
    public Joystick Joystick => joystick;

    private void Start()
    {
        bombButton.onClick.AddListener(OnBomb);
    }

    private void OnBomb() => OnBombClick.Invoke();
}