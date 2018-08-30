using ContactInventory.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInventory.Repository
{
   public class ContactInventoryRepository : ContactInventory.Repository.IContactInventoryEFRepository
    {
       ContactInventoryContext _cic;

       public ContactInventoryRepository(ContactInventoryContext cic)
        {
            _cic = cic;
            _cic.Configuration.LazyLoadingEnabled = false;
        }

       public Entities.Contact GetContact(int ContactId)
        {
            return _cic.Contacts.FirstOrDefault(e => e.ID == ContactId);           
        }

        public IQueryable<Entities.Contact> GetContacts()
        {
            return _cic.Contacts;
        }        

        public RepositoryActionResult<Entities.Contact> InsertContact(Entities.Contact e)
        {
            try
            {
                _cic.Contacts.Add(e);
                var result = _cic.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Contact>(e, RepositoryActionStatus.Created);
                }
                else
                {
                    return new RepositoryActionResult<Contact>(e, RepositoryActionStatus.NothingModified, null);
                }

            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Contact>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<Entities.Contact> UpdateContact(Entities.Contact e)
        {
            try
            {

                // you can only update when an contact already exists for this id

                var existingContact = _cic.Contacts.FirstOrDefault(exp => exp.ID == e.ID);

                if (existingContact == null)
                {
                    return new RepositoryActionResult<Contact>(e, RepositoryActionStatus.NotFound);
                }

                // change the original entity status to detached; otherwise, we get an error on attach
                // as the entity is already in the dbSet

                // set original entity state to detached
                _cic.Entry(existingContact).State = EntityState.Detached;

                // attach & save
                _cic.Contacts.Attach(e);

                // set the updated entity state to modified, so it gets updated.
                _cic.Entry(e).State = EntityState.Modified;


                var result = _cic.SaveChanges();
                if (result > 0)
                {
                    return new RepositoryActionResult<Contact>(e, RepositoryActionStatus.Updated);
                }
                else
                {
                    return new RepositoryActionResult<Contact>(e, RepositoryActionStatus.NothingModified, null);
                }
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Contact>(null, RepositoryActionStatus.Error, ex);
            }
        }

        public RepositoryActionResult<Entities.Contact> DeleteContact(int ContactId)
        {
            try
            {
                var exp = _cic.Contacts.Where(e => e.ID == ContactId).FirstOrDefault();
                if (exp != null)
                {
                    _cic.Contacts.Remove(exp);
                    _cic.SaveChanges();
                    return new RepositoryActionResult<Contact>(null, RepositoryActionStatus.Deleted);
                }
                return new RepositoryActionResult<Contact>(null, RepositoryActionStatus.NotFound);
            }
            catch (Exception ex)
            {
                return new RepositoryActionResult<Contact>(null, RepositoryActionStatus.Error, ex);
            }
        }
    }
}
