using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartMenuController : MonoBehaviour
{
    public GameObject chooseLevelUI;
    public GameObject instructionUI;
    public GameObject chooseSkinUI;

    // Use this for initialization
    void Start()
    {
        chooseLevelUI.SetActive(false);
        instructionUI.SetActive(false);
        chooseSkinUI.SetActive(false);
    }

    public void Escape()
    {
        chooseLevelUI.SetActive(false);
        instructionUI.SetActive(false);
        chooseSkinUI.SetActive(false);
    }

    public void StartGame()
    {
        chooseLevelUI.SetActive(true);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene("Level_" + index.ToString());
    }

    public void ShowInstruction()
    {
        instructionUI.SetActive(true);
    }

    public void SelectSkin()
	{
        chooseSkinUI.SetActive(true);
	}

    public void ConfirmSkin()
	{
        chooseSkinUI.SetActive(false);
    }
}
