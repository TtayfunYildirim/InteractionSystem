using System; // Action i?in gerekli
using System.Collections.Generic;
using InteractionSystem.Runtime.Core;
using UnityEngine;

namespace InteractionSystem.Runtime.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        #region Fields

        [SerializeField] private List<KeyData> m_Keys = new List<KeyData>();

        #endregion

        #region Events

        /// Activates when a new key added and throws an event to the UI.
        public event Action<KeyData> OnKeyAdded;

        #endregion

        #region Methods

        public void AddKey(KeyData key)
        {
            if (!m_Keys.Contains(key))
            {
                m_Keys.Add(key);
                Debug.Log($"Key added: {key.KeyName}");

                // Invoke the event.
                OnKeyAdded?.Invoke(key);
            }
        }

        public bool HasKey(KeyData key)
        {
            return m_Keys.Contains(key);
        }

        #endregion
    }
}