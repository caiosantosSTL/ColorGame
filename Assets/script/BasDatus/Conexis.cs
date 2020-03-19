using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Conexis : MonoBehaviour {

    string url = "http://localhost/colorludophp/conector.php";

    // Use this for initialization
    void Start () {
        StartCoroutine(Conector());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Conector()
    {
        UnityWebRequest net = UnityWebRequest.Get(url);
        yield return net.SendWebRequest();

        if (net.isNetworkError || net.isHttpError)
        {
            Debug.Log(net.error);
            print("erro");


        }
        else
        {
            Debug.Log("Conectou");
            print(net.downloadHandler.text); // retorno valor no php
        }
    }
}
