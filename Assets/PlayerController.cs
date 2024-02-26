using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    [Header("Movement Settings")]
    [SerializeField] private float speed;
    
    [SerializeField] private float _turnSpeed = 1000;
    private Vector2 move;
    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        LookAtMouse();
    }

    public void movePlayer()
    {
        Vector3 movement = new Vector3(move.x , 0f , move.y);

        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
    void LookAtMouse()
    {
        // Raycast from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Calculate the relative direction from the player position to the mouse position
            Vector3 relative = hit.point - transform.position;
            relative.y = 0; // Set the y-component to zero to keep the rotation on the same plane

            // Rotate the player towards the relative direction
            Quaternion rotation = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _turnSpeed * Time.deltaTime);
        }
    }
}