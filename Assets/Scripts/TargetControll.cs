using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControll : MonoBehaviour
{
    [SerializeField] private GameObject[] tergets;

    void Start()
    {

    }

    public void ResetTarget()
    {
        foreach (var terget in tergets)
        {
            terget.gameObject.SetActive(true);
        }
    }
}
