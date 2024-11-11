using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotRegis : MonoBehaviour
{
    public Text nombre;
    public Text contrasena;
    public Text email;
    public GameObject boton;
    public GameObject botlog;

    void Start() {
        nombre.text = "";
        contrasena.text = "";
        email.text = "";
        boton.SetActive(false);
    }

    void Update() {
        if(nombre.text!= "" && contrasena.text!= "" && contrasena.text!= "") {
            boton.SetActive(true);
        }
    }

    public void presionar() {
        Variables.nombre = nombre.text;
        Variables.contrasena = contrasena.text;
        Variables.email = email.text;
        //SceneManager.LoadScene("segunda");
    }
    public void log() {
        SceneManager.LoadScene("Login");
    }
}
