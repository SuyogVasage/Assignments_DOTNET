using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8_March_CodeFirst_EFcore.Models;
using Microsoft.EntityFrameworkCore;
namespace SampleCodeFirst
{
    public class CRUD 
    {
        BusinessDbContext bs;

        public CRUD()
        {
            bs = new BusinessDbContext();
        }
        public async Task<IEnumerable<Student>> GetAsync()
        {
            try
            {
                var result = await bs.Students.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
