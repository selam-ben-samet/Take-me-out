using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 1000;
    [SerializeField] private Transform player;
    [SerializeField] private RectTransform crosshairImage;
    
   
    void Awake()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        AimAtMouse();
        
    }
    void AimAtMouse()
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
        player.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _turnSpeed * Time.deltaTime);

        // Project the hit point onto the screen and update crosshair position
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(hit.point);
        crosshairImage.transform.position = screenPoint;
    }
}

    
}
