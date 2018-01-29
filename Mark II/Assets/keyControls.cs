using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyControls : MonoBehaviour 
{
	public GameObject obj1, obj2, obj3;
    public bool toggle1, toggle2, toggle3;
	void Start () 
	{
        obj1.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);
        toggle1 = false;
        toggle2 = false;
        toggle3 = false;
    }

	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.V) && !toggle1)
        {
            Debug.Log("dfisdnflvskdf");
            obj1.SetActive(true);
            toggle1 = true;
        }
        else if(Input.GetKeyDown(KeyCode.V) && toggle1)
        {
            Debug.Log("pppppppppppp");
            obj1.SetActive(false);
            toggle1 = false;
        }
        else if (Input.GetKeyDown(KeyCode.N) && !toggle2)
        {
            obj2.SetActive(true);
            toggle2 = true;
        }
        else if (Input.GetKeyDown(KeyCode.N) && toggle2)
        {
            obj2.SetActive(false);
            toggle2 = false;
        }
        else if (Input.GetKeyDown(KeyCode.B) && !toggle3)
        {
            obj3.SetActive(true);
            toggle3 = true;
        }
        else if (Input.GetKeyDown(KeyCode.B) && toggle3)
        {
            obj3.SetActive(false);
            toggle3 = false;
        }
    }
}
