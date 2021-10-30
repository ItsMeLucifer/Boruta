using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OutroManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(5);
    }
    public void GoToLastNote()
    {
        SceneManager.LoadScene(3);
    }
}
