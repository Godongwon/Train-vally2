using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Image gauge;
    public GameObject maxGauge;
    public float timeAmt ;
    float time;
    public Text numText;
    public int Maxnum;
    int num;
    public GameObject Train;
    PathSetting start;
    void Start()
    {
        start = GameObject.Find("TrainPath").GetComponent<PathSetting>();
        time = 0;
        num = 0;
        maxGauge.SetActive(false);
    }

    void Update()
    {

        if(time< timeAmt&&num<Maxnum)
        {
            time += Time.deltaTime;
            gauge.fillAmount = time / timeAmt;
        }
        else if(num < Maxnum)
        {
            num++;
            time = 0;
        }
        if(num== Maxnum)
        {
            maxGauge.SetActive(true);
        }
        else
        {
            maxGauge.SetActive(false);  
        }
        numText.text = num.ToString();
    }
    public void Onbutton()
    {
        num--;
   
        GameObject train = Instantiate(Train, new Vector3(start.nodes[0].x, start.nodes[0].y, start.nodes[0].z), new Quaternion(0, 0, 0, 0));
    }
}
