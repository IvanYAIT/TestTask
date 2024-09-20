using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Test : MonoBehaviour
{
    private float updateTimer = 0;

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
            Debug.Log(cloak.GetTime());
        }
    }

    private void Update()
    {
        if (updateTimer < 10)
            updateTimer += Time.deltaTime;
        else if(updateTimer >= 10)
        {
            StartCoroutine(GetTime());
            updateTimer = 0;
        }
    }
}
