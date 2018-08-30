using ContactInventory.Repository;
using ContactInventory.Repository.Entities;
using ContactInventory.Repository.Factories;
using Marvin.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactInventory.API.Controllers
{
    [RoutePrefix("api")]
    public class ContactController : ApiController
    {
        IContactInventoryEFRepository _repository;
        ContactFactory _contactFactory = new ContactFactory();
        
        public ContactController()
        {
            _repository = new ContactInventoryRepository(new Repository.Entities.ContactInventoryContext());
        }

        public ContactController(IContactInventoryEFRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Getting all the contacts from the Table with the proper Action result
        /// </summary>
        /// <returns></returns>
        [Route("contacts")]
        public IHttpActionResult Get()
        {
            try
            {
                var contact = _repository.GetContacts().ToList();
                if (contact != null)
                {
                    return Ok(contact);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Getting particular contact details from the Table with the proper Action result. 
        /// We need to send the Contact ID for this
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("contacts/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Repository.Entities.Contact contact = null;

                contact = _repository.GetContact(id);
                if (contact != null)
                {
                    var returnValue = _contactFactory.CreateContact(contact);
                    return Ok(returnValue);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Delete particular contact details from the Table with the proper Action result. 
        /// We need to send the Contact ID for this
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("contacts/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                var result = _repository.DeleteContact(id);

                if (result.Status == RepositoryActionStatus.Deleted)
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Can save the Contact in the Contact Table.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [Route("contacts")]
        public IHttpActionResult Post([FromBody]Contact contact)
        {
            try
            {
                
                if (contact == null)
                {
                    return BadRequest();
                }
                if (ModelState.IsValid)
                {

                    var exp = _contactFactory.CreateContact(contact);

                    var result = _repository.InsertContact(exp);
                    if (result.Status == RepositoryActionStatus.Created)
                    {
                        var newContact = _contactFactory.CreateContact(result.Entity);
                        return Created<Contact>(Request.RequestUri + "/" + newContact.ID.ToString(), newContact);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Can update the Contact in the Contact Table.
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [Route("contacts")]        
        public IHttpActionResult Put([FromBody]Contact contact)
        {
            try
            {
                if (contact == null)
                {
                    return BadRequest();
                }

                if (ModelState.IsValid)
                {
                    var exp = _contactFactory.CreateContact(contact);

                    var result = _repository.UpdateContact(exp);
                    if (result.Status == RepositoryActionStatus.Updated)
                    {
                        var updatedContact = _contactFactory.CreateContact(result.Entity);
                        return Ok(updatedContact);
                    }
                    else if (result.Status == RepositoryActionStatus.NotFound)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }

                return BadRequest();
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

    }
}
