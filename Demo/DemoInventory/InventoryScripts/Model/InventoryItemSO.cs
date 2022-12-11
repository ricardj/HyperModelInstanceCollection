using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HyperInstanceModelCollection
{
    [CreateAssetMenu]
    public class InventoryItemSO : ModelSO<InventoryItem>
    {
        public override InventoryItem GetInstance()
        {
            return SetupModel(new InventoryItem());
        }
    }
}




