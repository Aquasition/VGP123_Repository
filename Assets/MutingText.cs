using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MutingText : MonoBehaviour
{
    public Text muteText;

    private bool isOn;

    public void DisplayMuteText()
    {
        if (isOn == false)
        {
            muteText.text = "Muted";
            isOn = true;
        }
        else if (isOn == true)
        {
            muteText.text = "";
            isOn = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        muteText.text = "";
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void quitGame()
    {

    }
}