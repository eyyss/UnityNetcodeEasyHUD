using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NetworkManagerHudButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum ButtonType
    {
        StartHost,StartClient,StartServer
        
    };

    public ButtonType buttonType;
    private Vector2 enterScale ;
    private Vector2 exitScale;
    private Button button;
    public bool isEnter;

    public void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            switch (buttonType)
            {
                case ButtonType.StartHost:
                    NetworkManager.Singleton.StartHost();
                    break;
                case ButtonType.StartClient:
                    NetworkManager.Singleton.StartClient();
                    break;
                case ButtonType.StartServer:
                    NetworkManager.Singleton.StartServer();
                    break;
            }
        });
        exitScale = transform.localScale;
        enterScale = exitScale + new Vector2(.1f, .1f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isEnter = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isEnter = false;
    }
    private void LateUpdate()
    {
        if (isEnter)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, enterScale,Time.deltaTime*6);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, exitScale, Time.deltaTime * 6);
        }
    }

}
