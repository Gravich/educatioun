using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Predok item1 = new Predok();
        //Naslednik item2 = new Naslednik();
        Vnukan item3 = new Vnukan();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




class Predok 
{
    protected int pole3;
    public int pole;
    private int pole2;
    public void Method()
    {

    }
    private void Method2()
    {

    }
    public Predok()
    {
        Debug.Log("Predok");
    }
}

class Naslednik : Predok
{
    public int NaslPole;
    private int NaslPrivPole;
    private void GetOldFields()
    {
        NaslPole = 10;
        NaslPrivPole = 5;
    }
    public Naslednik()
    {
        Debug.Log("Naslednik");
    }
}


class Vnukan : Naslednik
{
    public int chonibud;
    public Vnukan()
    {
        Debug.Log("Vnuk");
    }
}