using UnityEngine;
using UnityEngine.UI; 
using TMPro;          

namespace InteractionSystem.Runtime.UI
{
    /// For Interaction classes and texts
    public class InteractionPromptUI : MonoBehaviour
    {
        #region Fields

        [Header("UI References")]
        [SerializeField] private GameObject m_UiPanel;
        [SerializeField] private TextMeshProUGUI m_PromptText;
        [SerializeField] private Image m_ProgressBar;

        #endregion

        #region Unity Methods

        private void Start()
        {
            Hide();
        }

        #endregion

        #region Methods

        /// Opens up the interactions and shows the text.
        public void Show(string promptText)
        {
            m_PromptText.text = "Press 'E' to interact.\n" + promptText;
            m_UiPanel.SetActive(true);

            // This is done to make hold and instant competable because of the error I was getting when using both.
            UpdateProgress(0f);
        }

        public void SetText(string text)
        {
            if (m_PromptText != null)
            {
                m_PromptText.text = text;
            }
        }


        public void Hide()
        {
            m_UiPanel.SetActive(false);
        }

        /// For showing the progress while holding.
        public void UpdateProgress(float progress)
        {
            if (m_ProgressBar != null)
            {
                m_ProgressBar.fillAmount = progress;
            }
        }

        #endregion
    }
}