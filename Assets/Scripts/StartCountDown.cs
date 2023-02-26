using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCountDown : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI countDownText;
    void OnEnable()
    {
        StartCoroutine(CountDown());

    }

    IEnumerator CountDown()
    {
        for (int i = 3; i > 0; i--)
        {
            countDownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        gameObject.SetActive(false);
    }
}
