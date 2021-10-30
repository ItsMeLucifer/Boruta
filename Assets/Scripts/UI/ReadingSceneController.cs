using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadingSceneController : MonoBehaviour
{
    [SerializeField] private GameObject textToRead;
    [SerializeField] private Text pageNumberDisplayText;
    public int maxPageNumber = 5;
    public void RestartPageNumber()
    {
        textToRead.GetComponent<TextMeshProUGUI>().pageToDisplay = 1;
    }
    public void NextPageToRead()
    {
        if (textToRead.GetComponent<TextMeshProUGUI>().pageToDisplay < maxPageNumber) textToRead.GetComponent<TextMeshProUGUI>().pageToDisplay++;
        SetPageNumber();
    }
    public void PreviousPageToRead()
    {
        if (textToRead.GetComponent<TextMeshProUGUI>().pageToDisplay > 1) textToRead.GetComponent<TextMeshProUGUI>().pageToDisplay--;
        SetPageNumber();
    }
    public void SetPageNumber()
    {
        pageNumberDisplayText.text = textToRead.GetComponent<TextMeshProUGUI>().pageToDisplay.ToString() + "/" + maxPageNumber.ToString();

    }
}
