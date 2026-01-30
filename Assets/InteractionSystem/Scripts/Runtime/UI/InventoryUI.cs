using UnityEngine;
using TMPro;
using InteractionSystem.Runtime.Core;
using InteractionSystem.Runtime.Player;

namespace InteractionSystem.Runtime.UI
{
    /// Checks and shows the items in the inventory
    public class InventoryUI : MonoBehaviour
    {
        #region Fields

        [Header("References")]
        [SerializeField] private PlayerInventory m_PlayerInventory;
        [SerializeField] private Transform m_ListContainer; // Container for the keys.
        [SerializeField] private GameObject m_KeyItemPrefab; // This part is for duplication.

        #endregion

        #region Unity Methods

        private void Start()
        {
            if (m_PlayerInventory != null)
            {
                // Add the event.
                m_PlayerInventory.OnKeyAdded += HandleKeyAdded;
            }
        }

        private void OnDestroy()
        {
            if (m_PlayerInventory != null)
            {
                // Remove the same event.
                m_PlayerInventory.OnKeyAdded -= HandleKeyAdded;
            }
        }

        #endregion

        #region Methods

        private void HandleKeyAdded(KeyData keyData)
        {
            GameObject newItem = Instantiate(m_KeyItemPrefab, m_ListContainer);

            TextMeshProUGUI textComp = newItem.GetComponentInChildren<TextMeshProUGUI>();
            if (textComp != null)
            {
                textComp.text = keyData.KeyName;
            }
        }

        #endregion
    }
}