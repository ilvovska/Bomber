using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuUI : MonoBehaviour
{
    private const string winText = "Winner!";
    private const string loseText = "Loser!";
    
    public event Action OnStartClick;
    
    [SerializeField] private Button startButton;
    [SerializeField] private TMP_Text text;

    private void Start()
    {
        startButton.onClick.AddListener(OnStart);
    }

    private void OnStart() => OnStartClick.Invoke();

    public void SetWinText(bool winLastGame)
    {
        text.text = winLastGame ? winText : loseText;
    }
}