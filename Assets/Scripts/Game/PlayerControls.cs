using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GameObject UIReadingScene;
    private RaycastHit hit;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject UIProgressScene;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private GameObject UIInventoryScene;
    [SerializeField] private GameObject EscapeMenuScene;
    private Inventory inventory;
    private bool isFlashlightOn = false;
    private bool isFlashlightEquipped = false;
    private bool wait = false;
    private GameObject hitGameObject;
    private LanguageManager lang;
    [SerializeField] private AudioSource footstepsSound;
    [SerializeField] private CharacterController controller;
    void Start()
    {
        inventory = GetComponent<Inventory>();
        lang = GameObject.Find("LanguageManager").GetComponent<LanguageManager>();
    }
    void Update()
    {
        KeyHandler();
        FlashLight();
        VisualInteractions();
    }
    void KeyHandler()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(hit.transform.gameObject.name);
            Physics.Raycast(transform.TransformPoint(new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, Camera.main.transform.localPosition.z)), Camera.main.transform.forward, out hit, 1000f);
            //Debug.DrawRay(transform.TransformPoint(new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, Camera.main.transform.localPosition.z)), Camera.main.transform.forward * 100.0f, Color.yellow);
            if (hit.transform.gameObject.tag == "Readable" && !wait)
            {
                DisableEveryScene();
                UI.GetComponent<UIController>().ReadingSceneController.RestartPageNumber(); //Set page number to 1
                Camera.main.GetComponent<MouseLook>().checkMousePosition = false;
                hitGameObject = hit.transform.gameObject;
                if (hit.transform.gameObject.GetComponent<TextToReadData>().pieceOfCharacter != null && !hit.transform.gameObject.GetComponent<TextToReadData>().pieceOfCharacter.activeSelf)
                {
                    wait = true;
                    if (lang.language == Language.English) UI.GetComponent<UIController>().NotificationsController.PopUpNotification("New part of character's story has been discovered."); //ENG
                    if (lang.language == Language.Polish)  UI.GetComponent<UIController>().NotificationsController.PopUpNotification("Nowa czêœæ historii postaci zosta³a odkryta."); //PL
                    hit.transform.gameObject.GetComponent<TextToReadData>().SpawnParticle();
                    StartCoroutine("ReadingSceneDelayed");
                }
                else
                {
                    ReadingScene();
                }

            }
            if (hit.transform.gameObject.tag == "Openable")
            {
                hit.transform.gameObject.GetComponent<DrawerHandler>().ChangeStateOfDrawer();
            }
            if(hit.transform.gameObject.tag == "Getable")
            {
                GameObject hittedObject = hit.transform.gameObject;
                inventory.AddElementToInventory(hittedObject.GetComponent<Text>().text);
                if (lang.language == Language.English) UI.GetComponent<UIController>().NotificationsController.PopUpNotification(hittedObject.GetComponent<Text>().text + " has been picked up."); //ENG
                if (lang.language == Language.Polish) UI.GetComponent<UIController>().NotificationsController.PopUpNotification(hittedObject.GetComponent<Text>().text + " zosta³/a podniesiony.");//PL
                if (hit.transform.gameObject.name == "Flashlight") isFlashlightEquipped = true;
                Destroy(hit.transform.gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isFlashlightEquipped)
            {
                flashlight.SetActive(!isFlashlightOn);
                isFlashlightOn = !isFlashlightOn;
            }
            else
            {
                if (lang.language == Language.English) UI.GetComponent<UIController>().NotificationsController.PopUpNotification("Flashlight is not equipped"); //ENG
                if (lang.language == Language.Polish) UI.GetComponent<UIController>().NotificationsController.PopUpNotification("Nie posiadasz latarki");//PL
            }
            
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            DisableEveryScene();
            UIProgressScene.SetActive(true);
            Camera.main.GetComponent<MouseLook>().checkMousePosition = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            DisableEveryScene();
            UIInventoryScene.SetActive(true);
            Camera.main.GetComponent<MouseLook>().checkMousePosition = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CheckIfAnySceneIsActive())
            {
                GoBackToGameFromScene();
            }
            else
            {
                EscapeMenuScene.SetActive(true);
                Camera.main.GetComponent<MouseLook>().checkMousePosition = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        if (controller.velocity == Vector3.zero && footstepsSound.isPlaying == true)
        {
            footstepsSound.Stop();
        }
        if (controller.velocity != Vector3.zero && footstepsSound.isPlaying == false)
        {
            footstepsSound.Play();
        }

    }
    public void GoBackToGameFromScene()
    {
        DisableEveryScene();
        Camera.main.GetComponent<MouseLook>().checkMousePosition = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void VisualInteractions()
    {
        Physics.Raycast(transform.TransformPoint(new Vector3(Camera.main.transform.localPosition.x, Camera.main.transform.localPosition.y, Camera.main.transform.localPosition.z)), Camera.main.transform.forward, out hit, 1000f);
        if(hit.transform.gameObject.tag != null && hit.transform.gameObject.tag == "VisualInteraction")
        {
            hit.transform.gameObject.GetComponent<VisualInteraction>().VisualInteractionWithThisObject();
        }
    }
    bool CheckIfAnySceneIsActive()
    {
        if (UIProgressScene.activeSelf) return true;
        if (UIReadingScene.activeSelf) return true;
        if (UIInventoryScene.activeSelf) return true;
        if (EscapeMenuScene.activeSelf) return true;
        return false;
    }
    void DisableEveryScene()
    {
        UIReadingScene.SetActive(false);
        UIProgressScene.SetActive(false);
        UIInventoryScene.SetActive(false);
        EscapeMenuScene.SetActive(false);
    }
    IEnumerator ReadingSceneDelayed()
    {
        
        for (int i = 0; i< 3; i++)
        {
            if(i == 2)
            {
                ReadingScene();
                wait = false;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    void ReadingScene()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        UIReadingScene.SetActive(true);
        UIReadingScene.transform.Find("TextToRead").gameObject.GetComponent<TextMeshProUGUI>().text = hitGameObject.GetComponent<TextToReadData>().textToRead.text;
        UI.GetComponent<UIController>().ReadingSceneController.maxPageNumber = hitGameObject.GetComponent<TextToReadData>().PageAmount;
        UI.GetComponent<UIController>().ReadingSceneController.SetPageNumber();
        if(hit.transform.gameObject.GetComponent<TextToReadData>().pieceOfCharacter != null) hitGameObject.GetComponent<TextToReadData>().WhileReadingTheText();
    }
    void FlashLight()
    {
        if (!isFlashlightOn) return;
        flashlight.transform.position = Camera.main.transform.position;
        flashlight.transform.rotation = Camera.main.transform.rotation;
    }
    public void ShutDownReadingMode()
    {
        Camera.main.GetComponent<MouseLook>().checkMousePosition = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UIReadingScene.SetActive(false);
    }
}
