using UnityEngine;

public class LanguageManagerSimple : MonoBehaviour
{
    public static LanguageManagerSimple Instance;

    public GameObject Dutch;
    public GameObject English;

    public enum Language { Dutch, English }
    public Language currentLanguage = Language.English;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadLanguage();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SwitchLanguage()
    {
        currentLanguage = (currentLanguage == Language.English) ? Language.Dutch : Language.English;
        PlayerPrefs.SetInt("language_simple", (int)currentLanguage);
        ApplyLanguage();
    }

    void LoadLanguage()
    {
        if (PlayerPrefs.HasKey("language_simple"))
        {
            currentLanguage = (Language)PlayerPrefs.GetInt("language_simple");
        }
        ApplyLanguage();
    }

    void ApplyLanguage()
    {
        if (Dutch != null) Dutch.SetActive(currentLanguage == Language.Dutch);
        if (English != null) English.SetActive(currentLanguage == Language.English);
    }
}

