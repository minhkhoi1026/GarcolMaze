using UnityEngine;
using UnityEngine.EventSystems;

public class DoorSwitch : Interactable
{
    const int MAX_DOOR_CNT = 4;
    public Moveable[] moveables = new Moveable[MAX_DOOR_CNT];
    bool flippedX = true;

    public void ToggleAllDoors()
    {
        GetComponent<SpriteRenderer>().flipX = flippedX;
        for (int i = 0; i < MAX_DOOR_CNT; i++)
        {
            if (moveables[i] != null)
            {
                moveables[i].Toggle();
            }
        }
        flippedX = !flippedX;
    }

    public override void Interact(PlayerController player)
    {
        ToggleAllDoors();
        SoundManager.PlaySound("switch");
    }

    // Start is called before the first frame update
    void Start()
    {
        flippedX = !GetComponent<SpriteRenderer>().flipX;
    }

    // Update is called once per frame
    void Update() { }
}
