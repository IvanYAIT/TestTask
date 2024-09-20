using CloakTime;
using CustomTime;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform hourArrow;
        [SerializeField] private Transform minuteArrow;
        [SerializeField] private Transform secondArrow;

        [SerializeField] private CustomTimePanelView customTimePanelView;
        [SerializeField] private TimeView timeView;
        [SerializeField] private ServerData serverData;
        private CloakController cloakController;
        private CustomTimePanelController customTimePanelController;
 
        void Start()
        {
            cloakController = new CloakController(hourArrow, minuteArrow, secondArrow);
            customTimePanelController = new CustomTimePanelController(customTimePanelView, cloakController, timeView);
            serverData.Contructor(timeView, cloakController);
        }
    }
}