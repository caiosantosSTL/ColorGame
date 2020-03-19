using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarPantallaRL : MonoBehaviour {

    public GameObject Pantalla_log;
    public GameObject Pantalla_reg;
    public GameObject Pantalla_instruct;
    public GameObject Pantalla_inicial;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Ir_tela_login()
    {
        Pantalla_log.SetActive(false);
        Pantalla_reg.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }

    public void Ir_tela_loginajogo()
    {
        Pantalla_log.SetActive(false);
        Pantalla_reg.SetActive(false);
        Pantalla_inicial.SetActive(true);
    }

    public void Ir_tela_registro()
    {
        Pantalla_log.SetActive(false);
        //Pantalla_reg.SetActive(true);
        SceneManager.LoadScene("CenadeReg");
    }

    public void Ir_tela_instruct()
    {
        Pantalla_inicial.SetActive(false);
        Pantalla_instruct.SetActive(true);  

    }

    public void regresar_instruccion_buton()
    {
        Pantalla_inicial.SetActive(true);
        Pantalla_instruct.SetActive(false);
    }
}
