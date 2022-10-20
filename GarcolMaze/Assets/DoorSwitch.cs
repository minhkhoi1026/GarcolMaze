using UnityEngine;
using UnityEngine.EventSystems;

public class DoorSwitch : MonoBehaviour, IPointerClickHandler
{
    const int MAX_DOOR_CNT = 4;
    public DoorMovement[] doors = new DoorMovement[MAX_DOOR_CNT];
    bool flippedX = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleAllDoors();
    }

    public void ToggleAllDoors()
    {
        GetComponent<SpriteRenderer>().flipX = flippedX;
        for (int i = 0; i < MAX_DOOR_CNT; i++)
        {
            if (doors[i] != null)
            {
                doors[i].ToggleDoor();
            }
        }
        flippedX = !flippedX;
    }

    // Start is called before the first frame update
    void Start()
    {
        flippedX = !GetComponent<SpriteRenderer>().flipX;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
