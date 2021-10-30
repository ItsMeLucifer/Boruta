using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UponEnterTheRoom : MonoBehaviour
{
    [SerializeField] private DrawerHandler door;
    [SerializeField] private GameObject secondCollider;
    public bool triggered = false;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    IEnumerator CloseTheDoor()
    {
        yield return new WaitForSeconds(1f);
        if (door.isOpen)
        {
            door.ChangeStateOfDrawer();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            triggered = true;
            if (secondCollider.GetComponent<UponEnterTheRoom>().triggered == true)
            {
                StartCoroutine("CloseTheDoor");
                secondCollider.GetComponent<UponEnterTheRoom>().triggered = false;
            }
        }
    }
}
