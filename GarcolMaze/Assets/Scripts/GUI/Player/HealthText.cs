using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    public float timeToLive = 0.5f;
    public float floatSpeed = 32;
    private TextMeshProUGUI textMesh;
    RectTransform rectTransform;

    private Vector3 floatDirection = new Vector3(0, 1, 0);

    private float timeElapsed = 0.0f;
    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
        color = textMesh.color;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        rectTransform.position += floatDirection * floatSpeed * Time.deltaTime;
        textMesh.color = new Color(color.r, color.g, color.b, 1 - (timeElapsed / floatSpeed));
        if (timeElapsed > timeToLive)
		{
            Destroy(gameObject);
		}
    }
}
