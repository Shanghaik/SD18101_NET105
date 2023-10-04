using AppsData.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SD18101_AppAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhviensController : ControllerBase
    {
        public AppDbContext context = new AppDbContext();
        // GET: api/<SinhviensController>
        [HttpGet("get-all")]
        public IEnumerable<Sinhvien> GetAll()
        {
            return context.sinhviens.ToList();
        }

        // GET api/<SinhviensController>/5
        [HttpGet("get-by-id")]
        public Sinhvien GetById(Guid id)
        {
            return context.sinhviens.Find(id);
        }
        [HttpGet("get-by-name")]
        public IEnumerable<Sinhvien> GetByName(string name)
        {
            return context.sinhviens.Where(p => p.Name.Contains(name)).ToList();
        }

        // POST api/<SinhviensController>
        [HttpPost("post-by-obj")]
        public bool PostByObj([FromBody] Sinhvien sinhvien)
        {
            try
            {
                context.sinhviens.Add(sinhvien);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpGet("post-by-params")]
        public bool PostByParams(string Name, string Description, string Email,
            string PhoneNumber, DateTime DoB, string Address, int Major)
        {
            Guid id = Guid.NewGuid();
            Sinhvien sinhvien = new Sinhvien
            {
                Id = id,
                Name = Name,
                Description = Description,
                Email = Email,
                PhoneNumber = PhoneNumber,
                DoB = DateTime.Now,
                Address = Address,
                Major = Major
            };
            try
            {
                context.sinhviens.Add(sinhvien);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // PUT api/<SinhviensController>/5
        [HttpPut("put-by-obj")]
        public bool PutByObj([FromBody] Sinhvien sinhvien)
        {
            Sinhvien sinhvienfrDb = context.sinhviens.Find(sinhvien.Id);
            try
            {
                sinhvienfrDb.Name = sinhvien.Name; // Nhớ là phải gán lại
                context.sinhviens.Update(sinhvienfrDb);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // DELETE api/<SinhviensController>/5
        [HttpGet("{id}")]
        public bool Delete(Guid id)
        {
            try
            {
                Sinhvien sv = context.sinhviens.Find(id);
                context.sinhviens.Remove(sv);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
