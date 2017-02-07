﻿using LoginManagement.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using DevOne.Security.Cryptography.BCrypt;

namespace LoginManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class LoginManagementImpl : ILoginManagement
    {
        private GenericDao<User> _userDao;
        private GenericDao<Section> _sectionDao;
        private GenericDao<Profile> _profileDao;
        private GenericDao<Software> _softwareDao;

        public LoginManagementImpl()
        {
            PaimenEntities entities = new PaimenEntities();
            this._userDao = new GenericDao<User>(entities);
            this._sectionDao = new GenericDao<Section>(entities);
            this._profileDao = new GenericDao<Profile>(entities);
            this._softwareDao = new GenericDao<Software>(entities);
        }

        public void AddProfileType(string typeProfile, string software)
        {

            Profile toAddProfile = new Profile();
            Software toAddSoftware = new Software();

            toAddProfile.Name = typeProfile;
            toAddProfile.Softwares.Add(toAddSoftware);

            toAddSoftware.Name = software;
            toAddSoftware.Profiles.Add(toAddProfile);

            this._profileDao.Add(toAddProfile);
            this._softwareDao.Add(toAddSoftware);
            this._softwareDao.SaveChanges();
            this._profileDao.SaveChanges();

        }

        public User SignIn(User user)
        {
            User inDbUser = this._userDao.Find(u => u.RegNumber.Equals(user.RegNumber));
            if(inDbUser == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(user.Password))
            {
                if (!user.Password.Equals(inDbUser.Password))
                {
                    return null;
                }
            }
            return inDbUser;
        }

        public bool AddStudentFromCSV(string csv)
        {
            string[] lines = File.ReadAllLines(csv);

            IList<Section> sections = GetAllSections();

            int idSection = 0;
            foreach(string line in lines)
            {
                string[] user = line.Split(',');

                foreach(Section s in sections)
                {
                    if (s.Code == user[4])
                    {
                        idSection = s.Id;
                    }
                }

                string login = GetLogin(user[2], user[1]);

                string password = GenerateAndEncryptPassword();

                User newStudent = new User
                {
                    RegNumber = Convert.ToInt32(user[0]),
                    LastName = user[1],
                    FirstName = user[2],
                    Year = Convert.ToInt32(user[3]),
                    Section = idSection,
                    Email = user[5],
                    Type = "Student",
                    Login = login,
                    Password = password
                };

                this._userDao.Add(newStudent);
            }
            return true;
        }

        private IList<Section> GetAllSections()
        {
            return this._sectionDao.GetAll();
        }

        private string GetLogin(string firstName, string lastName)
        {
            char beginning = (firstName.ToArray())[0];
            string end = lastName.Substring(0, Math.Min(lastName.Length, 6)); // Math.Min => si jamais le lastName est inférieur à 6 lettres 

            return beginning + end;
        }

        private string GenerateAndEncryptPassword()
        {
            return BCryptHelper.HashPassword(System.Web.Security.Membership.GeneratePassword(10, 5), BCryptHelper.GenerateSalt());
        }
    }
}
