using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerAfterGame : MonoBehaviour
{
   
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
    
        timerText.text = TimerController.instance.timePlayingStr;
        timerText.color = Color.yellow;

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
