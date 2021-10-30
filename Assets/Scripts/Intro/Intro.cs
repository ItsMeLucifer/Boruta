using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    private GameObject secondBoard, thirdBoard;
    void Start()
    {
        secondBoard = GameObject.Find("SecondBoard");
        thirdBoard = GameObject.Find("ThirdBoard");
    }

    public void ChangeBoard(int number)
    {
        switch (number)
        {
            case 2:
                secondBoard.transform.SetAsLastSibling();
                secondBoard.transform.Find("Image").GetComponent<Animator>().SetBool("start", true);
                break;
            case 3:
                thirdBoard.transform.SetAsLastSibling();
                thirdBoard.transform.Find("Image").GetComponent<Animator>().SetBool("start", true);
                break;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
