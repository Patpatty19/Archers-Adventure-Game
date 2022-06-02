using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{

   /* public float appearAgainAfter = 5f; */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public void HidePowerUp()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
       

    }

    /* If you want buffs to be respawnable, activate this code */
   /* IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(appearAgainAfter);
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = true;

    } */
}
