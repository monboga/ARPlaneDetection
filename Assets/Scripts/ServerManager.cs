using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Collections;

public class ServerManager : MonoBehaviour
{
    [SerializeField] private string jsonURL;
    [Serializable]
    public struct Items
    {
        [Serializable]
        public struct Item
        {
            public string Name;
            public string Description;
            public string URLBundleModel;
            public string URLImageModel;
        }

        public Item[] items;
    }

    public Items newItemsCollection = new Items();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GetJsonData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetJsonData()
    {
        UnityWebRequest serverRequest = UnityWebRequest.Get(jsonURL);
        yield return serverRequest.SendWebRequest();

        if(serverRequest.result == UnityWebRequest.Result.Success)
        {
            newItemsCollection = JsonUtility.FromJson<Items>(serverRequest.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Error");
        }
    }
}
