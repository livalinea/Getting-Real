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

        private int age;
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int calculatedAge = today.Year - BirthDate.Year;

                DateTime nextBirthday = BirthDate.AddYears(calculatedAge);
                if (today < nextBirthday)
                {
                    calculatedAge = calculatedAge - 1;
                }
                return calculatedAge;
            }
            set { age = value; }
        }
        private DateTime birthDate;

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string mail;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }


        private int phoneNumber1;
        private int phoneNumber2;

        public int PhoneNumber1
        {
            get { return phoneNumber1; }
            set
            {
                if (value.ToString().Length == 8)
                {
                    phoneNumber1 = value;
                }
                else
                {
                    throw new ValidationException("Telefonnummer 1 skal være 8 cifre.");
                }
            }
        }

        public int PhoneNumber2
        {
            get { return phoneNumber2; }
            set
            {
                if (value == 0)            // tillad tomt nr. 2
                {
                    phoneNumber2 = 0;
                }
                else if (value.ToString().Length == 8)
                {
                    phoneNumber2 = value;
                }
                else
                {
                    throw new ValidationException("Telefonnummer 2 skal være 8 cifre.");
                }
            }
        }
        private DateTime regDate;

        public DateTime RegDate
        {
            get { return regDate; }
            set { regDate = DateTime.Today; }
        }
        private string rank;

        public string Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        private bool judoPass;

        public bool JudoPass
        {
            get { return judoPass; }
            set { judoPass = value; }
        }
        private bool judoLicens;

        public bool JudoLicens
        {
            get { return judoLicens; }
            set { judoLicens = value; }
        }

        public Team.TeamName Team { get; set; }

        private double weight;

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private ClubRole role;

        public ClubRole Role
        {
            get { return role; }
            set { role = value; }
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
            JudoLicens = judoLicens;
            Team = team;
            Weight = weight;
            Role = role;

        }

    }
}
