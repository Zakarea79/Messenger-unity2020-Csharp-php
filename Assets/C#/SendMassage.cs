using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class SendMassage : MonoBehaviour
{
    private string Linkserver = "http://zakarea.mygamesonline.org/Unity_chat/sendmessage.php";

    [SerializeField] private Button btnSend;
    [SerializeField] private InputField TextMessage;

    private void Start()
    {
        btnSend.onClick.AddListener(async delegate
        {
            if (TextMessage.text != "")
            {
                string result = await webApi.sendData(Linkserver, new Dictionary<string, string>
                {
                    {"e1" , webApi.MyUsername},
                    {"e2" , webApi.FrindUsername},
                    {"txt" , TextMessage.text}
                });
                if (result == "true")
                {
                    TextMessage.text = "";
                }
            }
        });
    }

}
