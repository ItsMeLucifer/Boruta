using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TypeOfObject{
    Drawer,
    Cabinet,
    Door
}
public class DrawerHandler : MonoBehaviour
{
    public bool isOpen = false;
    public bool isLocked = false;
    public string keyName;
    [SerializeField] private TypeOfObject typeOfThisObject = TypeOfObject.Drawer;
    private Inventory inventory;
    [SerializeField] private Animator animator;
    void Start()
    {
        inventory = GameObject.Find("Character").GetComponent<Inventory>();
        if(typeOfThisObject != TypeOfObject.Door)
        {
            animator = GetComponent<Animator>();
        }
    }
    void Update()
    {
        
    }
    public void ChangeStateOfDrawer()
    {
        if (isLocked)
        {
            if (isOpen) return;
            if (!inventory.inventory.Contains(keyName))
            {
                GameObject.Find("SoundManager").GetComponent<SoundManagerScript>().PlaySound("locked");
                return;
            }
            inventory.DeleteElementFromInventory(keyName);
            isLocked = false;
        }

        GameObject.Find("SoundManager").GetComponent<SoundManagerScript>().PlaySound(AudioChooser());
        animator.SetBool("open", !isOpen);
        isOpen = !isOpen;
    }
    private string AudioChooser()
    {
        switch (typeOfThisObject)
        {
            case TypeOfObject.Drawer:
                return "drawer";
            case TypeOfObject.Cabinet:
                return "cabinet";
            case TypeOfObject.Door:
                if (isOpen) return "door_close";
                return "door_open";
            default:
                return "";
        }
    }
}
