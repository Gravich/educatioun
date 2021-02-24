using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public RectTransform GUIPrefab;
    public RectTransform GUIParent;
    public RectTransform MainGUI;
    private RectTransform CurrentGUI;


    public List<ItemBase> Cargo;
    public Transform spawnPoint;
    public Text ItemInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        Ray MPoint = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit RayCastObject;
        if (Physics.Raycast(MPoint, out RayCastObject))
        {
            var item = RayCastObject.collider.gameObject.GetComponent<Item>();
            if (item != null)
            {
                ItemInfo.text = item.config.ShowInfo();
                if (Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.E))
                {
                    Cargo.Add(item.config);
                    item.config.check++;
                    GameObject.Destroy(item.gameObject);
                }
            }
            else
            {
                ItemInfo.text = "";
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DropItem();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }
    }

    public void DropItem()
    {
        if (Cargo.Count>0)
        {
            Cargo[0].SpawnFromInventory(spawnPoint);
            Cargo.RemoveAt(0);
            
            if (CurrentGUI)
            {
                FillGUI(CurrentGUI);
            }
        }
    }

    public void ShowInventory()
    {
        if (CurrentGUI == null)
        {
            CurrentGUI = GameObject.Instantiate(GUIPrefab, GUIParent);
            MainGUI.gameObject.SetActive(false);
            this.gameObject.GetComponent<CamMove>().enabled = false;
            this.gameObject.GetComponent<DoFireBall>().enabled = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            FillGUI(CurrentGUI);
        }
        else
        {
            Destroy(CurrentGUI.gameObject);
            MainGUI.gameObject.SetActive(true);
            this.gameObject.GetComponent<CamMove>().enabled = true;
            this.gameObject.GetComponent<DoFireBall>().enabled = true;
        }
    }



    public void FillGUI(RectTransform GUI)
    {
        var target = GUI.gameObject.GetComponentInChildren<MarkerScript>().GetComponent<RectTransform>();
        var blocks = target.GetComponentsInChildren<ItemBlock>();
        Debug.Log(blocks.Length);
        foreach (var block in blocks)
        {
            Destroy(block.gameObject);
        }
        foreach (var item in Cargo)
        {
            var block = item.GenerateGUIBlock();
            block.transform.parent = target.transform;
        }
    }
}
