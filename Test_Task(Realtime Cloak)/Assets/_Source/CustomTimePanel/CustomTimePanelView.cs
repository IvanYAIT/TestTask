using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomTime
{
    public class CustomTimePanelView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField hoursInput;
        [SerializeField] private TMP_InputField minutesInput;
        [SerializeField] private TMP_InputField secondsInput;

        [SerializeField] private GameObject CustomTimePanel;

        [SerializeField] private Button openBtn;
        [SerializeField] private Button applyBtn;
        [SerializeField] private Button cancelBtn;

        public string Seconds => secondsInput.text;
        public string Minutes => minutesInput.text;
        public string Hours => hoursInput.text;
        public Button ApplyBtn => applyBtn;

        void Start()
        {
            openBtn.onClick.AddListener(OpenPanel);
            applyBtn.onClick.AddListener(ClosePanel);
            cancelBtn.onClick.AddListener(ClosePanel);
        }

        public void OpenPanel()
        {
            CustomTimePanel.SetActive(true);
            openBtn.gameObject.SetActive(false);
        }

        public void ClosePanel()
        {
            openBtn.gameObject.SetActive(true);
            CustomTimePanel.SetActive(false);
        }
    }
}