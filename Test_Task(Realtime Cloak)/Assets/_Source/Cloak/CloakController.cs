using UnityEngine;
using DG.Tweening;

namespace CloakTime
{
    public class CloakController
    {
        private Transform _hourArrow;
        private Transform _minuteArrow;
        private Transform _secondArrow;

        public CloakController(Transform hourArrow, Transform minuteArrow, Transform secondArrow)
        {
            _hourArrow = hourArrow;
            _minuteArrow = minuteArrow;
            _secondArrow = secondArrow;
        }

        private Cloak _cloak;

        public void SetCloak(Cloak cloak)
        {
            DOTween.KillAll();

            _cloak = cloak;

            Quaternion secondRot = _secondArrow.rotation;
            secondRot.eulerAngles = new Vector3(0, 0, -6 * _cloak.GetTime().Second);
            _secondArrow.rotation = secondRot;

            Quaternion minutRot = _minuteArrow.rotation;
            minutRot.eulerAngles = new Vector3(0, 0, -6 * _cloak.GetTime().Minute);
            _minuteArrow.rotation = minutRot;

            Quaternion hourRot = _hourArrow.rotation;
            hourRot.eulerAngles = new Vector3(0, 0, -30 * _cloak.GetTime().Hour);
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