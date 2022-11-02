using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextShow{   
    static public void showTextAbove(GameObject obj, GameObject textGUI, string content)
    {
        TextMeshProUGUI textMesh = GameObject.Instantiate(textGUI).GetComponent<TextMeshProUGUI>();
        textMesh.text = content;
        RectTransform textTransform = textMesh.rectTransform;

        textTransform.transform.position = Camera.main.WorldToScreenPoint(obj.transform.position);

        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        textTransform.SetParent(canvas.transform);

    }
}
