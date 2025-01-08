public class ArmorItem : EquipItem<ArmorType>
{
    private ArmorItemData data;
    private ArmorType type;

    public ArmorItem(ArmorItemData data) : base(data)
    {
        this.data = data;
        type = data.GetArmorType();
    }

    public override ArmorType GetItemTypeValue()
    {
        return type;
    }
}