using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharactersExplanationUI : MonoBehaviour
{
    [SerializeField] private GameObject finalNote;
    void Start()
    {
        
    }

    public void ShowFinalNote()
    {
        finalNote.transform.SetAsLastSibling();
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
