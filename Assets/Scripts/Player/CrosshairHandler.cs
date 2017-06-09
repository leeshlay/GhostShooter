namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class CrosshairHandler : MonoBehaviour
    {

        [SerializeField]
        private MissleShooter _MissleShooter;

        [SerializeField]
        private GameObject _Player;

        public void Start()
        {
            Cursor.visible = false;
        }

        public void Update()
        {
            transform.position = Input.mousePosition;
            Vector3 mousePosition = GetMousePositionOnWorld();


            //Player rotation towards cursor
            NavigatePlayerToMouseLocation(mousePosition);

            //Fire
            if (Input.GetMouseButtonDown(0))
            {
                _MissleShooter.Shoot(mousePosition);
            }

        }

        private Vector3 GetMousePositionOnWorld()
        {
            Vector3 shootDirection = Input.mousePosition;
            shootDirection.z = 1000;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection.y = 0;
            return shootDirection;
        }

        private void NavigatePlayerToMouseLocation(Vector3 mousePosition)
        {
            _Player.transform.rotation = Quaternion.LookRotation(mousePosition);
        }

    }
}
