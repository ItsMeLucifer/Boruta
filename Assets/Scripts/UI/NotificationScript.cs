using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationScript : MonoBehaviour
{
    private bool fadeOut, fadeIn;
    float fadeSpeed = 2f;
    void Start()
    {
        FadeInObject();
        StartCoroutine("DestroyMyself");
    }
    IEnumerator DestroyMyself()
    {
        for(int i = 0; i<8; i++)
        {
            if (i == 7)
            {
                FadeOutObject();
            }
            yield return new WaitForSeconds(1f);
        }
    }
    void Update()
    {
        if (fadeOut)
        {
            Color objectColor = GetComponent<Image>().color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            GetComponent<Image>().color = objectColor;
            transform.Find("Text").GetComponent<Text>().color = objectColor;

            if (objectColor.a <= 0)
            {
                fadeOut = false;
                Destroy(gameObject);
            }
        }
        if (fadeIn)
        {
            Color objectColor = GetComponent<Image>().color;
            float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            GetComponent<Image>().color = objectColor;
            transform.Find("Text").GetComponent<Text>().color = objectColor;

            if (objectColor.a >= 1)
            {
                fadeIn = false;
            }
        }
    }
    void FadeOutObject()
    {
        fadeOut = true;
    }
    void FadeInObject()
    {
        fadeIn = true;
    }
    public void SetNotificationsMessage(string message)
    {
        transform.Find("Text").gameObject.GetComponent<Text>().text = message;
    }
}
