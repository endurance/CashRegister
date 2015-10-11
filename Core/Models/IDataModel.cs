namespace CashRegister.Core.Models
{
    public interface IDataModel<TKeyType>
    {
        TKeyType Id { get; set; }
    }
}