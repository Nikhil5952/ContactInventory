using ContactInventory.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactInventory.Repository.Factories
{
   public class ContactFactory
    {
       public ContactFactory()
        {

        }

       public Contact CreateContact(Contact contact)
        {
            return new Contact()
            {
                ID=contact.ID,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Status = contact.Status
              
            };
        }       
    }
}
