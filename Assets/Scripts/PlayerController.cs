using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    public TreatmentPlan TreatmentPlan;
    public ItemPickup HeldItem;

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
        if (HeldItem != null) HeldItem.gameObject.SetActive(true);

        HeldItem = item;
        HeldItem.gameObject.SetActive(false);
    }

    [YarnCommand("use_held_item")]
    public void UseHeldItem()
    {
        if (!HeldItem) return;
        TreatmentPlan.TreatmentAction(HeldItem.TreatmentStep);
    }

    //public static bool HasItem(string name)
    //{
    //    if (HeldItem != null && HeldItem.Name == name) return true;
    //    else return false;
    //}
}
