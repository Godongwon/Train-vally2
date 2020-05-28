using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEditor;
//using UnityEditor.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using LitJson;

public enum DataCtrol
{
    Save,
    Load,
    Create,
    Empty
}

public class DataManager : MonoBehaviour
{
    
    public DataCtrol dataCtrol;
    private string scenename;
    public InputField ScenenameText;
    public GameObject[] savebtns;
    public GameObject[] loadbtns;
    public List<string> Scenename = new List<string>();
    public GameObject plain;
    BarButton barButton;
    public GameObject contant;
    public Sprite Btnimg;
    public string nametext;
    public GameObject Object;

    public Text stat;

    List<string> list = new List<string>();

    public GameManager gm;

    void Start()
    {
        stat.text = null;
        dataCtrol = DataCtrol.Empty;

        barButton = GameObject.Find("Bar").GetComponent<BarButton>();

        Object = GameObject.Find("Plain");
        gm = GameManager.Instance;
        DirectoryInfo di = new DirectoryInfo(Application.streamingAssetsPath+"/MapData");
        FileInfo[] file = di.GetFiles("*.json");
        //FileInfo[] file = di.GetFiles();
        Debug.Log(file.Length);
        
        if(file.Length>0)
        { 
            for(int i=0;i<file.Length;i++)
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(file[i].FullName.ToString());
                Debug.Log(name);
                buttonCreate(name);
            }
        }
    }
    float time = 0;
    private void Update()
    {
        

        if(stat.text!=null)
        {
            time += Time.deltaTime;
        }

        if(time>3.0f)
        {
            stat.text = null;
            time = 0;
        }

        if (barButton.selectBtn==SelectBtn.Save)
        {
            for(int i=0;i< savebtns.Length;i++)
            {
                savebtns[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < savebtns.Length; i++)
            {
                savebtns[i].SetActive(false);
            }
            
        }


        if (barButton.selectBtn == SelectBtn.Load)
        {
            for (int i = 0; i < loadbtns.Length; i++)
            {
                loadbtns[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < loadbtns.Length; i++)
            {
                loadbtns[i].SetActive(false);
            }
            
        }

    }
    public void Save()
    {
        if (nametext == "")
        {
            
            Debug.Log("선택해 임마");
            return;
        }
        list= GameObject.Find(nametext).GetComponent<CreateList>().newList;
        if(list[0] != nametext)
        {
            
            Debug.Log("없어 임마");
            return;
        }
        for (int i=0;i< Object.transform.GetChild(0).childCount;i++)
        {
            gm.objectLists.Add(new ObjectList((string)Object.transform.GetChild(0).GetChild(i).tag, (int)Object.transform.GetChild(0).GetChild(i).position.x,
                (int)Object.transform.GetChild(0).GetChild(i).GetChild(0).position.y, (int)Object.transform.GetChild(0).GetChild(i).position.z,
                 Object.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material.color.r.ToString(),
                 Object.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material.color.g.ToString(),
                 Object.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material.color.b.ToString()));
        }

        if (Object.transform.childCount > 1)
        {
            for (int i = 1; i < Object.transform.childCount; i++)
            {

                gm.objectLists.Add(new ObjectList((string)Object.transform.GetChild(i).tag, (int)Object.transform.GetChild(i).position.x,
                    (int)Object.transform.GetChild(i).position.y, (int)Object.transform.GetChild(i).position.z, (int)Object.transform.rotation.x, (int)Object.transform.rotation.y,
                    (int)Object.transform.rotation.z));
            }
        }

        JsonData jsonData = JsonMapper.ToJson(gm.objectLists);

        File.WriteAllText(Application.streamingAssetsPath + "/MapData/" + nametext+".json", jsonData.ToString());//"/MapData/"

        Debug.Log("생김 임마");
        stat.text = nametext + " Json파일이 생겼습니다.";

    }

    public void Load()
    {
        for(int i=0;i< Object.transform.GetChild(0).childCount;i++)
        {
            if (Object.transform.GetChild(0).GetChild(i).tag == "floor") Destroy(Object.transform.GetChild(0).GetChild(i).gameObject);
        }
        if (Object.transform.childCount > 1)
        {
            for (int i = 1; i < Object.transform.childCount; i++)
            {
                if (Object.transform.GetChild(i).tag != "Plain") Destroy(Object.transform.GetChild(i).gameObject);
            }
        }

        gm.MapLoad(nametext);
        stat.text = nametext + " Json파일이 불러왔습니다.";


    }

    public void Create()
    {
        if (barButton.selectBtn != SelectBtn.Save&& ScenenameText.text==null)
        {

            Debug.Log("똑디 안해서 만들수 없다..");
            return;
        }
        if (Scenename.Count > 0)
        {
            for (int i = 0; i < Scenename.Count; i++)
            {
                if (Scenename[i] == ScenenameText.text)
                {
                    
                    Debug.Log("이름이 같아서 만들수 없다..");
                    return;
                }
            }
        }
        if(ScenenameText.text=="")
        {
            
            Debug.Log("입력을 안해서 만들수 없다..");
            return;
        }


        dataCtrol = DataCtrol.Create;
        Scenename.Add(ScenenameText.text);
        buttonCreate(ScenenameText.text);
        List<string> list = GameObject.Find(ScenenameText.text).GetComponent<CreateList>().newList;
        list.Add(ScenenameText.text); 
        ScenenameText.text = null;
    }

    

    void buttonCreate(string name)
    {
        var buttonObject = new GameObject(name);
        var image = buttonObject.AddComponent<Image>();
        var list = buttonObject.AddComponent<CreateList>();
        image.transform.SetParent(contant.transform);
        image.rectTransform.sizeDelta = new Vector2(240, 30);
        image.rectTransform.anchoredPosition = Vector3.zero;
        var button = buttonObject.AddComponent<Button>();
        button.image = image;



        var textObject = new GameObject("Text");
        textObject.transform.parent = buttonObject.transform;
        var text = textObject.AddComponent<Text>();
        text.rectTransform.sizeDelta = Vector2.zero;
        text.rectTransform.anchorMin = Vector2.zero;
        text.rectTransform.anchorMax = Vector2.one;
        text.rectTransform.anchoredPosition = new Vector2(.5f, .5f);
        text.text = name;
        text.font = Resources.FindObjectsOfTypeAll<Font>()[0];
        text.fontSize = 20;
        text.color = Color.black;
        text.alignment = TextAnchor.MiddleCenter;
        button.onClick.AddListener(() => nametext=text.text);
    }
}
