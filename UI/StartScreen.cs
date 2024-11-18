using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private int gameScene;
    [SerializeField] private int scoreScene;
    [SerializeField] private int settingsScene;
    private void Awake() => DataPersistance.LoadData();
    public void PlayButton() => SceneManager.LoadScene(gameScene);
    public void ScoreButton() => SceneManager.LoadScene(scoreScene);
    public void SettingsButton() => SceneManager.LoadScene(settingsScene);
}
