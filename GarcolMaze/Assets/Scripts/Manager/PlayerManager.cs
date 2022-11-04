using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public GameObject playerA, playerB;
	private void Awake()
	{
        if (PlayerPrefs.HasKey("SkinA"))
        {
            int selectedId = PlayerPrefs.GetInt("SkinA");
            GameObject obj = Resources.Load("Player/Male/PlayerA_" + selectedId) as GameObject;
            // Destroy(playerA);
            playerA.GetComponent<Animator>().runtimeAnimatorController = obj.GetComponent<Animator>().runtimeAnimatorController;
        }

        if (PlayerPrefs.HasKey("SkinB"))
        {
            int selectedId = PlayerPrefs.GetInt("SkinB");
            GameObject obj = Resources.Load("Player/Female/PlayerB_" + selectedId) as GameObject;
            // Destroy(playerB);
            playerB.GetComponent<Animator>().runtimeAnimatorController = obj.GetComponent<Animator>().runtimeAnimatorController;

        }
    }
}
