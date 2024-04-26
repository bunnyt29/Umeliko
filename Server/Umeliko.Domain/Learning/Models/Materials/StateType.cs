namespace Umeliko.Domain.Learning.Models.Materials;

using Common.Models;

public class StateType : Enumeration
{
    public static readonly StateType None = new StateType(1, nameof(None));
    public static readonly StateType Pending = new StateType(2, nameof(Pending));
    public static readonly StateType Disapproved = new StateType(3, nameof(Disapproved));
    public static readonly StateType Approved = new StateType(4, nameof(Approved));

    private StateType(int value)
        : this(value, FromValue<StateType>(value).Name)
    {
    }

    private StateType(int value, string name)
        : base(value, name)
    {
    }
}
