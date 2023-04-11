using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    private void Awake()
    {
        Load();
    }

    public void Save()
    {
        SaveData savedata = new();
        BinaryFormatter bf = new();
        FileStream file = File.Create(Application.persistentDataPath + "/MyData.dat");

        var gameobjectToSave = FindObjectOfType<Inventory>();
        List<Item> savingListItems = gameobjectToSave.GetItems();


        for (int i = 0; i < savingListItems.Count; i++)
        {
            ItemData itemData = new()
            {
                itemClass = (int)savingListItems[i].itemClass,
                itemName = savingListItems[i].itemName,
                itemWeight = savingListItems[i].itemWeight,
                isStackable = savingListItems[i].isStackable,
                stackCaptivity = savingListItems[i].stackCaptivity,
                amount = savingListItems[i].amount
            };
            savedata.items.Add(itemData);
        }

        savedata.captivity = gameobjectToSave.GetCaptivity();
        savedata.priceForUpgrade = gameobjectToSave.GetPriceForUpgrade();
        savedata.money = gameobjectToSave.GetMoney();

        bf.Serialize(file, savedata);
        file.Close();
        Debug.Log("Данные успешно сохранены!");
    }

    private void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/MyData.dat"))
        {
            BinaryFormatter bf = new();
            FileStream file = File.Open(Application.persistentDataPath + "/MyData.dat", FileMode.Open);
            SaveData savedata = (SaveData)bf.Deserialize(file); 
            var gameobjectToLoadItems = FindObjectOfType<Inventory>();

            for (int i = 0; i < savedata.items.Count; i++)
            {
                switch (savedata.items[i].itemClass)
                {
                    case (int)ItemClass.Pistol:
                        var pistol = ScriptableObject.CreateInstance<Gun>();
                        pistol.name = "Pistol";
                        pistol.itemClass = (ItemClass)savedata.items[i].itemClass;
                        pistol.sprite = Resources.Load("Assets/Items/Sprites/ammo1.png") as Sprite;
                        pistol.itemName = savedata.items[i].itemName;
                        pistol.itemWeight = savedata.items[i].itemWeight;
                        pistol.isStackable = savedata.items[i].isStackable;
                        pistol.stackCaptivity = savedata.items[i].stackCaptivity;
                        pistol.amount = savedata.items[i].amount;
                        gameobjectToLoadItems.items.Add(pistol);
                        break;
                    case (int)ItemClass.AssaultRifle:
                        var assaultRifle = ScriptableObject.CreateInstance<Gun>();
                        assaultRifle.name = "Assault rifle";
                        assaultRifle.sprite = Resources.Load("Assets/Items/Sprites/assaultRifle") as Sprite;
                        assaultRifle.itemClass = (ItemClass)savedata.items[i].itemClass;
                        assaultRifle.itemName = savedata.items[i].itemName;
                        assaultRifle.itemWeight = savedata.items[i].itemWeight;
                        assaultRifle.isStackable = savedata.items[i].isStackable;
                        assaultRifle.stackCaptivity = savedata.items[i].stackCaptivity;
                        assaultRifle.amount = savedata.items[i].amount;
                        gameobjectToLoadItems.items.Add(assaultRifle);
                        break;
                    case (int)ItemClass.Ammo1:
                        var ammo1 = ScriptableObject.CreateInstance<Ammo>();
                        ammo1.name = "Ammo 1";
                        ammo1.sprite = Resources.Load("Assets/Items/Sprites/ammo1") as Sprite;
                        ammo1.itemClass = (ItemClass)savedata.items[i].itemClass;
                        ammo1.itemName = savedata.items[i].itemName;
                        ammo1.itemWeight = savedata.items[i].itemWeight;
                        ammo1.isStackable = savedata.items[i].isStackable;
                        ammo1.stackCaptivity = savedata.items[i].stackCaptivity;
                        ammo1.amount = savedata.items[i].amount;
                        Debug.Log(ammo1.itemName);
                        break;
                    case (int)ItemClass.Ammo2:
                        var ammo2 = ScriptableObject.CreateInstance<Ammo>();
                        ammo2.name = "Ammo 2";
                        ammo2.itemClass = (ItemClass)savedata.items[i].itemClass;
                        ammo2.itemName = savedata.items[i].itemName;
                        ammo2.itemWeight = savedata.items[i].itemWeight;
                        ammo2.isStackable = savedata.items[i].isStackable;
                        ammo2.stackCaptivity = savedata.items[i].stackCaptivity;
                        ammo2.amount = savedata.items[i].amount;
                        gameobjectToLoadItems.items.Add(ammo2);
                        break;
                    case (int)ItemClass.Cap:
                        var cap = ScriptableObject.CreateInstance<Head>();
                        cap.name = "Cap";
                        cap.itemClass = (ItemClass)savedata.items[i].itemClass;
                        cap.itemName = savedata.items[i].itemName;
                        cap.itemWeight = savedata.items[i].itemWeight;
                        cap.isStackable = savedata.items[i].isStackable;
                        cap.stackCaptivity = savedata.items[i].stackCaptivity;
                        cap.amount = savedata.items[i].amount;
                        gameobjectToLoadItems.items.Add(cap);
                        break;
                    case (int)ItemClass.Helmet:
                        var helmet = ScriptableObject.CreateInstance<Head>();
                        helmet.name = "Helmet";
                        helmet.itemClass = (ItemClass)savedata.items[i].itemClass;
                        helmet.itemName = savedata.items[i].itemName;
                        helmet.itemWeight = savedata.items[i].itemWeight;
                        helmet.isStackable = savedata.items[i].isStackable;
                        helmet.stackCaptivity = savedata.items[i].stackCaptivity;
                        helmet.amount = savedata.items[i].amount;
                        gameobjectToLoadItems.items.Add(helmet);
                        break;
                    case (int)ItemClass.Jacket:
                        var jacket = ScriptableObject.CreateInstance<Body>();
                        jacket.name = "Jacket";
                        jacket.itemClass = (ItemClass)savedata.items[i].itemClass;
                        jacket.itemName = savedata.items[i].itemName;
                        jacket.itemWeight = savedata.items[i].itemWeight;
                        jacket.isStackable = savedata.items[i].isStackable;
                        jacket.stackCaptivity = savedata.items[i].stackCaptivity;
                        jacket.amount = savedata.items[i].amount;
                        gameobjectToLoadItems.items.Add(jacket);
                        break;
                    case (int)ItemClass.BulletproofArmor:
                        var bulletproofArmor = ScriptableObject.CreateInstance<Body>();
                        bulletproofArmor.name = "Bulletproof armor";
                        bulletproofArmor.itemClass = (ItemClass)savedata.items[i].itemClass;
                        bulletproofArmor.itemName = savedata.items[i].itemName;
                        bulletproofArmor.itemWeight = savedata.items[i].itemWeight;
                        bulletproofArmor.isStackable = savedata.items[i].isStackable;
                        bulletproofArmor.stackCaptivity = savedata.items[i].stackCaptivity;
                        bulletproofArmor.amount = savedata.items[i].amount;
                        gameobjectToLoadItems.items.Add(bulletproofArmor);
                        break;
                }
            }

            gameobjectToLoadItems.SetCaptivity(savedata.captivity);
            gameobjectToLoadItems.SetPriceForUpgrade(savedata.priceForUpgrade);
            gameobjectToLoadItems.SetMoney(savedata.money);

            file.Close();
            Debug.Log("Данные загружены!");
        }
        else
            Debug.Log("Нет данных!");
    }
}