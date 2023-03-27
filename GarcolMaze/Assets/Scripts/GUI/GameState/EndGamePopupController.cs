using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGamePopupController : MonoBehaviour
{
    public GameObject panel;
    public TMPro.TextMeshProUGUI resultTxt;
    public TMPro.TextMeshProUGUI levelTxt;
    public TMPro.TextMeshProUGUI timeTxt;
    public Timer timer;
    public int level = 1;

    private void Start()
    {
        HidePopup();
    }

    public void ShowPopup(bool isWin)
    {
        if (panel != null)
        {
            panel.SetActive(true);
            UpdateInfo(isWin, timer.secondToTimeStr(), level);
        }
    }

    public void HidePopup()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    public void UpdateInfo(bool isWin, string time, int level)
    {
        if (resultTxt == null || levelTxt == null || timeTxt == null) return;
        resultTxt.text = isWin ? "WE WON" : "WE LOSE";
        levelTxt.text = level.ToString();
        timeTxt.text = time;
    }

    public void nextLevel()
    {
        level += 1;
        if (level > 2)
        {
            SceneManager.LoadScene("StartMenu");
        } else
        {
            SceneManager.LoadScene("Level_" + level.ToString());
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("Level_" + level.ToString());
    }
}
