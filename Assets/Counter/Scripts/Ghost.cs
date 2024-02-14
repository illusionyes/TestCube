using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Ghost : MonoBehaviour
{
    [SerializeField] private GameObject buildPrefab;
    public int index;

    private bool readyBuild = true;
    private Color defaultColor;
    private Counter script;
    private void Start()
    {
        defaultColor = new Color(0.66f, 1f, 1f, 0.35f);
        gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;
        
        script = GameObject.Find("Box").GetComponent<Counter>();
        script.text.gameObject.SetActive(true);
    }

    private void Update()
    {
        Biuld(index);
    }

    public void Biuld(int indexP)
    {

        if (Input.GetKey(KeyCode.E) && readyBuild)
        {
            var liveObject = Instantiate(buildPrefab, transform.position, buildPrefab.transform.rotation);
            var scale = this.gameObject.transform.localScale;
            var rb = liveObject.GetComponent<Rigidbody>();
            Destroy(rb);
            liveObject.transform.localScale = scale;
            readyBuild = false;
            script.counts[indexP]--;
            script.ChangeText(indexP);
            DestroyGhost();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.78f,0.04f,0.2f,0.3f);
        readyBuild = false;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        gameObject.GetComponent<MeshRenderer>().material.color = defaultColor;
        readyBuild = true;
    }

    public void DestroyGhost()
    {
        script.text.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
