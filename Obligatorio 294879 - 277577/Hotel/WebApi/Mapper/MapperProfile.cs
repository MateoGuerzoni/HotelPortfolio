using AutoMapper;
using LogicaNegocio.Entidades;
using WebApi.Dto;

namespace WebApi.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<CabaniaDto, Cabania>();
            CreateMap<Cabania, CabaniaDto>();

            CreateMap<TipoDto, Tipo>();
            CreateMap<Tipo, TipoDto>();

            CreateMap<MantenimientoDto , Mantenimiento>();
            CreateMap<Mantenimiento, MantenimientoDto>().
                ForMember(mantenimientoDto => mantenimientoDto.Fecha, mantenimiento => mantenimiento.MapFrom(campo => campo.Fecha.Value))
                .ForMember(mantenimientoDto => mantenimientoDto.Descripcion, mantenimiento => mantenimiento.MapFrom(campo => campo.Descripcion.Value))
                .ForMember(mantenimientoDto => mantenimientoDto.Costo, mantenimiento => mantenimiento.MapFrom(campo => campo.Costo.Value))
                .ForMember(mantenimientoDto => mantenimientoDto.NombreFuncionario, mantenimiento => mantenimiento.MapFrom(campo => campo.NombreFuncionario.Value));

            CreateMap<MantenimientoPorPersonaDto, MantenimientoPorPersona>();
            CreateMap<MantenimientoPorPersona, MantenimientoPorPersonaDto>();
        }
    }
}
