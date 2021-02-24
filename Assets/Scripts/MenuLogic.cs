using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class MenuLogic : MonoBehaviour
{
    public RectTransform Content;
    public RectTransform Menu;

    public RectTransform LevelContainer;
    public RectTransform LevelBtn;
    public List<LevelData> LevelList;

    public void OpenLevelMenu()
    {
        Content.gameObject.SetActive(true);
        Menu.gameObject.SetActive(false);
    }
    
    public void OpenMainMenu()
    {
        Content.gameObject.SetActive(false);
        Menu.gameObject.SetActive(true);
    }

    private void Start()
    {
        for (int i = 0; i < LevelList.Count; i++)
        {
            var tempBtn = GameObject.Instantiate(LevelBtn, LevelContainer);
            tempBtn.gameObject.GetComponentInChildren<Text>().text = $"[#{i + 1}] {LevelList[i].Name}";
            //
            tempBtn.gameObject.AddComponent<SelectLevelBtn>().path = LevelList[i].LevelPath;
            tempBtn.gameObject.GetComponent<Button>().onClick.AddListener(
                ()=>{ JumpToLevel(tempBtn.gameObject.GetComponent<SelectLevelBtn>().path); }
                );
            //
        }
            
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void JumpToLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
}

//Атрибут класса
[System.Serializable]
public class LevelData
{
    public string Name;
    public string LevelPath;
} 
