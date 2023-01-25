using ModelInstanceCollection;
using System;
using System.Collections.Generic;

[Serializable]
public class ResourcesPersistency : IPersistentData
{
    public List<ResourceConfiguration> _resourceConfigurations;
}

