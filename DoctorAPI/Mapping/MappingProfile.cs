using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Models;
using DoctorAPI.DTOs;

namespace DoctorAPI.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Analysis, AnalysisDTO>().ReverseMap();
			CreateMap<AvaliableVisitTime, AvtDTO>().ReverseMap();
			CreateMap<Diagnosis, DiagnosisDTO>().ReverseMap();
			CreateMap<Disease, DiseaseDTO>().ReverseMap();
			CreateMap<Doctor, DoctorDTO>().ReverseMap();
			CreateMap<Gender, GenderDTO>().ReverseMap();
			CreateMap<Patient, PatientDTO>().ReverseMap();
			CreateMap<Visit, VisitDTO>().ReverseMap();
			CreateMap<VisitType, VisitTypeDTO>().ReverseMap();

		}
	}
}