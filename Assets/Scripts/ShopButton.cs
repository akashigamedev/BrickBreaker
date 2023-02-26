using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI text;
    [SerializeField] GameObject imageObj;
    public ItemSO item;

    public void UpdateText(string updatedText)
    {
        text.text = updatedText;
    }

    public void SetImageObjectActive(bool value)
    {
        imageObj.SetActive(value);
    }
}
