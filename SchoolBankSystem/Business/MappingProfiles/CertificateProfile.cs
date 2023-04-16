using AutoMapper;
using Business.Models.Certificate;
using DAL.Entities;

namespace Business.MappingProfiles
{
    public class CertificateProfile : Profile
    {
        public CertificateProfile()
        {
            CreateMap<Certificate, CertificateModel>().ReverseMap();
            CreateMap<AddCertificateModel, Certificate>();
        }
    }
}