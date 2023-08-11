
using UnityEngine;

public class NetworkManagerHud : MonoBehaviour
{
    private string hudPath= "NetworkManagerHud"; // 

    void Start()
    {
        GameObject hud = Resources.Load<GameObject>(hudPath);

        if (hud != null)
        {
            var obj = Instantiate(hud);
            DontDestroyOnLoad(obj);
        }
        else
        {
            Debug.LogError("Prefab yüklenemedi: " + hudPath);
        }
    }

}
