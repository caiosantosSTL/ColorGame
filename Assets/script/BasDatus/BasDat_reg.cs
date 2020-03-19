using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;


public class BasDat_reg : MonoBehaviour {

    public  Text inputNombre;
    public  Text inputContrasena;
    // fecha
    public Text inputAno;
    public Text inputMes;
    public Text inputDia;

    // puntos
    public Text EsKorekto;
    public Text NoEsKorekto;

    public static int idade;
    public static string idadex;

    //salida info error input
    public Text infoError;

    string url = "http://localhost/colorludophp/conector.php";
    string url2 = "http://localhost/colorludophp/registro.php";


    //Servidor externa caminos
    /*string url = "http://neurodesarrollo.inb.unam.mx/phpunity/conector.php";
    string url2 = "http://neurodesarrollo.inb.unam.mx/phpunity/registro.php";*/


    // Use this for initialization
    void Start () {
        //StartCoroutine(Conector());

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
            Debug.Log("Conecto");
            print(net.downloadHandler.text); // retorno valor no php
        }
    }

    public void Poner_info_reg()
    {
        // ====== Area de las fechas
        
        bool falla_ingreso = false;// si hay informaciones malas, indica fallo de ingreso

        //agarra ano, mes, y dia de ahora
        int ano_atual = DateTime.Now.Year;
        int mes_atual = DateTime.Now.Month;
        int dia_atual = DateTime.Now.Day;


        //valores colocados en el input
        int an = Int32.Parse(inputAno.text);
        //**
        int mes = Int32.Parse(inputMes.text);
        //**
        int dia = Int32.Parse(inputDia.text);

        //area cod aniversario
        idade = (ano_atual - an)-1; 



        // ========================= Area regla de los inputs
        //incoerencia de anos
        if (an > ano_atual)
        {
            print("info  incoerente");
            falla_ingreso = true;
        }
        //ultrapasar meses
        if (mes > 12)
        {
            print("esta mal");
            falla_ingreso = true;
        }

        //regras de dias em cada mes
        if (mes == 1)
        {
            if (dia > 31)
            {
                print("esta mal");
                falla_ingreso = true;
            }
        }
        //ano bissext em feb
        if (mes == 2)
        {
            if ((an % 400 == 0) || (an % 4 == 0 && an % 100 != 0))
            {
                print("E bisexto");
                if (dia > 29)
                {
                    print("esta mal");
                    falla_ingreso = true;
                }
            }
            else
            {
                print("No e bisexto");
                if (dia > 28)
                {
                    print("esta mal");
                    falla_ingreso = true;
                }
            }

        }
        // regra dos dias do mes
        // de marz a jul
        if (mes != 2 && mes != 1 && mes >= 3 && mes < 8)
        {
            if (mes != 2 && mes % 2 == 1 || mes == 8)
            {
                print("E mes dias 31 marz a jul");
            }
            if (mes != 2 && mes % 2 == 0 && mes != 8)
            {
                print("E mes dias 30 marz a jul");
            }
        }
        // de sep a dez
        if (mes != 2 && mes != 1 && mes > 8 && mes <= 12)
        {
            if (mes % 2 == 1)
            {
                print("E mes dias 30 sep a dez");
            }
            if (mes % 2 == 0)
            {
                print("E mes dias 31 sep a dez");
            }
        }

        // ========================= Fin area reglas inputs

        // ====== Fin area fechas

        // ============ ============ ============ ============ Area de SQL input

        if (falla_ingreso == true)
        {
            print("Hay informaciones incorrectas");
            infoError.text = "Hay informaciones incorrectas en los inputs";
        }
        else // si no hay info incorrect
        {

            StartCoroutine(Registrox());
            infoError.text = "Informaciones enviadas con exito";

            // salida de confirmacion ==================================
            Console.WriteLine("Aqui fazemos os inputs das variaveis de an, mes, dia, idade");
            Console.WriteLine(" " + an.ToString() + " - " + mes.ToString() + " - " + dia.ToString() + " idade " + idadex);


        }


    }

    //****************


    //******************

    IEnumerator Registrox()
    {
        WWWForm form = new WWWForm();
        form.AddField("nombree", inputNombre.text);
        form.AddField("contrasenaa", inputContrasena.text);
        form.AddField("anoo", inputAno.text);
        form.AddField("mess", inputMes.text);
        form.AddField("diaa", inputDia.text);
        //form.AddField("diaa", idadex);

        UnityWebRequest net = UnityWebRequest.Post(url2, form);
        yield return net.SendWebRequest();

        if (net.isNetworkError || net.isHttpError)
        {
            Debug.Log(net.error);
        }
        else
        {
            Debug.Log("¡exito!");
        }
    }

    //*************************

    public void AgarrarPuntos()// metodo para insertar puntos
    {

        //StartCoroutine(Puntajex());

    }

    //*****************************




}
