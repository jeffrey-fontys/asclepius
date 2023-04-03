using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandItemManager : MonoBehaviour
{
    public InputActionProperty ClipboardInput;
    public InputActionProperty HeldItemInput;
    public PlayerController PlayerController;
    public GameObject Clipboard;
    public Transform HandAttachmentPoint;
    public Transform ItemStaging;
    [Range(0f, 1f)] public float ItemScale = 1f;

    private GameObject _itemCopy;

    private void OnEnable()
    {
        ClipboardInput.action.performed += ShowClipboard;
        ClipboardInput.action.canceled += HideClipboard;

        HeldItemInput.action.performed += ShowHandItem;
        HeldItemInput.action.canceled += HideHandItem;
    }

    private void OnDisable()
    {
        ClipboardInput.action.performed -= ShowClipboard;
        ClipboardInput.action.canceled -= HideClipboard;

        HeldItemInput.action.performed -= ShowHandItem;
        HeldItemInput.action.canceled -= HideHandItem;
    }

    private void ShowClipboard(InputAction.CallbackContext context)
    {
        Clipboard.transform.SetParent(HandAttachmentPoint, false);
    }

    private void HideClipboard(InputAction.CallbackContext context)
    {
        Clipboard.transform.SetParent(ItemStaging, false);
    }

    private void ShowHandItem(InputAction.CallbackContext context)
    {
        if (PlayerController.HeldItem == null) return;

        _itemCopy = Instantiate(PlayerController.HeldItem.gameObject, HandAttachmentPoint, false);
        _itemCopy.transform.localScale = Vector3.one * ItemScale;
        _itemCopy.SetActive(true);
    }

    private void HideHandItem(InputAction.CallbackContext context)
    {
        if (_itemCopy != null) Destroy(_itemCopy);
    }
}
