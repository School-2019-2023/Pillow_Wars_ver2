using System;
using UnityEngine;
using System.Collections.Generic;

public class BedManager : SingletonMonoBehaviour<BedManager>
{
    [SerializeField] private int activeBeds = 5;

    private List<int> beforeArr = new List<int>();
    private List<int> afterArr = new List<int>();

    public List<BoxCollider> bedColliders = new List<BoxCollider>();

    private void Start()
    {
        int childCount = transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            beforeArr.Add(i);
        }

        for (int i = 0; i < activeBeds; i++)
        {
            int activeNum = UnityEngine.Random.Range(0, beforeArr.Count);
            afterArr.Add(beforeArr[activeNum]);
            bedColliders.Add(transform.GetChild(activeNum).GetComponentInChildren<BoxCollider>());
            beforeArr.RemoveAt(activeNum);
            transform.GetChild(afterArr[i]).gameObject.SetActive(true);
        }
    }
}
