using System;
using System.Collections.Generic;
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
			get { return age; }
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
		//implementering af phone number er lidt længere
		//hvis ikke sin egen klasse er bedre med liste
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

		public Member()		
		{

        }






    }
}
