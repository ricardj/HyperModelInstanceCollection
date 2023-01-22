using ModelInstanceCollection;
using UnityEngine;

public class ShopItemSO : ModelSO<ShopItem>
{
    [SerializeField] int _price;
    [SerializeField] Sprite _sprite;


    public override ShopItem GetInstance()
    {
        return SetupModel(new ShopItem()
        {

        });
    }
}
