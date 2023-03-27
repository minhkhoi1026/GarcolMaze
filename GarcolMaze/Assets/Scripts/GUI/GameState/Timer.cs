using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int counter = 0;
    public Text timeText;
    bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        resume();
    }

    public void pause()
    {
        isRunning = false;
    }

    public void resume()
    {
        isRunning = true;
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(1);
            counter++;
            timeText.text = secondToTimeStr();
        }
    }

    public string secondToTimeStr()
    {
        int hours = counter / 3600;
        int minutes = (counter % 3600) / 60;
        int seconds = counter % 3600 % 60;
        return string.Format("{0, 0:D2}:{1, 0:D2}:{2, 0:D2}", hours, minutes, seconds);
    }
}
