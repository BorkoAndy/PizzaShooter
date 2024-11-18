using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BestScoreScreen : MonoBehaviour
{
    [SerializeField] private int startScene;
    [SerializeField] private TMP_Text lastScoreText;
    [SerializeField] private TMP_Text bestScoreText;    
    
    private void Start()
    {
        bestScoreText.text = DataPersistance.bestScore.ToString();
           
        lastScoreText.text = Score._score.ToString();
    }
    public void BackToMenuButton() => SceneManager.LoadScene(startScene);
}
