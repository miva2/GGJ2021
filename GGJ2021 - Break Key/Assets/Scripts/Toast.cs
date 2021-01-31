using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toast : MonoBehaviour
{
    public const float SHORT_DURATION = 3.000f;
    public const float LONG_DURATION = 5.000f;

    private Text textComponent;

    private void Start()
    {
        textComponent = GetComponent<Text>();
    }

    public void ShowToast(string message, float duration = SHORT_DURATION)
    {
        textComponent.text = message;
        gameObject.SetActive(true);
        //disable textcomponent after duration, using coroutine probably
        StartCoroutine(DisableToast(duration));
    }

    private IEnumerator DisableToast(float duration)
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }

}
