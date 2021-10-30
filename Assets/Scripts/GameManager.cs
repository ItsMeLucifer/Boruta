using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] allStoryParts;
    [SerializeField] private GameObject lastDoorToOpens;
    [SerializeField] private UIController UIController;
    bool done = false;
    private LanguageManager lang;
    void Start()
    {
        lang = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
    }
    void Update()
    {
        if (CheckIfAllPartsWereDiscovered() && !done)
        {
            if (lang.language == Language.Polish) UIController.NotificationsController.PopUpNotification("Odkryto wszystkie czêœci historii. Drzwi zosta³y otwarte");
            if (lang.language == Language.English) UIController.NotificationsController.PopUpNotification("All parts of the story have been uncovered. Doors have been opened");
            Destroy(lastDoorToOpens);
            done = true;
        }
    }

    bool CheckIfAllPartsWereDiscovered() {
        int temp = 0;
        foreach(GameObject storyPart in allStoryParts)
        {
            if (storyPart.activeSelf) temp++;
        }
        return temp == allStoryParts.Length;
    }
}
