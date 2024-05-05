using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;

public class Blink : MonoBehaviour
{
    [SerializeField] public GameObject blinkFloor;
    public static Blink instance;
  
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

      if(!FinalFloor.instance.b_Blinkoff)
         UniStageBlink();
       
    }

    
    async UniTask UniStageBlink()
    {

        
        await UniTask.Delay(500);
        blinkFloor.SetActive(false);
        await UniTask.Delay(500);
        blinkFloor.SetActive(true);
        

    }
}
