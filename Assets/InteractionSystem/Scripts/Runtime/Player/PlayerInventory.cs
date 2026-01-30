using System.Collections.Generic;
using InteractionSystem.Runtime.Core;
using UnityEngine;

namespace InteractionSystem.Runtime.Player
{
    /// A basic inventory system. (For now it only works for the spesific item which is a key.
    public class PlayerInventory : MonoBehaviour
    {
        #region Fields

        // List of all the collected Keys.
        [SerializeField] private List<KeyData> m_Keys = new List<KeyData>();

        #endregion

        #region Methods

        public void AddKey(KeyData key)
        {
            if (!m_Keys.Contains(key))
            {
                m_Keys.Add(key);
                Debug.Log($"Key added: {key.KeyName}");
            }
        }

        public bool HasKey(KeyData key)
        {
            return m_Keys.Contains(key);
        }

        #endregion
    }
}