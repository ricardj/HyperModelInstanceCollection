using ModelInstanceCollection;
using UnityEngine;

[CreateAssetMenu(menuName ="Hyper Scriptables/NEw resource configuration")]
public class ResourceConfigurationSO : ModelSO<ResourceConfiguration>
{
    public override ResourceConfiguration GetInstance()
    {
        return this.SetupModel(new ResourceConfiguration()
        {

        });
    }
}