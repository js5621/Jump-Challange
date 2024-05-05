using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class FallSoundPlay : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.instance.b_firstLanding && !Blink.instance.blinkFloor.activeSelf)
        {
            audioSource.PlayOneShot(clip);
            fadeOut();

        }
    }
    async UniTask fadeOut()
    {

        await UniTask.Delay(1000);
        audioSource.volume = -0.01f;

    }
}
