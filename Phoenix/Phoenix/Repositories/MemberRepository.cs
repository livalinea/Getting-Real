using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static Phoenix.Team;

namespace Phoenix.Repositories
{
    public class MemberRepository : IRepository
    {
        private readonly List<Member> _members = new();
        private string filePath = "Members.txt";

        public IEnumerable<Member> GetAll()
        {
            return _members;
        }

        public Member GetByID(int memberID)
        {
            foreach (Member member in _members)
            {
                if (member.MemberID == memberID)
                {
                    return member;
                }

            }
            return null;
        }
        public List<Member> GetMembersByTeam(Team.TeamName team)
        {
            return _members
               .Where(m => m.Team == team)
               .ToList();
            /*
             * Dette svarer til følgende og er en LINQ;
            var result = new List<Member>();
            foreach (var m in _members)
            { 
             if (m.Team == team)
              { 
                result.Add(m); 
              }
            }
            return result;
            }*/



        }

        public void Add(Member member)
        {
            _members.Add(member);
            SaveToFile();
        }

        public void Delete(int memberId)
        {
            var selected = GetByID(memberId);
            if (selected != null)
            {
                _members.Remove(selected);
                SaveToFile();
            }
        }

        public MemberRepository()
        {
            LoadFromFile();
           

        }

        public void Update(Member member)
        {
            //updatere medlemmer

            var Selected = GetByID(member.MemberID);

            if (Selected != null)
            {
                Selected.FirstName = member.FirstName;
                Selected.LastName = member.LastName;
                Selected.BirthDate = member.BirthDate;
                Selected.Address = member.Address;
                Selected.Mail = member.Mail;
                Selected.PhoneNumber1 = member.PhoneNumber1;
                Selected.PhoneNumber2 = member.PhoneNumber2;
                Selected.RegDate = member.RegDate;
                Selected.Rank = member.Rank;
                Selected.JudoPass = member.JudoPass;
                Selected._JudoLicens = member._JudoLicens;
                Selected.Team = member.Team;
                Selected.Weight = member.Weight;
                Selected.Role = member.Role;
                SaveToFile();
            }
        }
        public void SaveToFile()
        {
            using (StreamWriter sw = new StreamWriter("Members.txt"))
            {
                foreach (Member m in _members)
                {
                    // Gem som en linje med semikolon-separerede værdier
                    sw.WriteLine($"{m.MemberID};{m.FirstName};{m.LastName};{m.BirthDate:yyyy-MM-dd};{m.Address};{m.Mail};{m.PhoneNumber1};{m.PhoneNumber2};{m.Rank};{m.JudoPass};{m._JudoLicens};{m.Team};{m.Weight};{m.Role}");
                }
                sw.Close();
            }
        }
      

        public void LoadFromFile()
        {
            _members.Clear();

            if (!File.Exists("Members.txt"))
                return;
            using (StreamReader sr = new StreamReader("Members.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');

                    if (parts.Length >= 14)
                    {
                        int id = int.Parse(parts[0]);
                        string firstName = parts[1];
                        string lastName = parts[2];
                        DateTime birthDate = DateTime.Parse(parts[3]);
                        string address = parts[4];
                        string mail = parts[5];
                        int phoneNumber1 = int.Parse(parts[6]);
                        int phoneNumber2 = int.Parse(parts[7]);
                        string rank = parts[8];
                        bool judoPass = bool.Parse(parts[9]);
                        bool judoLicens = bool.Parse(parts[10]);
                        // tjekker om Teamname passer med en af vores enums// 
                        string raw = parts[11]?.Trim();
                        if (string.IsNullOrEmpty(raw))
                        if (raw.Contains(".")) raw = raw.Split('.').Last();

                        bool parsed =Enum.TryParse<Team.TeamName>(raw, true, out var teamType);
                        if (!parsed)
                        {  // håndter fejelen kast exception
                            throw new InvalidEnumArgumentException($"Ugyldigt teamnavn: '{raw}' er ikke en gyldig TeamName.");
                        }

                        double weight = double.Parse(parts[12]);
                        ClubRole role = (ClubRole)Enum.Parse(typeof(ClubRole), parts[13]);

                        Member m = new Member(id, firstName, lastName, birthDate, address, mail, phoneNumber1, phoneNumber2, rank, judoPass, judoLicens, teamType, weight, role);
                        _members.Add(m);
                    }
                }

            }
        }

        }

    }



  
    
