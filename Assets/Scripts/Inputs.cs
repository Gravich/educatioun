using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inputs : MonoBehaviour
{
    public string MenuPath;
    private bool MenuActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (MenuActive == false)
            {
                SceneManager.LoadSceneAsync(MenuPath, LoadSceneMode.Additive);
                SceneManager.sceneLoaded += ChangeScene;
                MenuActive = true;
                this.gameObject.GetComponent<CamMove>().enabled = false;
                this.gameObject.GetComponent<DoFireBall>().enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
            else
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneByPath(MenuPath));
                MenuActive = false;
                this.gameObject.GetComponent<CamMove>().enabled = true;
                this.gameObject.GetComponent<DoFireBall>().enabled = true;
            }

        }
        //Debug.Log(SceneManager.GetActiveScene().name);
    }

    void ChangeScene(Scene _scene, LoadSceneMode _mode)
    {
        SceneManager.SetActiveScene(_scene);
    }

}
