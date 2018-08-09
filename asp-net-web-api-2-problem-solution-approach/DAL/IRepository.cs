using Model;
using System.Threading.Tasks;

namespace DAL
{
    public interface IItemRepository
    {
        Task<Item> GetById(int id);

        void AddItem(Item newItem);
    }
}