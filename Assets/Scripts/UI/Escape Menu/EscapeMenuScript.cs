using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
public class EscapeMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject _motionBlur, _depthOfField;
    [SerializeField] private PostProcessLayer _postProcessLayer;
    void Start()
    {
        
    }
    public void triggerMotionBlur()
    {
        _motionBlur.SetActive(!_motionBlur.activeSelf);
    }
    public void triggerDepthOfField()
    {
        _depthOfField.SetActive(!_depthOfField.activeSelf);
    }
    public void setAntiAliasing(int number)
    {
        switch (number)
        {
            case 0:
                _postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.None;
                break;
            case 1:
                _postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
                break;
            case 2:
                _postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
                break;
            case 3:
                _postProcessLayer.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
                break;
            default:
                break;
        }
    }
    public void setGraphicsQuality(int number)
    {
        QualitySettings.SetQualityLevel(number);
    }
    public void setFullScreenMode(int number)
    {
        switch (number)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 3:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            default:
                break;
        }
    }
    public void goToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
