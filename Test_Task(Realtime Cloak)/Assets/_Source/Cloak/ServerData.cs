using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace CloakTime
{
    public class ServerData : MonoBehaviour
    {
        private TimeView _timeView;
        private ClockController _clockController;
        private float _syncTimer;

        public void Contructor(TimeView timeView, ClockController cloakController)
        {
            _timeView = timeView;
            _clockController = cloakController;
        }

        void Start()
        {
            StartCoroutine(GetTime());
        }

        IEnumerator GetTime()
        {
            UnityWebRequest www = UnityWebRequest.Get("http://worldtimeapi.org/api/timezone/Europe/Moscow");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Clock clock = JsonUtility.FromJson<Clock>(www.downloadHandler.text);
                Debug.Log(clock.GetTime());
                _clockController.SetTime(clock.GetTime());
                _timeView.SetTime(clock.GetTime());
            }
        }

        private void Update()
        {
            if (_syncTimer < 3600)
                _syncTimer += Time.deltaTime;
            else if (_syncTimer >= 3600)
            {
                StartCoroutine(GetTime());
                _syncTimer = 0;
            }
        }
    }
}