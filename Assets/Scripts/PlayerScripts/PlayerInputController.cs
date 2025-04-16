using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerController
{
    private void OnMove(InputValue value)
    {
        Vector3 playerInput = new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y, 0);
        currentInput = playerInput;
    }

    private void OnLook(InputValue value)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
        LookAt(mousePosition);
    }

    private void OnShoot()
    {
        Shoot();
    }

}
