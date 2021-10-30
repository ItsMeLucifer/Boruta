using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyScript : MonoBehaviour
{
    private LanguageManager lang;
    [SerializeField] private string polishName;
    [SerializeField] private string englishName;
    void Start()
    {
        lang = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
        if (lang.language == Language.Polish) GetComponent<Text>().text = polishName;
        if (lang.language == Language.English) GetComponent<Text>().text = englishName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
