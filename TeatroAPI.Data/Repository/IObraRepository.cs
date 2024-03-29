﻿using TeatroAPI.DTOs;
using TeatroAPI.Model;

namespace TeatroAPI.Data
{
    public interface IObraRepository
    {
        List<ObraSimpleDto> GetObras();
        ObraReservaDto GetObraById(int id);
        List<ObraSimpleDto> GetObraCategoriaById(int id);
        void InsertObra(Obra obra);
        void UpdateObra(Obra obra);
        void DeleteObra(int id);
    }
}