using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{

    public bool alreadyCalled = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CallReinforcements(int num, GameObject spawn, Transform NewPos)
    {
        Debug.Log("Called Guys");
        if (!alreadyCalled)
        {
            for (int i = 0; i < num; i++)
            {
              //  pos = spawn.transform.localPosition;
                Instantiate(spawn,NewPos.position,NewPos.rotation);
            }
            alreadyCalled = true;
        }
    }

    internal void CallReinforcements(int v)
    {
        throw new NotImplementedException();
    }
}
