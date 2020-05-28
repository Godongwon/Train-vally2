using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneTrain : MonoBehaviour
{
    public Sprite[] trainImgs;
    public Sprite train;
    public float trainSpeed = 150.0f;
   Vector3 posistion;
   public Image img;
    
    void Start()
    {
        posistion = transform.position;
        img = GameObject.Find("Train").GetComponent<Image>();
        img.sprite = trainImgs[Random.Range(0, trainImgs.Length)];
    }

    void Update()
    {
        if(img==null)
        {
            return;
        }
        

        transform.position = posistion;
        if(transform.position.x>=2000.0f)
        {
            
            img.sprite = trainImgs[Random.Range(0, trainImgs.Length)];
            posistion.x = 0;
            transform.position = posistion; 
            //Debug.Log(posistion.x);
        }
        else
        {
            
             posistion.x += Time.deltaTime * trainSpeed;
            //Debug.Log(posistion.x);

        }
        
    }

  
    
}
