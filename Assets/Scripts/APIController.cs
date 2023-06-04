using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class APIController : MonoBehaviour
{
    private IEnumerator CallApi()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://c07c-210-119-33-34.ngrok-free.app/test/unity");
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string response = www.downloadHandler.text;
            Debug.Log(response);
        }
        else
        {
            Debug.LogError(www.error);
        }
    }

    private void Start()
    {
        StartCoroutine(CallApi());
    }
}
