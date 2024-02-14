using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI[] SphereCubeCapsuleTexts;
    public TextMeshProUGUI text;

    public int[] counts;
    public GameObject[] ghostPrefab;
    private GameObject currentGhost;

    private bool haveGhost;
    private void Start()
    {
        DefaultVAlue();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sphere"))
        {
            counts[0]++;
            ChangeText(0);
        }
        else if (other.gameObject.CompareTag("Cube"))
        {
            counts[1]++;
            ChangeText(1);
        }
        else if (other.gameObject.CompareTag("Capsule"))
        {
            counts[2]++;
            ChangeText(2);
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
        switch (textInt)
        {
            case 0 :
                SphereCubeCapsuleTexts[0].SetText("Sphere: " + counts[0]);
                return;
            case 1 :
                SphereCubeCapsuleTexts[1].SetText("Cube: " + counts[1]);
                return;
            case 2 :
                SphereCubeCapsuleTexts[2].SetText("Capsule: " + counts[2]);
                return;
        }
    }

    public void ChooseItem(int indexButton)
    {
        switch (indexButton)
        {
            case 0:
                if (counts[0] > 0)
                {
                    ChangeText(0);
                    ActiveGhost(0);
                }
                else
                {
                    Debug.Log("Not enough minerals");
                }
                break;

            case 1:
                if (counts[1] > 0)
                {
                    ChangeText(1);
                    ActiveGhost(1);
                }
                break;
            case 2:
                if (counts[2] > 0)
                {
                    ChangeText(2);
                    ActiveGhost(2);
                }
                break;
            default:
                Debug.Log("OutOfBound index");
                break;
        }

        var movement = GetComponent<Movement>();
        Destroy(movement);
    }

    private void ActiveGhost(int indexGhost)
    {
        var ghost = ghostPrefab[indexGhost];
        if (haveGhost == false)
        {
            Instantiate(ghost, new Vector3(5, 3, 5),ghostPrefab[indexGhost].transform.rotation);
            haveGhost = true;
        }
        else
        {
            currentGhost = GameObject.FindWithTag("Ghost");
            Destroy(currentGhost);
            Instantiate(ghost, new Vector3(5, 3, 5),ghostPrefab[indexGhost].transform.rotation);
        }
    }
}
