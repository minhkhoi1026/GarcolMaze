using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public char PLAYER_NAME;
    private Image sprite;
    public Image player;
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
        sprite.sprite = skins[selectedSkin];
	} 

    public void PrevOption()
	{
        selectedSkin--;
        if (selectedSkin <= 0)
            selectedSkin = skins.Count - 1;
        sprite.sprite = skins[selectedSkin];
	}

    public void SaveSkin()
	{
        GameObject obj;
        if (PLAYER_NAME == 'A')
		{
            obj = Resources.Load("Player/Male/PlayerA_" + selectedSkin) as GameObject;
        } else
		{
            obj = Resources.Load("Player/Female/PlayerB_" + selectedSkin) as GameObject;
        }
        player.sprite = obj.GetComponent<SpriteRenderer>().sprite;
      
        PlayerPrefs.SetInt("Skin" + PLAYER_NAME, selectedSkin);
    }
}
