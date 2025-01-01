public class ArmorItem : EquipItem<ArmorType>
{
    private ArmorItemData data;

    public ArmorItem(ArmorItemData data) : base(data)
    {
        this.data = data;
    }

    public override ArmorType GetItemTypeValue()
    {
        return data.GetArmorType();
    }
}