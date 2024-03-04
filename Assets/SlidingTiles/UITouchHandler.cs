#pragma warning disable 649

using UnityEngine;
using UnityEngine.EventSystems;

// UI Module v0.9.0
public class UITouchHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isMouseDown = false;
    private bool isOneTimeClick;
    [SerializeField] Camera raycastCamera;
    public static bool Enabled { get; set; }

    public static bool CanReplay { get; set; }



    public void OnDrag(PointerEventData eventData)
    {
        if (!isMouseDown) return;

        CanReplay = true;

        isMouseDown = false;

    }

    public void OnPointerDown(PointerEventData eventData)
    {

        // Check if there are any touches
        if (Input.touchCount > 0)
        {
            // Iterate through all active touches
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                // Check if the touch phase is began
                if (touch.phase == TouchPhase.Began)
                {
                    // Perform raycast from the touch position
                    Ray ray = raycastCamera.ScreenPointToRay(touch.position);
                    RaycastHit2D hit1 = Physics2D.Raycast(ray.origin, ray.direction);

                    // Check if the ray hits any object
                    if (hit1.collider != null)
                    {
                        // Handle the hit object (e.g., disable a tile)
                        GameObject hitObject = hit1.collider.gameObject;
                        hitObject.GetComponent<Tiles>()?.DisableTile();
                        Debug.Log("Object clicked: " + hitObject.name);
                    }
                }
            }
        }

#if UNITY_EDITOR
        var hit = Physics2D.Raycast(raycastCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        // Debug.DrawLine(raycastCamera.ScreenToWorldPoint(Input.mousePosition), Vector3.positiveInfinity);
        if (hit)
        {
            if (hit.collider.CompareTag("Tiles"))
            {
                hit.collider.GetComponent<Tiles>().DisableTile();
                Debug.Log("object clicked: " + hit.collider.gameObject.name);
            }
        }
#endif
    }

    public void OnPointerUp(PointerEventData eventData)
    {


    }


}
