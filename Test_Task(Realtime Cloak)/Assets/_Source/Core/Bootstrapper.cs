using CloakTime;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform hourArrow;
        [SerializeField] private Transform minuteArrow;
        [SerializeField] private Transform secondArrow;

        [SerializeField] private TimeView timeView;
        [SerializeField] private ServerData serverData;
        private CloakController cloakController;

        void Start()
        {
            cloakController = new CloakController(hourArrow, minuteArrow, secondArrow);
            serverData.Contructor(timeView, cloakController);
        }
    }
}