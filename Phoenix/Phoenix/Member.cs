using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
    public enum ClubRole
    {
        Member,
        Coach,
        AsCoach,
	}
    public class Member
    {
        public int MemberID { get; internal set; }
       
        public string FirstName { get; set; }

        public string LastName { get; set; }

        private int _age;
        public int Age
        {
            get
            {
                var today = DateTime.Today;
               _age = today.Year - BirthDate.Year;

                DateTime nextBirthday = BirthDate.AddYears(_age);
                if (today < nextBirthday)
                {
                    _age = _age - 1;
                }
                return _age;
            }
            set { _age = value; }
        }
        private DateTime _birthDate;

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Mail { get; set; }


        private int _phoneNumber1;
        private int _phoneNumber2;

        public int PhoneNumber1
        {
            get { return _phoneNumber1; }
            set
            {
               if (value.ToString().Length == 8)
                {
                    _phoneNumber1 = value;
                }
                else
                {
                    throw new ValidationException("Telefonnummer 1 skal være 8 cifre.");
                }
            }
        }

        public int PhoneNumber2
        {
            get { return _phoneNumber2; }
            set
            {
                if (value == 0)            // tillad tomt nr. 2
                {
                    _phoneNumber2 = 0;
                }
                else if (value.ToString().Length == 8)
                {
                    _phoneNumber2 = value;
                }
                else
                {
                    throw new ValidationException("Telefonnummer 2 skal være 8 cifre.");
                }
            }
        }
        private DateTime _regDate;

        public DateTime RegDate
        {
            get { return _regDate; }
            set { _regDate = DateTime.Today; }
        }

        private string _rank;

        public string Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }
        private bool _judoPass;

        public bool JudoPass
        {
            get { return _judoPass; }
            set { _judoPass = value; }
        }
        private bool judoLicens;

        public bool _JudoLicens
        {
            get { return judoLicens; }
            set { judoLicens = value; }
        }
      
        public Team.TeamName Team { get; set; }

        private double _weight;

        public double Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        private ClubRole _role;

        public ClubRole Role
        {
            get { return _role; }
            set { _role = value; }
        }


        public Member(int memberID, string firstName, string lastName, DateTime birthDate, string address, string mail, int phoneNumber1, int phoneNumber2, string rank, bool judoPass, bool judoLicens, Team.TeamName team, double weight, ClubRole role)

        {
            MemberID = memberID;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Address = address;
            Mail = mail;
            PhoneNumber1 = phoneNumber1;
            PhoneNumber2 = phoneNumber2;
            Rank = rank;
            JudoPass = judoPass;
            _JudoLicens = judoLicens;
            Team = team;
            Weight = weight;
            Role = role;
          
        }

    }
}
