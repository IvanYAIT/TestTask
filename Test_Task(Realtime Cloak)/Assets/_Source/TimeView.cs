using System;
using TMPro;
using UnityEngine;

public class TimeView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    private DateTime _time;

    public void SetTime(DateTime time)
    {
        _time = time;
    }

    private void Update()
    {
        if (_time != null)
        {
            _time = _time.AddSeconds(Time.deltaTime);
            timeText.text = _time.ToString("HH:mm:ss");
        }
    }
}
