using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowVolume : MonoBehaviour
{
    public Scrollbar VolScroll;

    public Text VolText;



    // Start is called before the first frame update
    void Start()
    {
        VolText = GetComponent<Text>();
        VolScroll = GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        ScrollVal(VolScroll.value);
    }

    public void ScrollVal(float scrollvalue)
    {
        //VolScroll.value = scrollvalue;
        VolText.text = "Volume: " + scrollvalue;
    }
}