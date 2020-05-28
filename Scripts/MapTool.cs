using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapTool : MonoBehaviour
{
    public GameObject RotateBtn;
    public InputField Rotate;
    public GameObject SelectObtect;

    

    public static GameObject currentObj;
    public GameObject parent;
    public GameObject[] tiles;
    GameObject ColorPan;
    
    Vector3 mousePoint;         //마우스좌표

    Texture2D texture;          //색상표 텍스처
    Color color;                //타일 색상 바꿔줄 저장용 색상

    BarButton barButton;

    public List<GameObject> SelectObtects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("floor");
        barButton = GameObject.Find("Bar").GetComponent<BarButton>();
        ColorPan = GameObject.FindGameObjectWithTag("Color");
        RotateBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        tiles = GameObject.FindGameObjectsWithTag("floor");
        mousePoint = Input.mousePosition;

        if (barButton.selectBtn == SelectBtn.Paint)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (ColorPan.GetComponent<ColorSelect>().onMouse)
                {
                    StartCoroutine(setTileColorTexture());
                }
                changeTileColor();
            }
        }

        if (barButton.selectBtn == SelectBtn.Object || barButton.selectBtn == SelectBtn.Rain)
        {
            createObj();
        }
        ObjectRotate();
    }

    //타일 색상 설정
    IEnumerator setTileColorTexture()
    {
        texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        yield return new WaitForEndOfFrame();
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        color = texture.GetPixel((int)mousePoint.x, (int)mousePoint.y);
    }

    void changeTileColor()
    {
        for(int i =0; i <tiles.Length; i++)
        {
            if (tiles[i].transform.GetChild(0).GetComponent<Ground>().mouseCheck)
            {
                tiles[i].transform.GetChild(0).GetComponent<Renderer>().material.color = color;
                break;
            }
        }
    }

    //오브젝트 설치
    void createObj()
    {
        if (currentObj != null)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tiles[i].transform.GetChild(0).GetComponent<Ground>().mouseCheck &&
                    tiles[i].transform.GetChild(0).GetComponent<Ground>().index == 0)
                {
                    Transform tileTr = tiles[i].transform;
                    GameObject newObj = (GameObject)Instantiate(currentObj);
                    newObj.transform.parent = parent.transform;
                    newObj.transform.localPosition = new Vector3(tileTr.localPosition.x, tileTr.localPosition.y, tileTr.localPosition.z);
                    tiles[i].transform.GetChild(0).GetComponent<Ground>().index++;
                    break;
                }
            }
        }
        else return;
    }

    //오브젝트 설정변경
    
    void ObjectRotate()
    {

        for (int i = 1; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).tag == null) { }
            
            else if(parent.transform.GetChild(i).GetComponent<ObjMouseClick>().onMouse)
            {
                SelectObtects.Add(parent.transform.GetChild(i).gameObject);
                if (SelectObtects.Count >= 2)
                {
                    SelectObtects[0].GetComponent<ObjMouseClick>().onMouse = false;
                    SelectObtects.Remove(SelectObtects[0]);
                }
               
                SelectObtect = SelectObtects[0];
                break;
            }
        }
           
        

         if (SelectObtect != null)
         {
             RotateBtn.SetActive(true);
         }
         else
         {
             RotateBtn.SetActive(false);
         }
        
    }
    public void InputRotate()
    {
        if (SelectObtect != null)
        {
            if (barButton.selectBtn == SelectBtn.Rain) SelectObtect.transform.Rotate(new Vector3(0, 0, int.Parse(Rotate.text)));

            else if (barButton.selectBtn == SelectBtn.Object) SelectObtect.transform.Rotate(new Vector3(0, int.Parse(Rotate.text), 0));
        }//오브젝트 돌릴떄 버튼 누르고 돌려!

        SelectObtect.GetComponent<ObjMouseClick>().onMouse = false;
        SelectObtects.Clear();
        Rotate.text = null;
        SelectObtect = null;
    }
    public void Erase()
    {
        if (SelectObtect != null)
        {
            Destroy(SelectObtect);
            SelectObtects.Clear();
            Rotate.text = null;
            SelectObtect = null;
        }
    }
}
