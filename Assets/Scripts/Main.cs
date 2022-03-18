using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Main : MonoBehaviour
{
    public MeteoGalicia meteoGalicia;
    void Start()
    {
        
        StartCoroutine(GetRequest("https://servizos.meteogalicia.gal/mgrss/predicion/jsonCPrazo.action?dia=0&request_locale=gl"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    Debug.Log(listaMapas[0]);//acceder a los miembros de una lista. Se que está mal. 
                    break;
            }

            meteoGalicia = JsonUtility.FromJson<MeteoGalicia>(webRequest.downloadHandler.text);
        }
    }
}
