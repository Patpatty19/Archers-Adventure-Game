using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuffsCollected : MonoBehaviour
{


    public TextMeshProUGUI buffsCollect;
    private int buffNum;

    // Start is called before the first frame update
    void Start()
    {
        buffNum = 0;
        buffsCollect.text = "Buffs Collected =  " + buffNum + "/8";
        buffsCollect.color = Color.yellow;
    }


    private void OnCollisionEnter2D(Collision2D c)
    {

        if (c.gameObject.tag == "JumpandSpeedPowerUp")

        {

            buffNum += 1;
            buffsCollect.text = "Buffs Collected =  " + buffNum + "/8";

        }


        if (c.gameObject.tag == "SpeedPowerUp")

        {

            buffNum += 1;
            buffsCollect.text = "Buffs Collected =  " + buffNum + "/8";

        }


        if (c.gameObject.tag == "JumpandSpeedDebuff")

        {

            buffNum += 1;
            buffsCollect.text = "Buffs Collected =  " + buffNum + "/8";

        }
    }



}
