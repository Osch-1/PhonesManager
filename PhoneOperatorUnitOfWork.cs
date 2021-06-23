using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhonesManager.DbContexts;
using PhonesManager.Repositories;

namespace PhonesManager
{
    public class PhoneOperatorUnitOfWork : IDisposable
    {
        private readonly PhoneOperatorContext _db = new();
        private ClientRepository _clientRepository;
        private PackageRepository _packageRepository;
        private PaymentRepository _paymentRepository;
        private PhoneRepository _phoneRepository;
        private ServiceRepository _serviceRepository;
        private bool _disposed = false;

        public ClientRepository Clients
        {
            get
            {
                if ( _clientRepository == null )
                    _clientRepository = new( _db );

                return _clientRepository;
            }
        }
        public PackageRepository Packages
        {
            get
            {
                if ( _packageRepository == null )
                    _packageRepository = new( _db );

                return _packageRepository;
            }
        }
        public PaymentRepository Payments
        {
            get
            {
                if ( _paymentRepository == null )
                    _paymentRepository = new( _db );

                return _paymentRepository;
            }
        }
        public PhoneRepository Phones
        {
            get
            {
                if ( _phoneRepository == null )
                    _phoneRepository = new( _db );

                return _phoneRepository;
            }
        }
        public ServiceRepository Services
        {
            get
            {
                if ( _serviceRepository == null )
                    _serviceRepository = new( _db );

                return _serviceRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose( bool disposing )
        {
            if ( !_disposed )
            {
                if ( disposing )
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose( true );
            GC.SuppressFinalize( this );
        }
    }
}
