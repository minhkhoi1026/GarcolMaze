using UnityEditor;
using UnityEngine;
using System.Collections;


public class Moveable : MonoBehaviour
{
    public Vector3 closePosition;
    public Vector3 openPosition;
    public bool isOpen;
    public float duration = 1;

    public bool Toggle()
    {
        StopAllCoroutines();
        if (isOpen)
        {
            StartCoroutine(MoveTo(closePosition));
        }
        else
        {
            StartCoroutine(MoveTo(openPosition));
        }
        isOpen = !isOpen;
        return isOpen;
    }

    protected IEnumerator MoveTo(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = transform.position;
        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    private void Start()
    {
        if (isOpen)
        {
            transform.position = openPosition;
        }
        else
        {
            transform.position = closePosition;
        }
    }
}
