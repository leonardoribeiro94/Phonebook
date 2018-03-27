using Phonebook.Domain.Repositories;
using System.Web.Http;

namespace Phonebook.Api.Controllers
{
    public class DefaultController : ApiController
    {
        private readonly IContactOwnerRepository _contactOwnerRepository;

        public DefaultController(IContactOwnerRepository contactOwnerRepository)
        {
            _contactOwnerRepository = contactOwnerRepository;
        }

        // GET: api/Default
        public IHttpActionResult Get()
        {
            return Ok(_contactOwnerRepository.Get());
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
