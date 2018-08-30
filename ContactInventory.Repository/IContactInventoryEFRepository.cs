using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInventory.Repository
{
   public interface IContactInventoryEFRepository
    {
        ContactInventory.Repository.Entities.Contact GetContact(int ContactId);
        System.Linq.IQueryable<ContactInventory.Repository.Entities.Contact> GetContacts();
        RepositoryActionResult<ContactInventory.Repository.Entities.Contact> InsertContact(ContactInventory.Repository.Entities.Contact e);
        RepositoryActionResult<ContactInventory.Repository.Entities.Contact> UpdateContact(ContactInventory.Repository.Entities.Contact e);
        RepositoryActionResult<ContactInventory.Repository.Entities.Contact> DeleteContact(int ContactId);
    }
}
