using Angular.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Angular.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceMasterController : ControllerBase
    {
        private readonly EnquiryDbContext dbContext;
        public ServiceMasterController(EnquiryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


    }
}
