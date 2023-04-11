using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Item> itemsToAdd;
    public List<Item> items = new();
    [SerializeField] private int captivity = 15;
    [SerializeField] private int priceForUpgrade;
    [SerializeField] private int money;

    public void UpgradeTo30Slots()
    {
        if (money >= priceForUpgrade)
        {
            captivity = 30;
            money -= priceForUpgrade;
        }
        else
        {
            Debug.Log("Недостаточо средств!");
        }
    }

    public void Shoot()
    {
        List<int> ammoIndex = new();
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] is Ammo)
            {
                ammoIndex.Add(i);
            }
        }

        if (ammoIndex.Count == 0)
        {
            Debug.Log("А патронов-то нет!");
        }
        else
        {
            int randomNumber = Random.Range(0, ammoIndex.Count);
            int deleteNumber = ammoIndex[randomNumber];
            Debug.Log(ammoIndex.Count);

            if (items[deleteNumber].amount != 0)
                items[deleteNumber].amount--;
        }
        GlobalEventManager.SendInventoryChanged();
    }

    public void AddAmmo()
    {
        List<int> ammoIndex = new();
        for (int i = 0; i < itemsToAdd.Count; i++)
        {
            if (itemsToAdd[i] is Ammo)
                ammoIndex.Add(i);
        }

        List<int> itemsAmmoNumber = new();
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] is Ammo)
                itemsAmmoNumber.Add(i);
        }

        if (itemsAmmoNumber.Count == 0)
        {
            for (int i = 0; i < ammoIndex.Count; i++)
            {
                items.Add(itemsToAdd[i]);
                itemsToAdd[i].amount = itemsToAdd[i].stackCaptivity;
            }
        }
        else
        {
            // TODO: Переписать на добавление нового стака без патронов

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is Ammo)
                {
                    items[i].amount = items[i].stackCaptivity;
                }

            }
        }

        GlobalEventManager.SendInventoryChanged();
    }
    public void AddItem()
    {
        if (items.Count >= captivity)
        {
            Debug.Log("Не хвататет свободного места. Купите дополнительный слот.");
            return;
        }
        List<Gun> gunList = new();
        List<Clothes> headList = new();
        List<Clothes> bodyList = new();

        for (int i = 0; i < itemsToAdd.Count; i++)
        {
            switch (itemsToAdd[i])
            {
                case (Gun):
                    gunList.Add((Gun)itemsToAdd[i]);
                    break;
                case (Body):
                    bodyList.Add((Clothes)itemsToAdd[i]);
                    break;
                case (Head):
                    headList.Add((Clothes)itemsToAdd[i]);
                    break;
            }
        }
        if (items.Count != captivity)
            items.Add(gunList[Random.Range(0, gunList.Count)]);
        if (items.Count != captivity)
            items.Add(bodyList[Random.Range(0, bodyList.Count)]);
        if (items.Count != captivity)
            items.Add(headList[Random.Range(0, headList.Count)]);

        GlobalEventManager.SendInventoryChanged();
    }

    public void DeleteItem()
    {
        if (items.Count == 0)
        {
            Debug.LogError("Ваш инвентарь пуст");
            return;
        }
        int randomNumber = Random.Range(0, items.Count);
        items.RemoveAt(randomNumber);
        GlobalEventManager.SendInventoryChanged();
    }

    public List<Item> GetItemsToAdd()
    {
        return itemsToAdd;
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public int GetCaptivity()
    {
        return captivity;
    }

    public int GetPriceForUpgrade()
    {
        return priceForUpgrade;
    }

    public int GetMoney()
    {
        return money;
    }

    public void AddToItemsToAdd(Item item)
    {
        itemsToAdd.Add(item);
    }

    public void SetItemsToAdd(List<Item> items)
    {
        itemsToAdd = items;
    }

    public void SetItems(List<Item> items)
    {
        this.items = items;
    }

    public void SetCaptivity(int captivity)
    {
        this.captivity = captivity;
    }

    public void SetPriceForUpgrade(int priceForUpgrade)
    {
         this.priceForUpgrade = priceForUpgrade;
    }

    public void SetMoney(int money)
    {
         this.money = money;
    }
}