using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitScript : MonoBehaviour
{
    public Text quitText;

    public void DisplayQuitText()
    {
        quitText.text = "Quitting the game";
    }
    // Start is called before the first frame update
    void Start()
    {
        quitText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void quitGame()
    {

    }
}
