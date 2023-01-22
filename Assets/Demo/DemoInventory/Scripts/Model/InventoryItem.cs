﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace HyperInstanceModelCollection
{
    [Serializable]
    public class InventoryItem : Instance<InventoryItemSO>
    {
        public int initialLevel;
        public string itemClass;
        public string itemName;
        public List<InventoryItem> _otherReferences = new List<InventoryItem>();
    }
}



