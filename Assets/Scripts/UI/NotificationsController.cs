using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationsController : MonoBehaviour
{
    [SerializeField] private GameObject NotificationsArea;
    [SerializeField] private GameObject NotificationPrefab;
    public void PopUpNotification(string message)
    {
        GameObject notification = Instantiate(NotificationPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        notification.transform.SetParent(NotificationsArea.transform);
        notification.GetComponent<NotificationScript>().SetNotificationsMessage(message);
        notification.transform.localScale = new Vector3(1f,1f,1f);
        notification.transform.localPosition = Vector3.zero;
        notification.transform.localRotation = Quaternion.Euler(0,0,0);
    }
}
