namespace Ch_11.Controllers
{
    public interface IService
    {
        IItemRepository Repository { get; }

        Item GetById(int id);
        void AddItem(Item newItem);
    }
}