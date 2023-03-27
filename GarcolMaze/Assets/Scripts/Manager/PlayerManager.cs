using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public GameObject playerA, playerB;
    private Vector3 playerAPosition, playerBPosition;
	private void Awake()
	{
        if (PlayerPrefs.HasKey("SkinA"))
        {
            int selectedId = PlayerPrefs.GetInt("SkinA");
            if (selectedId != 0)
			{
                GameObject obj = Resources.Load("Player/Male/PlayerA_" + selectedId) as GameObject;
                playerA.GetComponent<Animator>().runtimeAnimatorController = obj.GetComponent<Animator>().runtimeAnimatorController;
			}
        }

        if (PlayerPrefs.HasKey("SkinB"))
        {
            int selectedId = PlayerPrefs.GetInt("SkinB");
            if (selectedId != 0)
			{
                GameObject obj = Resources.Load("Player/Female/PlayerB_" + selectedId) as GameObject;
                playerB.GetComponent<Animator>().runtimeAnimatorController = obj.GetComponent<Animator>().runtimeAnimatorController;
			}
        }
        // save original position
        playerAPosition = playerA.transform.position + Vector3.zero;
        playerBPosition = playerB.transform.position + Vector3.zero;
    }

    public void resetPlayerState()
	{
        playerA.transform.position = playerAPosition;
        playerB.transform.position = playerBPosition;
        playerA.GetComponent<PlayerController>().InitPlayerState();
        playerB.GetComponent<PlayerController>().InitPlayerState();
    }
}
