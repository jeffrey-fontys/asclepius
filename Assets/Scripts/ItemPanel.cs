using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    public Image ItemImage;

    public void UpdateSprite(ItemPickup item)
    {
        ItemImage.sprite = item.Sprite;
    }
}
