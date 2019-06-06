using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{

    public Text score;

    public static int ssccoorree;

   

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        ssccoorree = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + ssccoorree;  
    }

   
}
