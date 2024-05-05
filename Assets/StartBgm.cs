using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBgm : MonoBehaviour
{
    public AudioClip aclip_GameBgm;
    public AudioSource aSource_floorAudioSource;
    // Start is called before the first frame update
    public static StartBgm instance;
    private void Awake()
    {
     
        instance = this;
        
    }
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
            if (!PlayerController.instance.b_firstLanding)
            {
                PlayerController.instance.b_firstLanding = true;
                aSource_floorAudioSource.clip = aclip_GameBgm;
                aSource_floorAudioSource.Play();
                aSource_floorAudioSource.loop = true;

            }
            


        }
        
    }
}
