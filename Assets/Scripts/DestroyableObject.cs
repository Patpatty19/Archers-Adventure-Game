using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyableObject : MonoBehaviour
{
    public float appearAgainAfter = 10f;

   


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HideObject()
    {
        GetComponent<TilemapRenderer>().enabled = false;
        GetComponent<TilemapCollider2D>().enabled = false;
        StartCoroutine(DelayRespawn());

    }

    IEnumerator DelayRespawn()
    {
        yield return new WaitForSeconds(appearAgainAfter);
        GetComponent<TilemapRenderer>().enabled = true;
        GetComponent<TilemapCollider2D>().enabled = true;

    }

    
}
