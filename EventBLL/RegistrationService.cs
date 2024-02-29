using EventDAL;
using EventEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBLL
{
    public class RegistrationService
    {
       public List<Registration> GetRegistrations(int eventId)
        {
            List<Registration> registrations = new List<Registration>();
            RegistrationRepository regRepository = new RegistrationRepository();
            registrations = regRepository.GetRegistrations(eventId);
            return registrations;
        } 

        public bool DeleteRegistration(int registrationId)
        {
            RegistrationRepository regRepository = new RegistrationRepository();
            return regRepository.DeleteRegistration(registrationId);
        }

        public bool AddRegistration(Registration registration)
        {
            RegistrationRepository regRepository = new RegistrationRepository();
            return regRepository.AddRegistration(registration);
        }
        
        public bool UpdateRegistration(Registration registration)
        {
            RegistrationRepository regRepository = new RegistrationRepository();
            return regRepository.UpdateRegistration(registration);
        }
    }
}
