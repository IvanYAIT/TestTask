using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace CloakTime
{
    public class ServerData : MonoBehaviour
    {
        [SerializeField] private TimeView _timeView;
        [SerializeField] private CloakController _cloakController;

        private float _syncTimer;

        public void Contructor(TimeView timeView, CloakController cloakController)
        {
            _timeView = timeView;
            _cloakController = cloakController;
        }

        void Start()
        {
            StartCoroutine(GetTime());
        }

        IEnumerator GetTime()
        {
            UnityWebRequest www = UnityWebRequest.Get("https://yandex.com/time/sync.json");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Cloak cloak = JsonUtility.FromJson<Cloak>(www.downloadHandler.text);
                _cloakController.SetCloak(cloak);
                _timeView.SetTime(cloak.GetTime());
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