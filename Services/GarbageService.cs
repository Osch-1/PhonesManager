using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhonesManager.Entities.Models;

namespace PhonesManager.Services
{
    public class GarbageService
    {
        private readonly PhoneOperatorUnitOfWork _unitOfWork = new();

        //должен быть обобщенные метод к репозиторию
        public List<Client> GetAllClients() => _unitOfWork.Clients.GetAll();
        public List<Package> GetAllPackages() => _unitOfWork.Packages.GetAll();
        public List<Payment> GetAllPayments() => _unitOfWork.Payments.GetAll();
        public List<Phone> GetAllPhones() => _unitOfWork.Phones.GetAll();
        public List<Service> GetAllServices() => _unitOfWork.Services.GetAll();

        public Client GetClient( int id ) => _unitOfWork.Clients.GetById( id );
        public Package GetPackage( int id ) => _unitOfWork.Packages.GetById( id );
        public Payment GetPayment( int id ) => _unitOfWork.Payments.GetById( id );
        public Phone GetPhone( int id ) => _unitOfWork.Phones.GetById( id );
        public Service GetService( int id ) => _unitOfWork.Services.GetById( id );

        public void CreateClient( Client client ) => _unitOfWork.Clients.Create( client );
        public void CreatePackage( Package package ) => _unitOfWork.Packages.Create( package );
        public void CreatePayment( Payment payment ) => _unitOfWork.Payments.Create( payment );
        public void CreatePhone( Phone phone ) => _unitOfWork.Phones.Create( phone );
        public void CreateService( Service service ) => _unitOfWork.Services.Create( service );

        public void RemoveClient( Client client ) => _unitOfWork.Clients.Remove( client );
        public void RemovePackage( Package package ) => _unitOfWork.Packages.Remove( package );
        public void RemovePayment( Payment payment ) => _unitOfWork.Payments.Remove( payment );
        public void RemovePhone( Phone phone ) => _unitOfWork.Phones.Remove( phone );
        public void RemoveService( Service service ) => _unitOfWork.Services.Remove( service );

        public int GetServicesCountWithPrice( decimal price )
        {
            return _unitOfWork.Services
                       .GetAll()
                       .GroupBy( s => s.Price )
                       .First( s => s.Key == price ).Count();
        }

        public void SaveChanges()
        {
            _unitOfWork.Save();
        }
    }
}
