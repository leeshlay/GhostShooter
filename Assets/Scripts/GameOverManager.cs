namespace TGK.Project
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameOverManager : MonoBehaviour
    {

        #region Messages
        private void OnDeath(Messages.HealthDepleated message)
        {
            // Destroy itself
            Debug.Log("Dieded :<");
        }
        #endregion Messages
    }
}
