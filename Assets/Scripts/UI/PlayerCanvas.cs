using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCanvas : MonoBehaviour
{
    public InputActionProperty MenuInput;
    public GameObject SettingsMenu;

    private void OnEnable()
    {
        MenuInput.action.performed += ShowSettingsMenu;
    }

    private void OnDisable()
    {
        MenuInput.action.performed += ShowSettingsMenu;
    }

    private void ShowSettingsMenu(InputAction.CallbackContext context)
    {
        SettingsMenu.SetActive(true);
    }
}
