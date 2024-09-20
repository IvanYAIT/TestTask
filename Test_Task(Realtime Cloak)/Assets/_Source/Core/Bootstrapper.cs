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
        private ClockController clockController;
        private CustomTimePanelController customTimePanelController;
 
        void Start()
        {
            clockController = new ClockController(hourArrow, minuteArrow, secondArrow);
            customTimePanelController = new CustomTimePanelController(customTimePanelView, clockController, timeView);
            serverData.Contructor(timeView, clockController);
        }
    }
}