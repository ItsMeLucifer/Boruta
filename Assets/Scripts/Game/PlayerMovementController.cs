using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovementController : MonoBehaviour
{
    CharacterController controller;
    float playerSpeed = 3f;

    Transform groundCheck;
    float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start(){
        controller = GetComponent<CharacterController>();
        groundCheck = transform.Find("GroundCheck");
    }
    void Update()
    {
        //Y
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        //Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * playerSpeed * Time.deltaTime);
        //CheckGround
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "PortalToOutro")
        {
            Debug.Log("Chuj");
            SceneManager.LoadScene(2);
        }
    }
}
