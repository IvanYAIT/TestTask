using CloakTime;
using System;

namespace CustomTime
{
    public class CustomTimePanelController
    {
        private CustomTimePanelView _customTimeView;
        private CloakController _controller;
        private TimeView _timeView;

        public CustomTimePanelController(CustomTimePanelView customTimeView, CloakController controller, TimeView timeView)
        {
            _customTimeView = customTimeView;
            _controller = controller;
            _timeView = timeView;
            _customTimeView.ApplyBtn.onClick.AddListener(SetCustomTime);
        }

        public void SetCustomTime()
        {
            DateTime customDate = new DateTime(0);
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            int.TryParse(_customTimeView?.Hours, out hours);
            int.TryParse(_customTimeView?.Minutes, out minutes);
            int.TryParse(_customTimeView?.Seconds, out seconds);

            customDate = customDate.AddSeconds(seconds);
            customDate = customDate.AddMinutes(minutes);
            customDate = customDate.AddHours(hours);

            _controller.SetTime(customDate);
            _timeView.SetTime(customDate);
        }
    }
}