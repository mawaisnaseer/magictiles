using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TouchHandler : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnMouseDown()
    {
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("on mouse down");
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            print("ray hit "+hit.collider.name);
        }
    }
}
