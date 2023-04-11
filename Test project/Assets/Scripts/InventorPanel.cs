using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorPanel : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private RectTransform itemPanel;
    private List<GameObject> existingItems = new();

    // Start is called before the first frame update
    private void Start()
    {
        Refresh();
        GlobalEventManager.OnInventoryChanged += Refresh;
    }

    private void Refresh()
    {
        ClearPanel();

        for (int i = 0; i < inventory.items.Count; i++)
        {

            var item = inventory.items[i];
            var slot = new GameObject("Slot for " + item.name);
            slot.AddComponent<ItemSlot>();
            slot.AddComponent<Image>().color = new Color32(196, 255, 0, 255);
            slot.transform.SetParent(itemPanel);
            slot.transform.localScale = new Vector3(1, 1, 1);


            var icon = new GameObject(item.name);
            icon.AddComponent<Image>().sprite = item.sprite;
            icon.AddComponent<DragDrop>();
            icon.transform.SetParent(slot.transform);
            icon.transform.localScale = icon.transform.parent.localScale / 2;

            var text = new GameObject(item.name + " Amount");
            text.AddComponent<TextMeshPro>();
            if (item.amount == 1)
                text.GetComponent<TextMeshPro>().text = " ";
            if (item.amount > 1)
                text.GetComponent<TextMeshPro>().text = item.amount.ToString();
            text.GetComponent<TextMeshPro>().color = Color.red;
            text.GetComponent<TextMeshPro>().fontSize = 250;
            text.transform.SetParent(icon.transform);
            text.GetComponent<RectTransform>().localScale = gameObject.transform.GetComponentInParent<RectTransform>().localScale;
            text.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.TopRight;

            existingItems.Add(slot);
        }
    }

    private void ClearPanel()
    {
        for (int i = 0; i < existingItems.Count; i++)
        {
            Destroy(existingItems[i]);
        }
    }
}
