using ModelInstanceCollection;
using UnityEngine;

[CreateAssetMenu(menuName = "Hyper Scriptables/NEw resource configuration")]
public class ResourceConfigurationSO : ModelSO<ResourceConfiguration>
{
    [SerializeField] string _resourceName;
    public override ResourceConfiguration GetInstance()
    {
        return this.SetupModel(new ResourceConfiguration()
        {
            name = _resourceName,
            amount = 0
        });
    }
}