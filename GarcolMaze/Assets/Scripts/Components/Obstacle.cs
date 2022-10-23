using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Obstacle : MonoBehaviour
{
    Collider2D _collider;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _collider.isTrigger = true;
    }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            applyEffect(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null)
        {
            revertEffect(other);
        }
    }

    abstract public void applyEffect(Collider2D other);
    abstract public void revertEffect(Collider2D other);
}
