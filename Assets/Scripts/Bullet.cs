using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet : MonoBehaviour
{
    public float Speed = 15;

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime); 
    }

   private void OnCollisionEnter2D(Collision2D c)
    {


        Destroy(gameObject);

        if (c.gameObject.tag == "DestroyableObject")

        {
            

            DestroyableObject destroyableObject = c.gameObject.GetComponent<DestroyableObject>();
            destroyableObject.HideObject();
        }
                  
       
    
    } 
}
