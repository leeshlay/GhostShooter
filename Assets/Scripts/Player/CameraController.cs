namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraController : MonoBehaviour
    {

        [SerializeField]
        private GameObject _Player;

        private Vector3 _OffsetFromPlayer;

        void Start()
        {
            _OffsetFromPlayer = transform.position - _Player.transform.position;
        }

        void LateUpdate()
        {
            transform.position = _Player.transform.position + _OffsetFromPlayer;
        }
    }
}
