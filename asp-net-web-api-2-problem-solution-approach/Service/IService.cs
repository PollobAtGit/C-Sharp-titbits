using DAL;
using Model;
using System.Threading.Tasks;

namespace Service
{
    public interface IService
    {
        IItemRepository Repository { get; }

        Task<Item> GetById(int id);

        void AddItem(Item newItem);
    }
}