using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextToReadData : MonoBehaviour
{
    public int PageAmount = 5;
    public Text textToRead;
    public GameObject pieceOfCharacter;
    public GameObject particlePrefab;
    [SerializeField] private Text polishText;
    [SerializeField] private Text englishText;
    private LanguageManager lang;
    void Start()
    {
        textToRead = GetComponent<Text>();
        lang = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
        if (lang.language == Language.Polish) textToRead = polishText;
        if (lang.language == Language.English) textToRead = englishText;
    }
    public void WhileReadingTheText()
    {
        pieceOfCharacter.SetActive(true);
    }
    public void SpawnParticle()
    {
        GameObject particle = Instantiate(particlePrefab, Vector3.zero, Quaternion.identity) as GameObject;
        particle.transform.position = transform.position;
        particle.transform.eulerAngles = new Vector3(-90f, 0, 0);
    }
}
