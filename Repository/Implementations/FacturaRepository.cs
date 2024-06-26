﻿using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Modelos;

namespace Repository.Implementations
{
    public class FacturaRepository(ApplicationDbContext context) : IFacturaRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<bool> Add(FacturaDTO factura)
        {
            try
            {
                var existeCliente = await _context.ClientesEF.AsNoTracking()
                                                             .Where(e => e.Id == factura.IdCliente)
                                                             .AnyAsync();
                if (existeCliente)
                {
                    await _context.FacturasEF.AddAsync(factura);
                    return await _context.SaveChangesAsync() > 0;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la factura", ex);
            }
        }

        public async Task<FacturaDTO> Get(int id)
        {
            try
            {
                return await _context.FacturasEF.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la factura", ex);
            }
        }

        public async Task<IEnumerable<FacturaDTO>> List()
        {
            try
            {
                return await _context.FacturasEF.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las facturas", ex);
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                var factura = await _context.FacturasEF.FindAsync(id);
                if (factura is not null)
                {
                    _context.FacturasEF.Remove(factura);
                    return await _context.SaveChangesAsync() > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la factura", ex);
            }
        }

        public async Task<bool> Update(FacturaDTO factura)
        {
            try
            {
                var existeCliente = await _context.ClientesEF.AsNoTracking()
                                                             .Where(e => e.Id == factura.IdCliente)
                                                             .AnyAsync();

                var existeFactura = await _context.FacturasEF.AsNoTracking()
                                                             .Where(e => e.Id.Equals(factura.Id))
                                                             .AnyAsync();
                if (existeCliente && existeFactura)
                {
                    _context.FacturasEF.Update(factura);
                    return await _context.SaveChangesAsync() > 0;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la factura", ex);
            }
        }
    }
}
