using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;

public class ListChat : MonoBehaviour
{
    private string url = "http://localhost/ProjectTest/ListMessage.php";
    [SerializeField] private List<string> ReseveData = new List<string>();
    [SerializeField] private List<string> oldListChat = new List<string>();
    [SerializeField] private List<string> saveListChat = new List<string>();
    [SerializeField] private List<string> DeletedItem = new List<string>();
    private int positon = -50;

    public RectTransform Panel;
    public GameObject Message;

    private bool FirstTime = false;

    private void Start()
    {
        StartCoroutine(Getlistchat());
    }

    private IEnumerator Getlistchat()
    {
        while (true)
        {
            string data = webApi.sendData(url, new Dictionary<string, string>
        {
            {"user" , webApi.MyUsername}
        });
            if (data != "[]")
            {
                ReseveData = JsonConvert.DeserializeObject<List<string>>(data);
                saveListChat.Clear();
                saveListChat.AddRange(ReseveData);

                if (oldListChat.Count != 0 && oldListChat.Count != ReseveData.Count)
                {
                    for (int i = 0; i < ReseveData.Count; i++)
                    {
                        for (int j = 0; j < oldListChat.Count; j++)
                        {
                            //----------------------------------
                            if (ReseveData[i] == oldListChat[j])
                            {
                                DeletedItem.Add(ReseveData[i]);
                                break;
                            }
                        }
                    }
                    AddItemV(ReseveData);
                }
                if (FirstTime == false)
                {
                    AddItem(ReseveData);
                    FirstTime = true;
                }
                oldListChat.Clear();
                oldListChat.AddRange(saveListChat);
                ReseveData.Clear();
            }
            yield return new WaitForSeconds(1f);
        }
    }
    private void AddItem(List<string> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            Panel.sizeDelta = new Vector2(Panel.sizeDelta.x, Panel.sizeDelta.y + 100);
            GameObject v = Instantiate(Message, new Vector2(0, 0), Panel.rotation, Panel.transform);
            v.GetComponent<RectTransform>().anchoredPosition = (new Vector2(0, positon));
            string Name = data[i].Split('-')[0] == webApi.MyUsername ? data[i].Split('-')[1] : data[i].Split('-')[0];
            v.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = Name;
            positon -= 100;
        }
    }
    private void AddItemV(List<string> data)
    {
        bool breakAddItem = false;
        for (int i = 0; i < data.Count; i++)
        {
            for (int j = 0; j < DeletedItem.Count; j++)
            {
                if (data[i] == DeletedItem[j])
                {
                    breakAddItem = true;
                    DeletedItem.RemoveAt(j);
                    break;
                }
            }
            if (breakAddItem == true) { breakAddItem = false; continue; }

            Panel.sizeDelta = new Vector2(Panel.sizeDelta.x, Panel.sizeDelta.y + 100);
            GameObject v = Instantiate(Message, new Vector2(0, 0), Panel.rotation, Panel.transform);
            v.GetComponent<RectTransform>().anchoredPosition = (new Vector2(0, positon));
            string Name = data[i].Split('-')[0] == webApi.MyUsername ? data[i].Split('-')[1] : data[i].Split('-')[0];
            v.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = Name;
            positon -= 100;
        }
    }
}