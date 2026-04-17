using UnityEngine;
using UnityEngine.InputSystem;
public class GameController : MonoBehaviour
{
    private PlayerInput playerInput;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TouchScreen(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            playerInput.actions["TouchPosition"].ReadValue<Vector2>();
        }
    }
}
