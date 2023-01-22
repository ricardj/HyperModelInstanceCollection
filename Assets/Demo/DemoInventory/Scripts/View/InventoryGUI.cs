using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperInstanceModelCollection
{

    public class InventoryGUI : MonoBehaviour
    {
        
        [SerializeField] InventoryCollectionSO _inventoryCollection;
        public void OnEnable()
        {
            _inventoryCollection.OnCollectionUpdated.AddListener(UpdateList);
        }
        public void OnDisable()
        {
            _inventoryCollection.OnCollectionUpdated.RemoveListener(UpdateList);
        }

        private void UpdateList()
        {

        }

        public void Start()
        {
            
        }

    }

}
