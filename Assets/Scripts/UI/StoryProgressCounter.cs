using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryProgressCounter : MonoBehaviour
{
    [SerializeField] private GameObject[] storyParts;
    [SerializeField] private Text displayText;
    private int _storyProgressCounter = 0;
    private int _storyPartsAmount;
    void Start()
    {
        _storyPartsAmount = storyParts.Length;
    }
    void Update()
    {
        _storyProgressCounter = CheckAmountOfStoryPartsDiscovered();
        displayText.text = _storyProgressCounter.ToString() + "/" + _storyPartsAmount.ToString();
    }
    int CheckAmountOfStoryPartsDiscovered()
    {
        int temp = 0;
        foreach (GameObject storyPart in storyParts)
        {
            if (storyPart.activeSelf) temp++;
        }
        return temp;
    }
}
