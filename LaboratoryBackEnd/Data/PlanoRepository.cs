using LaboratoryBackEnd.Data.Interface;
using LaboratoryBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LaboratoryBackEnd.Data
{
    public class PlanoRepository : Repository<Plano>, IPlanoRepository
    {
        private readonly APIDbContext _context;

        public PlanoRepository(APIDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> CountPlanosByConvenioAsync(int convenioId)
        {
            return await _context.Plano.CountAsync(p => p.ConvenioId == convenioId);
        }
    }
}
