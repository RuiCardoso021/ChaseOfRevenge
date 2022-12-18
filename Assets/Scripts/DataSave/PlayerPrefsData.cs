using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Newtonsoft.Json.Linq;
using UnityEngine.UIElements;

public class PlayerPrefsData : MonoBehaviour
{

    public enum ExtensionType
    {
        PlayerPrefs,
    }
    public ExtensionType extensionType;
    public int sceneID;

    //Save
    public void SaveFloat(string key, float value)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            PlayerPrefs.SetFloat(key + sceneID, value);
        }
    }

    public void SaveInt(string key, int value)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            PlayerPrefs.SetInt(key + sceneID, value);
        }
    }

    public void SaveBool(string key, bool value)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            PlayerPrefs.SetInt(key + sceneID, Convert.ToInt32(value));
        }
    }

    public void SaveString(string key, string text)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            PlayerPrefs.SetString(key + sceneID, text);
        }
    }

    public void SaveDouble(string key, double value)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            string yString = value.ToString();
            PlayerPrefs.SetString(key + sceneID, yString);
        }
    }

    public void SaveVector3(string key, Vector3 vector)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            PlayerPrefs.SetFloat(key + sceneID + "x", vector.x);
            PlayerPrefs.SetFloat(key + sceneID + "y", vector.y);
            PlayerPrefs.SetFloat(key + sceneID + "z", vector.z);
        }
    }

    public void SaveVector2(string key, Vector2 vector)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            PlayerPrefs.SetFloat(key + sceneID + "x", vector.x);
            PlayerPrefs.SetFloat(key + sceneID + "y", vector.y);
        }
    }

    public void SaveQuaternion(string key, Quaternion quaternion)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            PlayerPrefs.SetFloat(key + sceneID + "x", quaternion.x);
            PlayerPrefs.SetFloat(key + sceneID + "y", quaternion.y);
            PlayerPrefs.SetFloat(key + sceneID + "z", quaternion.z);
            PlayerPrefs.SetFloat(key + sceneID + "w", quaternion.w);
        }
    }

    public void SaveFloatArray(string key, float[] array, int length)
    {
        for (int x = 0; x < array.Length; x++)
        {
            PlayerPrefs.SetFloat(key + x + "" + sceneID, array[x]);
            PlayerPrefs.SetInt(key + "Length" + sceneID, length);
        }
    }

    public void SaveIntArray(string key, int[] array, int length)
    {
        for (int x = 0; x < array.Length; x++)
        {
            PlayerPrefs.SetInt(key + x + "" + sceneID, array[x]);
            PlayerPrefs.SetInt(key + "Length" + sceneID, length);
        }
    }

    public void SaveBoolArray(string key, bool[] array, int length)
    {
        for (int x = 0; x < array.Length; x++)
        {
            PlayerPrefs.SetInt(key + x + "" + sceneID, Convert.ToInt32(array[x]));
            PlayerPrefs.SetInt(key + "Length" + sceneID, length);
        }
    }

    public void SaveStringArray(string key, string[] array, int length)
    {
        for (int x = 0; x < array.Length; x++)
        {
            PlayerPrefs.SetString(key + x + "" + sceneID, array[x]);
            PlayerPrefs.SetInt(key + "Length" + sceneID, length);
        }
    }

    public void SaveDoubleArray(string key, double[] array, int length)
    {
        for (int x = 0; x < array.Length; x++)
        {
            PlayerPrefs.SetString(key + x + "" + sceneID, array[x].ToString());
            PlayerPrefs.SetInt(key + "Length" + sceneID, length);
        }
    }

    public void SaveVector3Array(string key, Vector3[] array, int length)
    {
        for (int x = 0; x < array.Length; x++)
        {
            PlayerPrefs.SetFloat(key + x + "x" + sceneID, array[x].x);
            PlayerPrefs.SetFloat(key + x + "y" + sceneID, array[x].y);
            PlayerPrefs.SetFloat(key + x + "z" + sceneID, array[x].z);
            PlayerPrefs.SetInt(key + "Length" + sceneID, length);
        }
    }

    public void SaveVector2Array(string key, Vector2[] array, int length)
    {
        for (int x = 0; x < array.Length; x++)
        {
            PlayerPrefs.SetFloat(key + x + "x" + sceneID, array[x].x);
            PlayerPrefs.SetFloat(key + x + "y" + sceneID, array[x].y);
            PlayerPrefs.SetInt(key + "Length" + sceneID, length);
        }
    }

    public void SaveQuaternionArray(string key, Quaternion[] array, int length)
    {
        for (int x = 0; x < array.Length; x++)
        {
            PlayerPrefs.SetFloat(key + x + "x" + sceneID, array[x].x);
            PlayerPrefs.SetFloat(key + x + "y" + sceneID, array[x].y);
            PlayerPrefs.SetFloat(key + x + "z" + sceneID, array[x].z);
            PlayerPrefs.SetFloat(key + x + "w" + sceneID, array[x].w);
            PlayerPrefs.SetInt(key + "Length" + sceneID, length);
        }
    }

    //Load
    public float LoadFloat(string key)
    {
        float load = PlayerPrefs.GetFloat(key + sceneID);
        return load;
    }

    public int LoadInt(string key)
    {
        int load = PlayerPrefs.GetInt(key + sceneID);
        return load;
    }

    public bool LoadBool(string key)
    {
        bool load = Convert.ToBoolean(PlayerPrefs.GetInt(key + sceneID));
        return load;
    }

    public string LoadString(string key)
    {
        string text = PlayerPrefs.GetString(key + sceneID);
        return text;
    }

    public double LoadDouble(string key)
    {
        string yString = PlayerPrefs.GetString(key + sceneID);
        double value = double.Parse(yString, System.Globalization.CultureInfo.InvariantCulture);
        return value;
    }

    public Vector2 LoadVector2(string key)
    {
        Vector2 vector = new Vector3(PlayerPrefs.GetFloat(key + sceneID + "x"), PlayerPrefs.GetFloat(key + sceneID + "y"));
        return vector;
    }

    public Vector3 LoadVector3(string key)
    {
        Vector3 vector = new Vector3(PlayerPrefs.GetFloat(key + sceneID + "x"), PlayerPrefs.GetFloat(key + sceneID + "y"),
        PlayerPrefs.GetFloat(key + sceneID + "z"));
        return vector;
    }

    public Quaternion LoadQuaternion(string key)
    {
        Quaternion quaternion = new Quaternion(PlayerPrefs.GetFloat(key + sceneID + "x"), PlayerPrefs.GetFloat(key + sceneID + "y"),
        PlayerPrefs.GetFloat(key + sceneID + "z"), PlayerPrefs.GetFloat(key + sceneID + "w"));
        return quaternion;
    }

    public float[] LoadFloatArray(string key)
    {
        float[] array = new float[PlayerPrefs.GetInt(key + "Length" + sceneID)];
        for (int x = 0; x < array.Length; x++)
        {
            array[x] = PlayerPrefs.GetFloat(key + x + "" + sceneID);
        }
        return array;
    }

    public int[] LoadIntArray(string key)
    {
        int[] array = new int[PlayerPrefs.GetInt(key + "Length" + sceneID)];
        for (int x = 0; x < array.Length; x++)
        {
            array[x] = PlayerPrefs.GetInt(key + x + "" + sceneID);
        }
        return array;
    }

    public bool[] LoadBoolArray(string key)
    {
        bool[] array = new bool[PlayerPrefs.GetInt(key + "Length" + sceneID)];
        for (int x = 0; x < array.Length; x++)
        {
            array[x] = Convert.ToBoolean(PlayerPrefs.GetInt(key + x + "" + sceneID));
        }
        return array;
    }

    public string[] LoadStringArray(string key)
    {
        string[] array = new string[PlayerPrefs.GetInt(key + "Length" + sceneID)];
        for (int x = 0; x < array.Length; x++)
        {
            array[x] = PlayerPrefs.GetString(key + x + "" + sceneID);
        }
        return array;
    }

    public double[] LoadDoubleArray(string key)
    {
        double[] array = new double[PlayerPrefs.GetInt(key + "Length" + sceneID)];
        for (int x = 0; x < array.Length; x++)
        {
            array[x] = double.Parse(PlayerPrefs.GetString(key + x + "" + sceneID), System.Globalization.CultureInfo.InvariantCulture);
        }
        return array;
    }

    public Vector2[] LoadVector2Array(string key)
    {
        Vector2[] array = new Vector2[PlayerPrefs.GetInt(key + "Length" + sceneID)];
        for (int x = 0; x < array.Length; x++)
        {
            array[x].x = PlayerPrefs.GetFloat(key + x + "x" + sceneID, array[x].x);
            array[x].y = PlayerPrefs.GetFloat(key + x + "y" + sceneID, array[x].y);
        }
        return array;
    }

    public Vector3[] LoadVector3Array(string key)
    {
        Vector3[] array = new Vector3[PlayerPrefs.GetInt(key + "Length" + sceneID)];
        for (int x = 0; x < array.Length; x++)
        {
            array[x].x = PlayerPrefs.GetFloat(key + x + "x" + sceneID, array[x].x);
            array[x].y = PlayerPrefs.GetFloat(key + x + "y" + sceneID, array[x].y);
            array[x].z = PlayerPrefs.GetFloat(key + x + "z" + sceneID, array[x].z);
        }
        return array;
    }

    public Quaternion[] LoadQuaternionArray(string key)
    {
        Quaternion[] array = new Quaternion[PlayerPrefs.GetInt(key + "Length" + sceneID)];
        for (int x = 0; x < array.Length; x++)
        {
            array[x].x = PlayerPrefs.GetFloat(key + x + "x" + sceneID, array[x].x);
            array[x].y = PlayerPrefs.GetFloat(key + x + "y" + sceneID, array[x].y);
            array[x].z = PlayerPrefs.GetFloat(key + x + "z" + sceneID, array[x].z);
            array[x].w = PlayerPrefs.GetFloat(key + x + "w" + sceneID, array[x].w);
        }
        return array;
    }

    public void DeleteBasicKey(string key)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            PlayerPrefs.DeleteKey(key + sceneID);
        }
    }

    public void DeleteVector2(string key)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            PlayerPrefs.DeleteKey(key + sceneID + "x");
            PlayerPrefs.DeleteKey(key + sceneID + "y");
        }
    }

    public void DeleteVector3(string key)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            PlayerPrefs.DeleteKey(key + sceneID + "x");
            PlayerPrefs.DeleteKey(key + sceneID + "y");
            PlayerPrefs.DeleteKey(key + sceneID + "z");
        }
    }

    public void DeleteQuaternion(string key)
    {
        if (extensionType == ExtensionType.PlayerPrefs)
        {
            PlayerPrefs.DeleteKey(key + sceneID + "x");
            PlayerPrefs.DeleteKey(key + sceneID + "y");
            PlayerPrefs.DeleteKey(key + sceneID + "z");
            PlayerPrefs.DeleteKey(key + sceneID + "w");
        }
    }

    public void DeleteArrayBasicArray(string key)
    {
        int[] array = new int[PlayerPrefs.GetInt(key + "Length" + sceneID)];
        for (int x = 0; x < array.Length; x++)
        {
            PlayerPrefs.DeleteKey(key + x + "" + sceneID);
        }
        PlayerPrefs.DeleteKey(key + "Length" + sceneID);
    }
}
