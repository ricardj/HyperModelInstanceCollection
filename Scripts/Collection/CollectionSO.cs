using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public class CollectionSO<T> : ScriptableObject, ITypelessCollectionSO
{

    [Serializable]
    public class CollectionItemEvent : UnityEvent<T> { }


    //[SerializeReference]
    [SerializeField]
    List<T> _collectionList;

    [Header("Events")]
    public CollectionItemEvent OnItemAdded;
    public CollectionItemEvent OnItemRemoved;
    public UnityEvent OnCollectionUpdated;

    public List<T> CollectionList
    {
        get
        {
            CheckNullCollectionList();
            return _collectionList;
        }
        set
        {
            CheckNullCollectionList();
            _collectionList = value;
        }
    }


    private void CheckNullCollectionList()
    {
        if (_collectionList == null)
        {
            _collectionList = new List<T>();
        }
    }

    public void AddItem(T item)
    {
        if (!CollectionList.Contains(item))
        {
            CollectionList.Add(item);
            OnItemAdded.Invoke(item);
            OnCollectionUpdated.Invoke();
        }
    }

    public void AddItem(List<T> inventorySlots)
    {
        CollectionList.AddRange(inventorySlots);
        OnCollectionUpdated.Invoke();
    }

    public void RemoveItem(T item)
    {
        if (CollectionList.Contains(item))
        {
            CollectionList.Remove(item);
            OnItemRemoved.Invoke(item);
            OnCollectionUpdated.Invoke();
        }
    }
    public List<T> GetItems()
    {
        return CollectionList;
    }

    public void Clear()
    {
        CollectionList.Clear();
    }

    public T GetRandomItem()
    {
        if (CollectionList.Count > 0)
        {
            return CollectionList[Random.Range(0, CollectionList.Count)];
        }
        return default(T);
    }

    public int GetCount()
    {
        return CollectionList.Count;
    }

    public void SetUnique(T unique)
    {
        Clear();
        AddItem(unique);
    }

    public T GetUnique()
    {
        if (GetCount() >= 1)
        {
            return CollectionList[0];
        }
        return default(T);
    }
}


public interface ITypelessCollectionSO
{
    int GetCount();
}
