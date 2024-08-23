using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    private const int _leftClickIndex = 0;
    
    public bool IsActive = false;

    public void SetInputActive(bool status)
    {
        IsActive = status;
    }
    
    public bool GetAttackInput()
    {
        if (IsActive && Input.GetMouseButtonDown(_leftClickIndex) && !IsPointerOverUIObject())
        {
            return true;
        }
        return false;
    }
    
    private bool IsPointerOverUIObject()
    {
        PointerEventData currentMousePosition = new PointerEventData(EventSystem.current);
        currentMousePosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(currentMousePosition, results);
        return results.Count > 0;
    }
}
