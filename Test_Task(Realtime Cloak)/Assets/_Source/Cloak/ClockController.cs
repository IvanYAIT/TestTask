using UnityEngine;
using DG.Tweening;
using System;

namespace CloakTime
{
    public class ClockController
    {
        private Transform _hourArrow;
        private Transform _minuteArrow;
        private Transform _secondArrow;

        public ClockController(Transform hourArrow, Transform minuteArrow, Transform secondArrow)
        {
            _hourArrow = hourArrow;
            _minuteArrow = minuteArrow;
            _secondArrow = secondArrow;
        }

        public void SetTime(DateTime time)
        {
            DOTween.KillAll();

            Quaternion secondRot = _secondArrow.rotation;
            secondRot.eulerAngles = new Vector3(0, 0, -6 * time.Second);
            _secondArrow.rotation = secondRot;

            Quaternion minutRot = _minuteArrow.rotation;
            minutRot.eulerAngles = new Vector3(0, 0, -6 * time.Minute);
            _minuteArrow.rotation = minutRot;

            Quaternion hourRot = _hourArrow.rotation;
            hourRot.eulerAngles = new Vector3(0, 0, -30 * time.Hour);
            _hourArrow.rotation = hourRot;

            _secondArrow.DORotate(_secondArrow.eulerAngles + new Vector3(0, 0, -6), 1)
                .SetLoops(-1, LoopType.Incremental);

            _minuteArrow.DORotate(_minuteArrow.eulerAngles + new Vector3(0, 0, -6), 60)
                .SetLoops(-1, LoopType.Incremental);

            _hourArrow.DORotate(_hourArrow.eulerAngles + new Vector3(0, 0, -30), 3600)
                .SetLoops(-1, LoopType.Incremental);
        }
    }
}