namespace PhoneBook.Shared.ResultTypes
{
    public interface IDataResult<out T>:IResult
    {
        T Data { get; }
    }
}
