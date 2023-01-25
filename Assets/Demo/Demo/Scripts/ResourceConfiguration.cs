using ModelInstanceCollection;
using System;

[Serializable]
public class ResourceConfiguration : Instance<ResourceConfigurationSO>
{
    public int amount;
    public string name;
}
