using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatDialog : MonoBehaviour
{
	public float timeToLive = 0.5f;
	public float floatSpeed = 16;

	private float timeElapsed = 0.0f;
	private Vector3 floatDirection = new Vector3(0, 1, 0);
	RectTransform rectTransform;

	private void Start()
	{
        rectTransform = GetComponent<RectTransform>();
	}

	private void Update()
	{
		timeElapsed += Time.deltaTime;
		rectTransform.position += floatDirection * floatSpeed * Time.deltaTime;
		if (timeElapsed > timeToLive)
		{
			floatDirection *= -1;
			timeElapsed = 0.0f;
		}
	}
}
