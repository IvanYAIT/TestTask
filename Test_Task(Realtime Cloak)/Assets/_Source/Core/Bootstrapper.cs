using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Transform hourArrow;
    [SerializeField] private Transform minuteArrow;
    [SerializeField] private Transform secondArrow;

    [SerializeField] private TimeView timeView;
    [SerializeField] private ServerData serverData;
    [SerializeField] private CloakController cloakController;

    void Start()
    {
        cloakController.Constructor(hourArrow, minuteArrow, secondArrow);
        serverData.Contructor(timeView, cloakController);
    }
}
