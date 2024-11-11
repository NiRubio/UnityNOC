using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotLog : MonoBehaviour
{
    public Text nombre;
    public Text contrasena;
    public GameObject boton;
    public GameObject botregis;

    void Start() {
        nombre.text = "";
        contrasena.text = "";
        boton.SetActive(false);
    }

    void Update() {
        if(nombre.text!= "" && contrasena.text!= "") {
            boton.SetActive(true);
        }
    }

    public void presionar() {
        Variables.nombre = nombre.text;
        Variables.contrasena = contrasena.text;
        //SceneManager.LoadScene("segunda");
    }
    public void regis() {
        SceneManager.LoadScene("Register");
    }
}
