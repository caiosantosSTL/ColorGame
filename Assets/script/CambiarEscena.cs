using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour { // cambiar escena

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {

            SceneManager.LoadScene("CenadeReg");//vamos para pantalla de login en la escena de registro




        }

    }
}
