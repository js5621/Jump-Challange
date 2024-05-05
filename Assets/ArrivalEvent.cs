using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class ArrivalEvent : MonoBehaviour
{
    public bool b_isGameEnd = false;
    public static ArrivalEvent instance; 
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
        if(b_isGameEnd)
            SceneManager.LoadScene(2);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name.Contains("Player"))
        {

            bgmFadeOut();
            // StartBgm.instance.aSource_floorAudioSource.Stop();
            
        }
        
    }

    async UniTask bgmFadeOut()
    {
      for(int i =0; i< 10;i++)
      {
            await UniTask.Delay(100);
            StartBgm.instance.aSource_floorAudioSource.volume -=0.01f;
            
            

       }
      await UniTask.Delay(100);
      StartBgm.instance.aSource_floorAudioSource.Stop();
      await UniTask.Delay(100);
      b_isGameEnd=true;
    

    }
}
