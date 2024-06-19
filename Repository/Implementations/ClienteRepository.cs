using Repository.Interfaces;
using Repository.Modelos;
using Microsoft.EntityFrameworkCore;
using Repository.Enums;


namespace Repository.Implementations
{
    public class ClienteRepository(ApplicationDbContext context) : IClienteRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> Add(ClienteDTO cliente)
        {
            try
            {
                var existeCliente = await _context.ClientesEF.AsNoTracking()
                                                             .Where(e => e.Documento.Equals(cliente.Documento) && e.Estado.Equals(GenericoConstante.EstadoActivo))
                                                             .AnyAsync();

                if (!existeCliente)
                {
                    cliente.Estado = GenericoConstante.EstadoActivo;
                    await _context.ClientesEF.AddAsync(cliente);
                    return await _context.SaveChangesAsync() > 0;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClienteDTO> Get(int id)
        {
            try
            {
                return await _context.ClientesEF.FirstOrDefaultAsync(c => c.Id == id && c.Estado == GenericoConstante.EstadoActivo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ClienteDTO>> List()
        {
            try
            {
                return await _context.ClientesEF
                    .Where(c => c.Estado.Equals(GenericoConstante.EstadoActivo))
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                var cliente = await _context.ClientesEF.FindAsync(id);
                if (cliente is not null)
                {
                    cliente.Estado = GenericoConstante.EstadoInactivo;
                    _context.ClientesEF.Update(cliente);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(ClienteDTO cliente)
        {
            try
            {
                var existeDocumento = await _context.ClientesEF.AsNoTracking()
                                                    .Where(e => e.Documento.Equals(cliente.Documento) && e.Estado.Equals(GenericoConstante.EstadoActivo))
                                                    .AnyAsync();

                var existeCliente = await _context.ClientesEF.AsNoTracking()
                                                            .Where(e => e.Id.Equals(cliente.Id) && e.Estado.Equals(GenericoConstante.EstadoActivo))
                                                            .AnyAsync();
                if (!existeDocumento && existeCliente)
                {
                    _context.ClientesEF.Update(cliente);
                    return await _context.SaveChangesAsync() > 0;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
