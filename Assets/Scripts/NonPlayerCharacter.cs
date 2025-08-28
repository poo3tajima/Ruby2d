using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class NonPlayerCharacter : MonoBehaviour
{
    public float displayTime = 4f;
    GameObject dialogBox;
    float timerDisplay;
    RectTransform rt;
    TextMeshProUGUI tm;
    string msg;


    void Start()
    {
        // 最初の子要素を取得
        dialogBox = transform.GetChild(0).gameObject;
        rt = dialogBox.GetComponent<RectTransform>();
        rt.localScale = Vector3.zero;
        tm = dialogBox.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        msg = tm.text;
        tm.text = "";
        dialogBox.SetActive(false);
        timerDisplay = -1f;
    }


    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;

            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
                rt.localScale = Vector3.zero;
                tm.text = "";
            }
        }
    }


    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);

        rt.DOScale(0.01f, 0.6f).SetEase(Ease.OutBack);
        tm.DOText(msg, 3f).SetDelay(0.8f);
    }
}