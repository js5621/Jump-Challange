using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFloor : MonoBehaviour
{
    public static FinalFloor instance;
    public bool b_Blinkoff;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {

           b_Blinkoff = true;   

        }

    }
}
