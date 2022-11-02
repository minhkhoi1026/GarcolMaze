using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Effect : MonoBehaviour
{
    abstract public void StartEffect(GameObject obj);
    abstract public void ClearEffect();
}
