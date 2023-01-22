using HyperInstanceModelCollection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Networking.UnityWebRequest;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] InventoryItemSO _itemModel2;
    [SerializeField] InventoryItemSO _itemModel;
    [SerializeField] string _result;


    [SerializeField] List<InventoryItem> _instances;
    [SerializeField] InventoryItem _unserializedItem;
    public bool loadOnStart = true;


    // Start is called before the first frame update
    void Start()
    {
        if (loadOnStart)
        {
            LoadMemory();
        }
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadMemory();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveMemory();
        }
    }

    private void SaveMemory()
    {
        InventoryItem newItem = _itemModel.GetInstance();
        InventoryItem newItem2 = _itemModel2.GetInstance();
        newItem._otherReferences.Add(newItem2);
        _instances.Add(newItem);
        _instances.Add(newItem2);

        string result = InstanceSerializer.SerializeInstance(newItem);

        _result = result;

        PlayerPrefs.SetString("Hello", result);
    }

    private void LoadMemory()
    {
        string result = PlayerPrefs.GetString("Hello");
        _unserializedItem = InstanceSerializer.DeserializeInstance<InventoryItem, InventoryItemSO>(result);
    }
}
