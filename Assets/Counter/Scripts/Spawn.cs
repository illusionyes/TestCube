using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawn : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public GameObject[] prefabs;
    public int count;

    private void Start()
    {
        count = 10;
        countText.SetText("Spawn Item " + count);
        StartCoroutine(Spawner());
    }

    private void SpawnRandomObj()
    {
        if (count > 0)
        {
            var index = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[index], GetRandomPos(), prefabs[index].transform.rotation);
            count--;
            countText.SetText("Spawn Item " + count);
        }
        else
        {
            StopCoroutine(Spawner());
        }
    }

    private Vector3 GetRandomPos()
    {
        var x = Random.Range(-4f,4);
        var y = Random.Range(12f,15f);
        var z = Random.Range(-4f,4f);
        return new Vector3(x, y, z);
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            SpawnRandomObj();
        }
    }
}
