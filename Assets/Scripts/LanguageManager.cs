using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language
{
    Polish,
    English
}
public class LanguageManager : MonoBehaviour
{
    public Language language = Language.Polish;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SetLanguage(string lang)
    {
        if (lang == "PL") language = Language.Polish;
        if (lang == "ENG") language = Language.English;
    }
}
