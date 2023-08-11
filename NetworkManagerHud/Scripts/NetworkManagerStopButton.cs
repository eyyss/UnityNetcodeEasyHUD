using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerStopButton : MonoBehaviour
{
    public GameObject verticalMenu;
    public Button button;
    public Image image;
    public Text text;


    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.Shutdown();
            button.enabled = false;
            image.enabled = false;
            text.enabled = false;
            verticalMenu.SetActive(true);
        });
    }

    private void OnEnable()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += Singleton_OnClientConnectedCallback;
        NetworkManager.Singleton.OnClientStarted += Singleton_OnClientStarted;
        NetworkManager.Singleton.OnServerStarted += Singleton_OnServerStarted;
    }


    private void OnDisable()
    {
        if (NetworkManager.Singleton!=null)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= Singleton_OnClientConnectedCallback;
            NetworkManager.Singleton.OnClientStarted -= Singleton_OnClientStarted;
            NetworkManager.Singleton.OnServerStarted -= Singleton_OnServerStarted;
        }
    }
    private void Singleton_OnServerStarted()
    {
        button.enabled = true;
        image.enabled = true;
        text.enabled = true;
        verticalMenu.SetActive(false);
    }

    private void Singleton_OnClientStarted()
    {
        button.enabled = true;
        image.enabled = true;
        text.enabled = true;
        verticalMenu.SetActive(false);
    }
    private void Singleton_OnClientConnectedCallback(ulong obj)
    {
        button.enabled = true;
        image.enabled = true;
        text.enabled = true;
        verticalMenu.SetActive(false);
    }
}
