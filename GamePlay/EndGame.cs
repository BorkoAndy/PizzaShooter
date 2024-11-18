using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject windows;
    [SerializeField] private int looseScene;

    private int _windowsCount;
    private int _brokenWindows;
    private void OnEnable() => Window.OnWindowBrake += WindowBroke;

    private void OnDisable() => Window.OnWindowBrake += WindowBroke;

    private void Start() => _windowsCount = windows.transform.childCount;
    private void Update()
    {
        if (_brokenWindows == _windowsCount)
            LooseGame();
    }
    private void WindowBroke() => _brokenWindows++;
    private void LooseGame() => SceneManager.LoadScene(looseScene);
}
