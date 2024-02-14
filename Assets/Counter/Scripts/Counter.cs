using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI[] SphereCubeCapsuleTexts;
    public TextMeshProUGUI text;
    public int[] counts;
    public GameObject[] ghostPrefab;
    public static GameObject boxObj;
    public Vector3 posForGhost = new (5, 3, 5);
    private GameObject currentGhost;
    private bool haveGhost;
    private string[] names = {"Sphere","Cube","Capsule"};
    private void Start()
    {
        boxObj = this.gameObject;
        DefaultVAlue();
    }
    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (other.gameObject.CompareTag(names[i]))
            {
                counts[i]++;
                ChangeText(i);
            }
        }
        Destroy(other.gameObject);
    }

    private void DefaultVAlue()
    {
        ChangeText(0);
        ChangeText(1);
        ChangeText(2);
    }

    public void ChangeText(int textInt)
    {
        SphereCubeCapsuleTexts[textInt].SetText(names[textInt] + ": " + counts[textInt]);
    }

    public void ChooseItem(int indexButton)
    {
        if (counts[indexButton] > 0)
        {
            ChangeText(indexButton);
            ActiveGhost(indexButton);
        }
        var movement = GetComponent<Movement>();
        Destroy(movement);
    }

    private void ActiveGhost(int indexGhost)
    {
        var ghost = ghostPrefab[indexGhost];
        if (haveGhost == true)
        {
            currentGhost = GameObject.FindWithTag("Ghost");
            Destroy(currentGhost);
        }
        var objectGhost = Instantiate(ghost, posForGhost,ghostPrefab[indexGhost].transform.rotation);
        var ghostScript = objectGhost.GetComponent<Ghost>();
        ghostScript.boxOblect = this.gameObject;
        haveGhost = true;
    }
}
