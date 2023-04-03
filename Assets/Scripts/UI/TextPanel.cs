using UnityEngine;

public class TextPanel : MonoBehaviour
{
    public Transform PlayerCamera;

    private void Update()
    {
        gameObject.transform.LookAt(PlayerCamera);
        gameObject.transform.Rotate(Vector3.up, 90);
    }
}
