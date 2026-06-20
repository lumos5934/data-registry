
namespace LLib
{
    public interface ICondition<T>
    {
        bool IsValid(T item);
    }
}
