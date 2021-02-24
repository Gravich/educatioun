using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIRaycast : MonoBehaviour
{
    public Text SimpleOutput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray MPoint = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit RayCastObject;
        if ( Physics.Raycast(MPoint, out RayCastObject) ) 
        {
            var tempFuel = RayCastObject.collider.gameObject.GetComponent<ExplosiveFuel>();
            if (tempFuel != null)
            {
                SimpleOutput.text = "Состояние взрывчатки: "+tempFuel.HP.ToString();
            }
            else
            {
                SimpleOutput.text = "";
            }
        }
        else
        {
            SimpleOutput.text = "";
        }

    }
}
