using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;

    void Update()
    {
        GatherInput();
        LookAtMouse();
    }

    void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
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

    void Move()
{
    Vector3 movement = transform.forward * _input.z + transform.right * _input.x;
    _rb.MovePosition(transform.position + movement.normalized * _speed * Time.deltaTime);
}
}