using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertObservers : MonoBehaviour
{
    [SerializeField] private Animator nameAnimator;
    [SerializeField] private Animator descriptionAnimator;
    [SerializeField] private GameObject continueButton;
    public void SHOWNAME()
    {
        nameAnimator.SetBool("start", true);
        descriptionAnimator.SetBool("start", true);
    }
    public void ShowContinueButton()
    {
        if(continueButton != null) continueButton.SetActive(true);
    }
}
