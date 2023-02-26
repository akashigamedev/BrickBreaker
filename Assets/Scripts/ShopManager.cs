using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    public event EventHandler OnCoinUpdate;
    public event EventHandler OnButtonPressedSFX;
    [SerializeField] ShopButton[] shopButtons;

    void Start()
    {
        LoadButtonsState();
        foreach (ShopButton shopButton in shopButtons)
        {
            UpdateButtonUI(shopButton);
        }

    }

    void SaveButtonsState()
    {
        List<SerializableItemState> itemStateList = new List<SerializableItemState>();
        foreach (ShopButton shopButton in shopButtons)
        {
            SerializableItemState item = new SerializableItemState(shopButton.item.itemState);
            itemStateList.Add(item);
        }

        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination))
            file = File.OpenWrite(destination);
        else
            file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, itemStateList);
        file.Close();
    }

    void LoadButtonsState()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination))
            file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not Found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();

        List<SerializableItemState> itemStateList = new List<SerializableItemState>();

        itemStateList = (List<SerializableItemState>)bf.Deserialize(file);
        if (itemStateList != null && itemStateList.Count > 0)
        {
            Debug.Log("Saved file had item state list");
            for (int i = 0; i < itemStateList.Count; i++)
            {
                shopButtons[i].item.itemState = itemStateList[i].itemState;
            }
        }
        file.Close();
    }

    public void OnButtonEventRecieved()
    {
        OnButtonPressedSFX?.Invoke(this, EventArgs.Empty);
        ShopButton shopButton = EventSystem.current.currentSelectedGameObject.GetComponent<ShopButton>();
        UpdateItem(shopButton);
        UpdateButtonUI(shopButton);
        SaveButtonsState();
    }

    void UpdateItem(ShopButton shopButton)
    {
        ItemSO item = shopButton.item;
        switch (item.itemState)
        {
            case ItemState.Locked:
                int price = item.price;
                int coins = PlayerPrefs.GetInt("Coins");
                if (coins >= price)
                {
                    PlayerPrefs.SetInt("Coins", coins - price);
                    OnCoinUpdate?.Invoke(this, EventArgs.Empty);
                    item.itemState = ItemState.Unlocked;
                    Debug.Log("Item Bought");
                    foreach (ShopButton _shopButton in shopButtons)
                    {
                        UpdateButtonUI(_shopButton);
                    }
                }
                else
                {
                    Debug.Log("item too expensive to buy");
                }
                break;
            case ItemState.Unlocked:
                foreach (ShopButton _shopButton in shopButtons)
                {
                    if (_shopButton.item.id != item.id)
                    {
                        // so if they are not the same item
                        if (_shopButton.item.itemType == item.itemType)
                        {
                            if (_shopButton.item.itemState == ItemState.Set)
                            {
                                _shopButton.item.itemState = ItemState.Unlocked;
                                UpdateButtonUI(_shopButton);
                            }
                        }
                    }
                }
                item.itemState = ItemState.Set;
                if (item.itemType == ItemType.Ball)
                    PlayerPrefs.SetString("Ball", item.id);
                if (item.itemType == ItemType.Paddle)
                    PlayerPrefs.SetString("Paddle", item.id);
                Debug.Log("Item was unlocked now it's set");
                break;
            case ItemState.Set:
                Debug.Log("Item Already Set As Default");
                break;
        }
    }

    void UpdateButtonUI(ShopButton shopButton)
    {
        switch (shopButton.item.itemState)
        {
            case ItemState.Locked:
                shopButton.UpdateText(shopButton.item.price.ToString());
                shopButton.SetImageObjectActive(true);
                if (PlayerPrefs.GetInt("Coins") >= shopButton.item.price)
                {
                    shopButton.gameObject.GetComponent<Button>().interactable = true;
                }
                else
                {
                    shopButton.gameObject.GetComponent<Button>().interactable = false;
                }
                break;
            case ItemState.Unlocked:
                shopButton.UpdateText("Use");
                shopButton.SetImageObjectActive(false);
                shopButton.gameObject.GetComponent<Button>().interactable = true;
                break;
            case ItemState.Set:
                shopButton.UpdateText("Set");
                shopButton.SetImageObjectActive(false);
                shopButton.gameObject.GetComponent<Button>().interactable = false;
                break;
        }
    }

}
