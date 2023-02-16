using AutoMapper;
using Business.Models.CertificatePurchase;
using DAL.Entities;

namespace Business.MappingProfiles
{
    public class CertificatePurchaseProfile : Profile
    {
        public CertificatePurchaseProfile()
        {
            CreateMap<CertificatePurchase, CertificatePurchaseModel>();
        }
    }
}