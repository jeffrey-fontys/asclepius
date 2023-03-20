using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public TreatmentPlan TreatmentPlan;
    public GameObject HeldItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickupItem(GameObject gameObject)
    {
        if (HeldItem != null) HeldItem.SetActive(true);

        HeldItem = gameObject;
        HeldItem.SetActive(false);
    }

    public void UseItem()
    {
        if (!HeldItem) return;
    }
}
