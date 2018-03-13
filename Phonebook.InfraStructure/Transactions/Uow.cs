using Phonebook.InfraStructure.DataContexts;

namespace Phonebook.InfraStructure.Transactions
{
    public class Uow : IUow
    {
        private readonly PhoneBookDataContext _context;
        public Uow(PhoneBookDataContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
