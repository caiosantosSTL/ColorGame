using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class BasDat_logpuntos : MonoBehaviour {

    public Text inputNOMOlog;
    public Text inputPASVlog;


    public GameObject pantalla_log;
    public GameObject pantalla_reg;
    public GameObject pantalla_inicial;

    //conector
    public GameObject conex;
    //public GameObject inputslog;

    //Variables para comparacion de los datos en tabla sql
    string nomox;
    string pasvortox;
    int idx;
    string fechax;

    public static int idlog;
    public static string fechanac;

    //agarra inputs de los puntos
    public Text EsKorekto;
    public Text NoEsKorekto;
    //*********
    int valButon = 0;


    string url = "http://localhost/colorludophp/conector.php";
    string url2 = "http://localhost/colorludophp/login.php";
    string url3 = "http://localhost/colorludophp/puntaje.php";

    //Servidor externa caminos
    /*string url = "http://neurodesarrollo.inb.unam.mx/phpunity/conector.php";
    string url2 = "http://neurodesarrollo.inb.unam.mx/phpunity/login.php";
    string url3 = "http://neurodesarrollo.inb.unam.mx/phpunity/puntaje.php";*/

    //string edad = BasDat_reg.idadex; no vamos usar papada de edad
    //fecha hoy

    int anoH;
    int mesH;
    int diaH;

    //=====

    string anohoy; // <======================
    string meshoy;
    string diahoy;



    // Use this for initialization
    void Start () {
        //StartCoroutine(Conector());
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AhoraTiempo()
    {
        anoH = DateTime.Now.Year;
        mesH = DateTime.Now.Month;
        diaH = DateTime.Now.Day;

        anohoy = anoH.ToString();
        meshoy = mesH.ToString();
        diahoy = diaH.ToString();
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


    public void AgarrarReg()
    {
        
        StartCoroutine(Logar());

    }

    public void AgarrarPuntos()// metodo para insertar puntos
    {
        if(valButon == 0)
        {
            StartCoroutine(Puntajex());
            valButon = 1;
        }


    }

    //**************************

    IEnumerator Logar()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombree", inputNOMOlog.text);
        form.AddField("contrasenaa", inputPASVlog.text);

        UnityWebRequest net3 = UnityWebRequest.Post(url2, form);
        yield return net3.SendWebRequest();

        if (net3.isNetworkError || net3.isHttpError)
        {
            Debug.Log(net3.error);


        }
        else
        {
            
            Debug.Log("Se ha iniciado");
            print(net3.downloadHandler.text); // retorno valor en php
            if (net3.downloadHandler.text == "logax")
            {
                print("bololodo");
                pantalla_log.SetActive(false);
                pantalla_reg.SetActive(false);
                pantalla_inicial.SetActive(true);
                DontDestroyOnLoad(conex);

            }

        }
    }

    //*****************************

    IEnumerator Puntajex() 
    {
        AhoraTiempo();
        WWWForm form = new WWWForm();
        form.AddField("corectoo", EsKorekto.text);
        form.AddField("incorectoo", NoEsKorekto.text);

        form.AddField("anoo", anohoy);
        form.AddField("mess", meshoy);
        form.AddField("diaa", diahoy);

        form.AddField("nombree", inputNOMOlog.text);
        form.AddField("contrasenaa", inputPASVlog.text);

        UnityWebRequest net = UnityWebRequest.Post(url3, form);
        yield return net.SendWebRequest();

        if (net.isNetworkError || net.isHttpError)
        {
            Debug.Log(net.error);
        }
        else
        {
            Debug.Log("Enviado los puntos !");
        }
    }





}
