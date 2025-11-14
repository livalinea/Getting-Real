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
        //andre roller?

	}
    internal class Member
    {
        public int MemberID { get; }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (today < BirthDate.AddYears(age))
                    age--;
                return age;
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
        private int phoneNumber;

        public int PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value.ToString().Length == 8)
                {
                    phoneNumber = value;
                }
                throw new ValidationException("Error");
            }
        }
        private DateTime regDate;

        public DateTime RegDate
        {
            get { return regDate; }
            set { regDate = value; }
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
        private Team teamType;

        public Team TeamType
        {
            get { return teamType; }
            set { teamType = value; }
        }
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

        public ClubMember(int memberID, string name, DateTime birthDate, string address, string mail, string rank, bool judoPass, Team teamType, double weight, ClubRole role)
        {
            MemberID = memberID;
            Name = name;
            BirthDate = birthDate;
            Address = address;
            Mail = mail;
            Rank = rank;
            JudoPass = judoPass;
            TeamType = teamType;
            Weight = weight;
            Role = role;



            var today = DateTime.Today;
            if (today > birthDate)
            {
                Age = DateTime.Now.Year - birthDate.Year;
            }
            else
            {
                Age = DateTime.Now.Year - birthDate.Year - 1;
            }

            RegDate = DateTime.Now.Date;
        }






    }
}
