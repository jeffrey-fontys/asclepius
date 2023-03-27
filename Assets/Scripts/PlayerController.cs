using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Yarn.Unity;

public class PlayerController : MonoBehaviour
{
    public ProgressManager ProgressManager;
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

        HeldItem = item;
        _handItem = Instantiate(item.gameObject, CarryingHand, false);
        HeldItem.gameObject.SetActive(false);
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
