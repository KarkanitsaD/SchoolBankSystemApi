using AutoMapper;
using Business.Models.CertificatePurchase;
using Business.Services.IServices;
using DAL.Entities;
using DAL.Repositories.IRepositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Business.Services
{
    public class CertificatePurchaseService : ICertificatePurchaseService
    {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Certificate> _certificateRepository;
        private readonly IRepository<CertificatePurchase> _certificatePurchaseRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public CertificatePurchaseService
        (
            IRepository<Student> studentRepository,
            IRepository<Certificate> certificateRepository,
            IRepository<CertificatePurchase> certificatePurchaseRepository,
            IHttpContextAccessor contextAccessor,
            IMapper mapper
        )
        {
            _studentRepository = studentRepository;
            _certificateRepository = certificateRepository;
            _certificatePurchaseRepository = certificatePurchaseRepository;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }

        public async Task<CertificatePurchaseModel> PurchaseAsync(Guid certificateId)
        {
            var certificate = await _certificateRepository.GetFirstAsync(x => x.Id == certificateId);
            if (certificate == null)
            {
                throw new Exception($"Certificate with Id = {certificateId} not found.");
            }

            var studentIdClaim = _contextAccessor.HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier);
            var studentId = new Guid(studentIdClaim.Value);
            var student = await _studentRepository.GetFirstAsync(x => x.Id == studentId);
            if (student.Sum < certificate.Price)
            {
                throw new Exception("Not enough funds for transaction.");
            }

            using var transaction = await _certificatePurchaseRepository.BeginTransactionAsync();

            var purchase = new CertificatePurchase
            {
                StudentId = studentId,
                CertificateId = certificateId,
                Time = DateTime.Now,
            };
            student.Sum -= certificate.Price;

            await _certificatePurchaseRepository.CreateAsync(purchase);
            await _studentRepository.UpdateAsync(student);

            await transaction.CommitAsync();

            purchase.Student = student;
            purchase.Certificate= certificate;

            var result = _mapper.Map<CertificatePurchase, CertificatePurchaseModel>(purchase);

            return result;
        }

        public async Task<CertificatePurchaseModel> ActivateAsync(Guid purchaseId)
        {
            var purchase = await _certificatePurchaseRepository.GetFirstAsync(x => x.Id == purchaseId);
            if (purchase == null)
            {
                throw new Exception($"Certifciate purchase with Id = {purchaseId} not found.");
            }

            purchase.ActivatedTime = DateTime.Now;
            await _certificatePurchaseRepository.UpdateAsync(purchase);
            var purchaseModel = _mapper.Map<CertificatePurchase, CertificatePurchaseModel>(purchase);

            return purchaseModel;
        }
    }
}
