using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableStats : MonoBehaviour
{
    public Text recycleableCntText;
    public Text nonRecycleableCntText;
    public Text organicCntText;
    static string multiplySymbol = "x";

    public void UpdateStats(int recycleable, int nonRecycleable, int organic)
    {
        recycleableCntText.text = multiplySymbol + recycleable.ToString();
        nonRecycleableCntText.text = multiplySymbol + nonRecycleable.ToString();
        organicCntText.text = multiplySymbol + organic.ToString();
    }

    private void Start()
    {
        UpdateStats(0, 0, 0);
    }
}
