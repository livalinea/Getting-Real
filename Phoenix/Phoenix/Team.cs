using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix
{
	internal class Team
	{
		private string type;

		public string Type
		{
			get { return type; }
			set { type = value; }
		}

		// Backing collections for members and coaches
		private readonly List<Member> members;
		private readonly List<Member> coaches;
		private readonly List<Member> ascoaches;

		// Price for the team (matches UML)
		private double price;

		// Read-only views for external callers
		public IReadOnlyList<Member> Members => members.AsReadOnly();
		public IReadOnlyList<Member> Coaches => coaches.AsReadOnly();
		public IReadOnlyList<Member> AsCoaches => ascoaches.AsReadOnly();

		// Computed properties
		public int NumMembers => members.Count;
		public double Price
		{
			get => price;
			set => price = value;
		}

		// Constructor
		public Team(string type)
		{
			this.type = type;
			members = new List<Member>();
			coaches = new List<Member>();
			ascoaches = new List<Member>();
			price = 0.0;
		}

		// Methods
		public int CountMembers()
		{
			return members.Count + coaches.Count;
		}

		public void AddMember(Member m)
		{
			if (m == null) throw new ArgumentNullException(nameof(m));
			members.Add(m);
		}

		public void AddCoach(Member c)
		{
			if (c == null) throw new ArgumentNullException(nameof(c));
			coaches.Add(c);
		}

        public void AddAsCoach(Member s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            ascoaches.Add(s);
        }

    }
}
