using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowHP : MonoBehaviour
{
    public Slider HPBar;
    public int MaxHP = 3;
    private int CurrentHP;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;  
    }

   
    // Update is called once per frame
    void Update()
    {
        CurrentHP = Character.health;
        HPBar.value = CurrentHP;
    }
}
