using UnityEngine;

public static class DataPersistance
{
    public static bool isSound;
    public static bool isMusic;
    public static bool isVibro;

    public static int bestScore;

    public  static  void LoadData()
    {
        isSound = (PlayerPrefs.GetInt("sound") == 1) ? true : false;
        isMusic = (PlayerPrefs.GetInt("music") == 1) ? true : false;
        isVibro = (PlayerPrefs.GetInt("vibro") == 1) ? true : false;

        bestScore = PlayerPrefs.GetInt("bestScore");
    }

    public static void SaveData()
    {
        if (isSound) PlayerPrefs.SetInt("sound", 1);
        else PlayerPrefs.SetInt("sound", 0);

        if (isMusic) PlayerPrefs.SetInt("music", 1);
        else PlayerPrefs.SetInt("music", 0);

        if (isVibro) PlayerPrefs.SetInt("vibro", 1);
        else PlayerPrefs.SetInt("vibro", 0);

        PlayerPrefs.SetInt("bestScore", bestScore);

        PlayerPrefs.Save();
    }
}
