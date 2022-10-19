using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorMovement : MonoBehaviour, IPointerClickHandler
{
    public Vector3 closePosition;
    public Vector3 openPosition;

    public bool isOpen;

    float duration = 5;

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleDoor();
    }

    public bool ToggleDoor()
    {
        StopAllCoroutines();
        if (isOpen)
        {
            transform.position = closePosition;
            //StartCoroutine(MoveDoor(closePosition));
        }
        else
        {
            transform.position = openPosition;
            //StartCoroutine(MoveDoor(openPosition));
        }
        isOpen = !isOpen;
        return isOpen;
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
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

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
    }
}
