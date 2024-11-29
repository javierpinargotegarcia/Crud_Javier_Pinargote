using Api.Context;
using Api.Dto;
using Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly AplicationDbcontext _context;
        public TareasController(AplicationDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<TareasDto>>> Get()
        {
            var listaDTO = new List<TareasDto>();
            var listaDB = await _context.Tareas.ToListAsync();
            foreach (var tarea in listaDB)
            {
                listaDTO.Add(new TareasDto
                {
                    ID = tarea.ID,
                    Titulo = tarea.Titulo,
                    Descripcion = tarea.Descripcion,
                    FechaCreacion = tarea.FechaCreacion,
                    FechaVencimiento = tarea.FechaVencimiento,
                    Completada = tarea.Completada,
                    Prioridad = (Dto.PrioridadNivel)tarea.Prioridad,
                    Etiqueta = tarea.Etiqueta
                });
            }
            return Ok(listaDTO);
        }

        [HttpGet]
        [Route("buscar/{ID}")]
        public async Task<ActionResult<TareasDto>> Get(int ID)
        {
            var tarea = await _context.Tareas.FindAsync(ID);

            if (tarea == null)
            {
                return NotFound();
            }

            var tareaDTO = new TareasDto
            {
                ID = tarea.ID,
                Titulo = tarea.Titulo,
                Descripcion = tarea.Descripcion,
                FechaCreacion = tarea.FechaCreacion,
                FechaVencimiento = tarea.FechaVencimiento,
                Completada = tarea.Completada,
                Prioridad = (Dto.PrioridadNivel)tarea.Prioridad,
                Etiqueta = tarea.Etiqueta
            };

            return Ok(tareaDTO);
        }

        [HttpPost]
        [Route("guardar")]
        public async Task<ActionResult<TareasDto>> Guardar(TareasDto tareasDTO)
        {
            var tareas = new Tareas
            {
                Titulo = tareasDTO.Titulo,
                Descripcion = tareasDTO.Descripcion,
                FechaCreacion = tareasDTO.FechaCreacion,
                FechaVencimiento = tareasDTO.FechaVencimiento,
                Completada = tareasDTO.Completada,
                Prioridad = (Api.Entities.PrioridadNivel)tareasDTO.Prioridad,
                Etiqueta = tareasDTO.Etiqueta
            };

            _context.Tareas.Add(tareas);
            await _context.SaveChangesAsync();

            return Ok("Tarea agregada");
        }

        [HttpPut]
        [Route("editar")]
        public async Task<ActionResult> Editar(TareasDto tareasDTO)
        {
            var responseApi = new ResponseApis<TareasDto>();
            var tareaExistente = await _context.Tareas.FindAsync(tareasDTO.ID);

            if (tareaExistente == null)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = "Tarea no actualizada";
            }
            else
            {
                tareaExistente.Titulo = tareasDTO.Titulo;
                tareaExistente.Descripcion = tareasDTO.Descripcion;
                tareaExistente.FechaCreacion = tareasDTO.FechaCreacion;
                tareaExistente.FechaVencimiento = tareasDTO.FechaVencimiento;
                tareaExistente.Completada = tareasDTO.Completada;
                tareaExistente.Prioridad = (Api.Entities.PrioridadNivel)tareasDTO.Prioridad;
                tareaExistente.Etiqueta = tareasDTO.Etiqueta;

                await _context.SaveChangesAsync();

                responseApi.EsCorrecto = true;
                responseApi.Mensaje = "Tarea actualizada correctamente";
            }

            return Ok(responseApi);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public async Task<ActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseApis<int>();
            var tarea = await _context.Tareas.FindAsync(id);

            if (tarea == null)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = "Tarea no encontrada";
            }
            else
            {
                _context.Tareas.Remove(tarea);
                await _context.SaveChangesAsync();

                responseApi.EsCorrecto = true;
            }
            return Ok(responseApi);
        }
    }
}
