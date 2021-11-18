using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabsGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform[] prefabs;

    [SerializeField]
    private KeyCode key = KeyCode.G;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Generate();
        }
    }

    private void Generate()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, Quaternion.identity, transform);
    }
}
