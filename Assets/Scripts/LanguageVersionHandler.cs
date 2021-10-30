using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LanguageVersionHandler : MonoBehaviour
{
    [SerializeField] private GameObject polishText;
    [SerializeField] private GameObject englishText;
    private LanguageManager langManager;
    private void Start()
    {
        langManager = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
        polishText.SetActive(langManager.language == Language.Polish);
        englishText.SetActive(!(langManager.language == Language.Polish));
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu") return;
        polishText.SetActive(langManager.language == Language.Polish);
        englishText.SetActive(!(langManager.language == Language.Polish));
    }
}
