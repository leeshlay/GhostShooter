using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairHandler: MonoBehaviour {

    public void Start()
    {
        Cursor.visible = false;
    }

    public void Update()
    {
        transform.position = Input.mousePosition;

        if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pressed left click.");
        }

    }

}
