using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    public ProgressManager ProgressManager;
    public VariableStorageBehaviour VariableStorage;
    public ItemPickup HeldItem { get; private set; }
    public Transform CarryingHand;

    private GameObject _handItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupItem(ItemPickup item)
    {
        if (HeldItem != null)
        {
            HeldItem.gameObject.SetActive(true);
            Destroy(_handItem);
        }

        // Instantiate copy in hand
        _handItem = Instantiate(item.gameObject, CarryingHand, false);
        _handItem.transform.position = CarryingHand.position + new Vector3(0f, -0.03f, 0f);
        _handItem.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        HeldItem = item;
        HeldItem.gameObject.SetActive(false);
        VariableStorage.SetValue("$HeldItem", item.Name);
    }

    [YarnCommand("use_held_item")]
    public void UseHeldItem()
    {
        if (!HeldItem) return;
        ProgressManager.TreatmentAction(HeldItem.TreatmentStep);
    }

    //public static bool HasItem(string name)
    //{
    //    if (HeldItem != null && HeldItem.Name == name) return true;
    //    else return false;
    //}
}
