using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.name.Contains("DropStone"))
        {
           
            StoneSpawn.Instance.RetrySpawnRequest();
           

        }
    }
    
        // Update is called once per frame
        void Update()
    {
        
    }
}
