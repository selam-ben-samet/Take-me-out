using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    // Reference to the crosshair RectTransform component
    [SerializeField] private RectTransform crosshairRectTransform;

    void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position to a position relative to the canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            crosshairRectTransform.parent as RectTransform,
            mousePosition,
            null,
            out Vector2 localPoint
        );

        // Set the position of the crosshair to the calculated position
        crosshairRectTransform.localPosition = localPoint;
    }
}