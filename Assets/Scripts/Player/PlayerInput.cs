using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const int _leftClickIndex = 0;

    public bool GetAttackInput()
    {
        return Input.GetMouseButtonDown(_leftClickIndex);
    }
}
