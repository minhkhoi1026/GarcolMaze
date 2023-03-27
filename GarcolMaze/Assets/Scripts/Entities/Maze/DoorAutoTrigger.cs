using System.Collections;
using UnityEngine;


public class DoorAutoTrigger : AutoTrigger
{
    const int MAX_DOOR_CNT = 16;
    public Moveable[] moveables = new Moveable[MAX_DOOR_CNT];
    public string canTriggerTag = "ANY_TAG";
    public Sprite btnUpSprite;
    public Sprite btnDownSprite;

    SpriteRenderer _renderer;
    bool isBtnUp = true;

    public void ToggleAllDoors()
    {
        int n = moveables.Length;
        for (int i = 0; i < n; i++)
        {
            if (moveables[i] != null)
            {
                moveables[i].Toggle();
            }
        }
    }

    public void ToggleSprite()
    {
        if (isBtnUp)
        {
            _renderer.sprite = btnDownSprite;
        }
        else
        {
            _renderer.sprite = btnUpSprite;
        }
        isBtnUp = !isBtnUp;
    }

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.sprite = btnUpSprite;
        isBtnUp = true;
    }

    public override void applyEffect(Collider2D other) {
    }

    public override void revertEffect(Collider2D other)
    {
        string colliderTag = other.gameObject.tag;
        if (!colliderTag.StartsWith("Player")) return;
        if (canTriggerTag.Equals(colliderTag) || canTriggerTag.Equals("ANY_TAG"))
        {
            ToggleAllDoors();
            ToggleSprite();
            SoundManager.PlaySound("button");
        }
    }
}
