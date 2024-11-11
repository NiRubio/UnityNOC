using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// Clase que define los datos de un usuario
[System.Serializable]
public class UserData
{
    public string username;
    public string email;
    public string password;

    // Constructor para inicializar los datos
    public UserData(string username, string email, string password)
    {
        this.username = username;
        this.email = email;
        this.password = password;
    }
}

public class ConnectApi : MonoBehaviour
{
    public string apiUrl = "http://localhost:8000/api"; 

    // UI elements
    public Text usernameInput;
    public Text emailInput;
    public Text passwordInput;
    public Text feedbackText; // Muestra mensajes de éxito o error

    // Método para el login
    public void Login()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        StartCoroutine(LoginCoroutine(username, password));
    }

    // Método para el registro
    public void Register()
    {
        string username = usernameInput.text;
        string email = emailInput.text;
        string password = passwordInput.text;

        StartCoroutine(RegisterCoroutine(username, email, password));
    }

    // Corrutina para el login
    private IEnumerator LoginCoroutine(string username, string password)
    {
        // Crear un objeto UserData para el login
        UserData loginData = new UserData(username, "", password); // Email no es necesario para login
        string jsonData = JsonUtility.ToJson(loginData);  // Convertir a JSON

        // Crear el request
        using (UnityWebRequest request = new UnityWebRequest(apiUrl + "/login", "GET"))
        {
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);

            // Enviar request y esperar la respuesta
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                // Aquí puedes procesar la respuesta, por ejemplo, mostrar un mensaje de éxito
                feedbackText.text = "Login exitoso: " + request.downloadHandler.text;
            }
            else
            {
                feedbackText.text = "Error en login: " + request.error;
            }
        }
    }

    // Corrutina para el registro
    private IEnumerator RegisterCoroutine(string username, string email, string password)
    {
        // Crear un objeto UserData para el registro
        UserData registerData = new UserData(username, email, password);
        string jsonData = JsonUtility.ToJson(registerData);  // Convertir a JSON

        // Crear el request
        using (UnityWebRequest request = new UnityWebRequest(apiUrl + "/register", "POST"))
        {
            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            // Enviar request y esperar la respuesta
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                feedbackText.text = "Registro exitoso: " + request.downloadHandler.text;
            }
            else
            {
                feedbackText.text = "Error en registro: " + request.error;
            }
        }
    }
}
