using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LooseScreen : MonoBehaviour
{
    [SerializeField] private int gameScene;
    [SerializeField] private int startScene;
    [SerializeField] private TMP_Text scoreText; 
   

    private void Start()
    {
        scoreText.text = Score._score.ToString();

        if (Score._score > DataPersistance.bestScore)
        {
            DataPersistance.bestScore = Score._score;
            PlayerPrefs.SetInt("bestScore", DataPersistance.bestScore);
        }
    }

    public void RestartButton() => SceneManager.LoadScene(gameScene);
    public void MainMenuButton() => SceneManager.LoadScene(startScene);

    private void OnDisable() => PlayerPrefs.Save();
}
