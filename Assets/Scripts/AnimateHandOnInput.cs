using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty PinchAnimationAction;
    public InputActionProperty GripAnimationAction;
    public Animator HandAnimator;

    private void Update()
    {
        float triggerValue = PinchAnimationAction.action.ReadValue<float>();
        float gripValue = GripAnimationAction.action.ReadValue<float>();

        HandAnimator.SetFloat("Trigger", triggerValue);
        HandAnimator.SetFloat("Grip", gripValue);
    }
}
