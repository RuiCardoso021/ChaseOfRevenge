using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject spawnPoint;
    private GameObject objectPrefab;

    private GameObject _spawnedObject;

    private void Start()
    {
        objectPrefab = GameObject.Find("receivedObject");
        objectPrefab.SetActive(false);
    }

    private void Update()
    {
        if (_spawnedObject == null)
        {
            _spawnedObject = Instantiate(objectPrefab, spawnPoint.transform.position, Quaternion.identity);
            _spawnedObject.SetActive(true);
        }
    }
}
