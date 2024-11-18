using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScreen : MonoBehaviour
{
    [SerializeField] private Toggle sound;
    [SerializeField] private Toggle music;
    [SerializeField] private Toggle vibration;
    [SerializeField] private int startScene;

    public static Action<bool> MusicPlay;

    private void Awake()
    {
        sound.isOn = DataPersistance.isSound;
        music.isOn = DataPersistance.isMusic;
        vibration.isOn = DataPersistance.isVibro;
    }
    public void SoundChange() => DataPersistance.isSound = sound.isOn;
    public void MusicChange()
    {
        DataPersistance.isMusic = music.isOn;
        MusicPlay?.Invoke(music.isOn);
    }

    public void VibroChange() => DataPersistance.isVibro = vibration.isOn;

    public void BackToMainMenuButton()
    {
        DataPersistance.SaveData();
        SceneManager.LoadScene(startScene);       
    }
}
