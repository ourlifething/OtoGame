using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgementEffect : MonoBehaviour
{
    // 文字の変更を行うGood,Badなど
    [SerializeField] Text text;

    public void SetText(string message)
    {
        text.text = message;
        StartCoroutine(MoveUp());
        switch (message)
        {
            case "Excellent":
                text.color = Color.red;
                break;
            case "Good":
                text.color = Color.yellow;
                break;
            case "Bad":
                text.color = Color.blue;
                break;
        }
    }

    IEnumerator MoveUp()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(0, 0.5f, 0);
        }
        Destroy(gameObject);
    }
}
