using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public ReadingSceneController ReadingSceneController;
    public NotificationsController NotificationsController;
    private void Start()
    {
        ReadingSceneController.SetPageNumber();
    }
    private void Update()
    {
        
    }
    public void DestroyObject(GameObject objectToDestroy)
    {
        Destroy(objectToDestroy);
    }
    
}
