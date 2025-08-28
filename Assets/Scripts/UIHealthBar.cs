using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIHealthBar : MonoBehaviour
{
    // getはできるが、setはできない
    public static UIHealthBar instance { get; private set; }
    public Image mask;
    float originalSize;

    void Awake()
    {
        // はじめにinstanceに自分自身を登録している
        instance = this;
    }


    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }


    public void SetValue(float value)
    {
        // mask.rectTransform.SetSizeWithCurrentAnchors(
        // RectTransform.Axis.Horizontal, originalSize * value);

        // １秒かけてHPゲージが変化する
        DOTween.To(
            () => mask.rectTransform.rect.width,
             x => mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, x),
              originalSize * value,
              1f);
    }
}
