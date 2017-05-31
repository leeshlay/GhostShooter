using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairHandler: MonoBehaviour {

    [SerializeField]
    private MissleShooter missleShooter;

    [SerializeField]
    private GameObject player;

    public void Start()
    {
        Cursor.visible = false;
    }

    public void Update()
    {
        transform.position = Input.mousePosition;
        Vector3 mousePosition = getMousePositionOnWorld();


        //Player rotation towards cursor
        navigatePlayerToMouseLocation(mousePosition);
        
        //Fire
        if (Input.GetMouseButtonDown(0)){
            missleShooter.Shoot(mousePosition);
        }

    }

    private Vector3 getMousePositionOnWorld() {
        Vector3 shootDirection = Input.mousePosition;
        shootDirection.z = 1000;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection.y = 0;
        return shootDirection;
    }

    private void navigatePlayerToMouseLocation(Vector3 mousePosition) {
        player.transform.rotation = Quaternion.LookRotation(mousePosition);
    }

}
