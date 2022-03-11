using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Setting_MainChat : MonoBehaviour
{
    [SerializeField] private Text Username;
    [SerializeField] private Button btn_bak;
    void Start()
    {
        Username.text = webApi.FrindUsername;
        btn_bak.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("ListChat");
        });
    }
}
