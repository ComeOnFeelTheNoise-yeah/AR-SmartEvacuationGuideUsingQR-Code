using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class URLSchemeExample : MonoBehaviour
{
    [SerializeField]
    public TMP_Text tmp;

    private void Start()
    {
#if UNITY_EDITOR
        // 에디터에서 실행할 때는 URL이 비어있을 수 있으므로 처리합니다.
        if (string.IsNullOrEmpty(Application.absoluteURL))
        {
            tmp.text = "Cannot retrieve URL scheme in the Unity Editor.";
            return;
        }
#endif

        // 현재 실행 중인 애플리케이션의 URL을 가져옵니다.
        string url = Application.absoluteURL;



        // URL에서 스키마 부분을 추출합니다.
        string scheme = GetURLScheme(url);
        tmp.text = scheme;

        // 추출한 스키마를 출력하거나 원하는 대로 사용합니다.
        Debug.Log("URL Scheme: " + scheme);
    }

    private string GetURLScheme(string url)
    {

        // URL을 Uri 객체로 변환합니다.
        System.Uri uri = new System.Uri(url);

        // Uri 객체에서 스키마 부분을 추출하여 반환합니다.
        return uri.Scheme;
    }

}