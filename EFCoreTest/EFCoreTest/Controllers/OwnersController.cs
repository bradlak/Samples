using EFCoreTest.Data.Entities;
using EFCoreTest.Data.Interfaces;
using EFCoreTest.Data.Providers;
using EFCoreTest.Data.Repositories;
using System.Web.Http;

namespace EFCoreTest.Controllers
{
    [RoutePrefix("api/owners")]
    public class OwnersController : ApiController
    {
        SampleDataProvider dataProvider;

        public OwnersController()
        {
            dataProvider = new SampleDataProvider();
        }

        [Route("{includes:bool}")]
        public IHttpActionResult Get(bool includes)
        {
            using (var repository = new OwnersRepository())
            {
                return Ok(repository.GetCollection(includes));
            }
        }

        [Route("{id:int}/{includes:bool}")]
        public IHttpActionResult GetById(int id, bool includes)
        {
            Owner owner = null;

            using (var repository = new OwnersRepository())
            {
                owner = repository.GetById(id, includes);
            }

            if (owner != null)
            {
                return Ok(owner);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("seed")]
        [HttpGet]
        public IHttpActionResult SeedData()
        {
            var owners = dataProvider.GetSampleData();

            using (var repository = new OwnersRepository())
            {
                foreach (var owner in owners)
                {
                    repository.Create(owner);
                }
            }

            return Ok("Data seeded");
        }

        [Route("clear")]
        [HttpGet]
        public IHttpActionResult DeleteAllData()
        {
            using (var repository = new OwnersRepository())
            {
                repository.DeleteAll();
            }

            return Ok("Database cleared");
        }
    }
}