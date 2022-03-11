using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using UnityEngine.UI;

public class MainChat : MonoBehaviour
{
    void Start()
    {
        openGithubPage.onClick.AddListener(delegate
        {
            Application.OpenURL("https://github.com/Zakarea79");
        });
        InvokeRepeating("LoadMessage", 1f, 1f);
    }
    
    [SerializeField] private RectTransform Plane;
    [SerializeField] private GameObject MessageItem;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private Button openGithubPage;
    private int lengthMessage = 0;
    private int positon = -50;
    private string ChatID = "";
    private string urlMessage = "http://localhost/ProjectTest/";
    private string urlServer = "http://localhost/ProjectTest/ListGetFileMessage.php";
    private bool ChatFiend = false;
    private void LoadMessage()
    {
        if (ChatFiend == false)
        {
            string result = webApi.sendData(urlServer, new Dictionary<string, string>
                {
                    {"e1" , webApi.MyUsername},
                    {"e2" , webApi.FrindUsername}
                });
            if (result != "false")
            {
                ChatID = result;
                ChatFiend = true;
            }
        }
        if (ChatID != "")
        {
            using (WebClient client = new WebClient())
            {
                string messags = client.DownloadString(urlMessage + ChatID);

                for (int i = lengthMessage; i < messags.Split('\n').Length - 1; i++)
                {
                    Plane.sizeDelta = new Vector2(Plane.sizeDelta.x, Plane.sizeDelta.y + 105);
                    //-------------------------
                    GameObject v = Instantiate(MessageItem, new Vector2(0, 0), Plane.rotation, Plane.transform);
                    scrollbar.value = 0;
                    v.GetComponent<RectTransform>().anchoredPosition = (new Vector2(0, positon));
                    string finduser = messags.Split('\n')[i].Split(':')[0];
                    if(finduser == webApi.FrindUsername)
                    {
                        v.GetComponent<Image>().color = Color.white;
                    }
                    else
                    {
                        v.GetComponent<Image>().color = Color.green;
                    }
                    v.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = messags.Split('\n')[i].Split(':')[1];
                    positon -= 105;
                    
                }
                lengthMessage = messags.Split('\n').Length - 1;
            }
        };
    }
}
