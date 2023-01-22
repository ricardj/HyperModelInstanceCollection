using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperInstanceModelCollection
{
    [CreateAssetMenu]
    public class InventoryItemSO : ModelSO<InventoryItem>
    {

        [SerializeField] string _name;
        [SerializeField] string _class;
        [SerializeField] int _initialLevel;

        public override InventoryItem GetInstance()
        {
            return SetupModel(new InventoryItem()
            {
                itemName = _name,
                itemClass = _class,
                initialLevel = _initialLevel
            });
        }
    }
}




