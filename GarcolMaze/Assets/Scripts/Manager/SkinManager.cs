using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkinManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Image sprite;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;

	private void Awake()
	{
		sprite = GetComponent<Image>();
	}
	public void NextOption()
	{
        selectedSkin++;
        if (selectedSkin >= skins.Count)
            selectedSkin = 0;
        Debug.Log(selectedSkin);
        sprite.sprite = skins[selectedSkin];
	} 

    public void PrevOption()
	{
        selectedSkin--;
        if (selectedSkin <= 0)
            selectedSkin = skins.Count - 1;
        sprite.sprite = skins[selectedSkin];
	}
}
