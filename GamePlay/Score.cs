using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private int value;
    [SerializeField] private int valueToUpgradeLevel;

    public static int _score;

    public static Action OnLevelUpgrade;

    private void OnEnable() => Pizza.OnPizzaCatch += ScoreUpdate;
    private void OnDisable() => Pizza.OnPizzaCatch -= ScoreUpdate;
    private void Start() => _score = 0;
    private void ScoreUpdate()
    {
        _score += value;
        scoreText.text = "Score " + _score;
        if (_score >= valueToUpgradeLevel)
            OnLevelUpgrade?.Invoke();
    }
}
