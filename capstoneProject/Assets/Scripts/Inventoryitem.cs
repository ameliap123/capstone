using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventoryitem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;

    [HideInInspector] public Transform parentAfterDrag; //makes background behind

    //Drag item and drop item
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false; //see if we have slot to drop item
        parentAfterDrag=transform.parent; //makes so object is placed on top of background
        transform.SetParent(transform.root);
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition; //follows mouse when dragging
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true; //see if we have slot to drop item
        transform.SetParent(parentAfterDrag); //parent is reverted after drop
    }
}
