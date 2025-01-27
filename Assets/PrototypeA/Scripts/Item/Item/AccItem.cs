

public class AccItem : EquipItem<AccType>
{
    private AccItemData data;
    private AccType accType;

    public AccItem(AccItemData data) : base(data)
    {
        this.data = data;
        accType = data.GetAccType();
    }


    public override AccType GetItemTypeValue()
    {
        return accType;
    }
}