using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    public ProgressManager ProgressManager;
    public VariableStorageBehaviour VariableStorage;
    public ItemPickup HeldItem { get; private set; }

    public void PickupItem(ItemPickup item)
    {
        if (HeldItem != null)
        {
            HeldItem.gameObject.SetActive(true);
        }

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
}
