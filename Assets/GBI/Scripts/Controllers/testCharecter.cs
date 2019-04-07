using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCharecter : MonoBehaviour
{
    public float speed = 5;
    private CharacterController _characterController;
    void Start()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        _characterController.Move(new Vector3(-Input.GetAxis("Vertical"),0,Input.GetAxis("Horizontal")) * speed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "Treasure(Clone)")
        {
            Destroy(hit.gameObject);
        }
    }
}
