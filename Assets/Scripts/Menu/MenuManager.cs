using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static AudioClip menuMusic;
    static AudioSource audioSource;
    [SerializeField] private GameObject mainMenuBoard, authorsBoard, howToPlayBoard;
    [SerializeField] private Animator endCredits;
    [SerializeField] private GameObject loadingAnimation;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        menuMusic = Resources.Load<AudioClip>("menu_music");
        audioSource.PlayOneShot(menuMusic);
        loadingAnimation.SetActive(false);
    }

    void Update()
    {
        
    }
    public void GoBackToMenuBoard()
    {
        mainMenuBoard.transform.SetAsLastSibling();
        endCredits.SetBool("start", false);
    }
    public void GoToAuthorsBoard()
    {
        authorsBoard.transform.SetAsLastSibling();
        endCredits.SetBool("start", true);
    }
    public void howToPlay()
    {
        howToPlayBoard.transform.SetAsLastSibling();
    }
    public void StartGame()
    {
        loadingAnimation.SetActive(true);
        SceneManager.LoadScene(4);
    }
    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
