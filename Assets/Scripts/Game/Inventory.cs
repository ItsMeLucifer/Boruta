using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<string> inventory = new List<string>();
    [SerializeField] private GameObject UIInventoryDisplay;
    [SerializeField] private GameObject inventoryItemPrefab;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void AddElementToInventory(string elementName)
    {
        inventory.Add(elementName);
        GameObject inventoryItem = Instantiate(inventoryItemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        inventoryItem.transform.SetParent(UIInventoryDisplay.transform);
        inventoryItem.transform.Find("Text").GetComponent<Text>().text = elementName;
        inventoryItem.name = elementName;
        inventoryItem.transform.localScale = new Vector3(1f, 1f, 1f);
        inventoryItem.transform.localPosition = Vector3.zero;
        inventoryItem.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    public void DeleteElementFromInventory(string elementName)
    {
        if (!inventory.Contains(elementName)) return;
        inventory.Remove(elementName);
        Destroy(UIInventoryDisplay.transform.Find(elementName).gameObject);
    }
}
