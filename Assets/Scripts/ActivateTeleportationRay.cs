using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject LeftTeleportation;
    public GameObject RightTeleportation;

    public InputActionProperty LeftActivate;
    public InputActionProperty RightActivate;

    private void Update()
    {
        LeftTeleportation.SetActive(LeftActivate.action.ReadValue<float>() > 0.1f);
        RightTeleportation.SetActive(RightActivate.action.ReadValue<float>() > 0.1f);
    }
}
