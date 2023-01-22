using ModelInstanceCollection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{

    public ResourceConfigurationInstancesCollection _resources;



}

[Serializable]
public class ResourceConfiguration : Instance<ResourceConfigurationSO>
{

}
