using HMSFE.Models;
using AutoMapper;
using HMSFE.DTOS;
using HMSFE.Models.DTOS;

namespace HMSFE
{
    public class MappingProfile : Profile
    {
      
            public MappingProfile()
            {

                // Mapping between DoctorAvailability entity and DoctorAvailabilityDTO
                CreateMap<DoctorAvailability, DoctorAvailabilityDto>()
                    .ForMember(dest => dest.Staff, opt => opt.MapFrom(src => src.Staff)) 
                    .ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.IsAvailable)) 
                    .ForMember(dest => dest.AvailabilityId, opt => opt.MapFrom(src => src.AvailabilityId))
                    .ForMember(dest => dest.AvailableDate, opt => opt.MapFrom(src => src.AvailableDate))
                    .ForMember(dest => dest.TimeSlot, opt => opt.MapFrom(src => src.TimeSlot))
                    .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization));

                // Reverse mapping
                CreateMap<DoctorAvailabilityDto, DoctorAvailability>()
                    .ForMember(dest => dest.Staff, opt => opt.MapFrom(src => src.Staff))
                    .ForMember(dest => dest.AvailabilityId, opt => opt.MapFrom(src => src.AvailabilityId))
                    .ForMember(dest => dest.AvailableDate, opt => opt.MapFrom(src => src.AvailableDate))
                    .ForMember(dest => dest.TimeSlot, opt => opt.MapFrom(src => src.TimeSlot))
                    .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization));

                // Mapping between Staff entity and StaffDTO
                CreateMap<HospitalStaff, HospitalStaffDto>()
                    .ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.StaffId))
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                    .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                    .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization));

                // Reverse mapping for HospitalStaff
                CreateMap<HospitalStaffDto, HospitalStaff>()
                    .ForMember(dest => dest.StaffId, opt => opt.MapFrom(src => src.StaffId))
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                    .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                    .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                    .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.Specialization));
            }
        }
    }

