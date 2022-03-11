using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreesAction : MonoBehaviour
{
    public Button btn_Object_Chat;
    public Text txt_name;
    void Start()
    {
        btn_Object_Chat.onClick.AddListener(delegate
        {
            webApi.FrindUsername = txt_name.text;
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainChat");
        });
    }
}
