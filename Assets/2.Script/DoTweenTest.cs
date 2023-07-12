using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DoTweenTest : MonoBehaviour
{
    [SerializeField] private Image testImg = null;

    private void Start()
    {
        testImg.DOColor(Color.red, 3);
        testImg.transform.DOMoveX(0, 2);
        testImg.transform.DOMoveY(0, 2);
    }
}
