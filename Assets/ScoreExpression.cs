using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreExpression : MonoBehaviour
{
    public Text CongText1;
    public Text CongText2;
    public Text score;
    public Text scoreValue;
    public Text timeRecord;
    public Text timeRecordValue;
    public int i_finalMin = 0 ;
    public int i_finalsec = 0 ;
    // Start is called before the first frame update
    void Start()
    {
        
        i_finalMin =TimeSetting.instance.getMin();
        i_finalsec = TimeSetting.instance.getSec();
        scoreValue.text = GetGrade();
        timeRecordValue.text = string.Format("{0:00}:{1:00}", i_finalMin, i_finalsec);
        MessageBlink();
    }
    string GetGrade()
    {
        if (i_finalMin < 1)
            return "S";
        else if (i_finalMin < 2 && i_finalMin >= 1)
            return "A";
        else if (i_finalMin < 6 && i_finalMin >= 2)
            return "B";
        else if (i_finalMin <10 && i_finalMin >= 6)
            return "C";
        else if (i_finalMin < 12 && i_finalMin >= 11)
            return "D";
        else
            return "E";

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    async UniTask MessageBlink()
    {
        MsgBlink(CongText1);
        MsgBlink(CongText2);
        MsgBlink(score);
        MsgBlink(scoreValue);
        MsgBlink(timeRecord);
        MsgBlink(timeRecordValue);



    }
    public async void MsgBlink(Text txt)
    {

        await UniTask.Delay(500);
        txt.enabled = false;
        await UniTask.Delay(500);
        txt.enabled = true;
        await UniTask.Delay(500);
        txt.enabled = false;
        await UniTask.Delay(500);
        txt.enabled = true;
       
    }
}
