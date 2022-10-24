using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    // Start is called before the first frame update
    private static teste _Instance;
    public static teste Instance
    {
        get
        {
            if (!_Instance)
            {
                _Instance = new GameObject().AddComponent<teste>();
                // name it for easy recognition
                _Instance.name = _Instance.GetType().ToString();
                // mark root as DontDestroyOnLoad();
                DontDestroyOnLoad(_Instance.gameObject);
            }
            return _Instance;
        }
    }
}
