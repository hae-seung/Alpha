public class AccItem : EquipItem<AccType>
{
    private AccType accType;

    public AccItem(AccItemData data, AccType type) : base(data)
    {
        accType = type;
    }

    public override AccType GetItemTypeValue()
    {
        return accType;
    }
}