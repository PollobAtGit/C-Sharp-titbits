namespace Ch_11.Controllers
{
    public interface IItemRepository
    {
        Item GetById(int id);
        void AddItem(Item newItem);
    }
}