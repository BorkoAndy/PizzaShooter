using UnityEngine;

public class Audio : MonoBehaviour
{ 
    public static Audio Instance;


    [SerializeField] private AudioClip pizzaCatchingSound;
    [SerializeField] private AudioClip windowBreakingSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void OnEnable()
    {
        Window.OnWindowBrake += WindowBreak;
        Pizza.OnPizzaCatch += PizzaCatch;
        SettingsScreen.MusicPlay += MusicPlay;
    }
    private void OnDisable()
    {
        Window.OnWindowBrake -= WindowBreak;
        Pizza.OnPizzaCatch -= PizzaCatch;
        SettingsScreen.MusicPlay -= MusicPlay;
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (!DataPersistance.isMusic) 
            _audioSource.Stop();
    }

    private void WindowBreak()
    {
        if(DataPersistance.isSound)
            _audioSource.PlayOneShot(windowBreakingSound);
    }

    private void PizzaCatch()
    {
        if (DataPersistance.isSound)
            _audioSource.PlayOneShot(pizzaCatchingSound);
    }
    private void MusicPlay(bool musicOn)
    {
        if(musicOn) _audioSource.Play();
        if(!musicOn) _audioSource.Stop();
    }
}
