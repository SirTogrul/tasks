using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[10];
            int groupCount = 0;

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Telebe elave et.");
                Console.WriteLine("2. Butun telebelere bax.");
                Console.WriteLine("3. Telebe uzre axtaris et.");
                Console.WriteLine("0. programi bitir");

                Console.WriteLine("secimini qeyd et");
                string choice= Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (groupCount >= groups.Length)

                        {
                            Console.WriteLine("telebe ugurla elave edildi");
                            continue;
                        }
                            Console.WriteLine("qrup nomresi daxil edin (AB123 benzer)");
                            string groupNo = Console.ReadLine();
                            if (!(groupNo.Length == 5 && Char.IsUpper(groupNo[0]) && Char.IsUpper(groupNo[1])
                            && Char.IsDigit(groupNo[2]) && Char.IsDigit(groupNo[3]) && Char.IsDigit(groupNo[4])))
                            {
                                Console.WriteLine("qrup nomresi duzgun daxil edilmemisdir");
                                continue;
                            }
                            Console.WriteLine("telebe limiti qeyd edin");
                            int Studentlimit;
                            Studentlimit=Convert.ToInt32(Console.ReadLine());
                            if(!(Studentlimit > 0 && Studentlimit < 20))
                            {
                                Console.WriteLine("telebe limit 0 ve 20 araliginda olmalidir");
                                continue;
                            }
                            string no;
                            Group group = new Group(Studentlimit, 0, groupNo);
                            groups[groupCount++] = group;


                            Console.WriteLine("telebenin ad ve soyadini qeyd edin ");
                            string fullName= Console.ReadLine();
                            Student student = new Student {Fullname=fullName,Groupno=groupNo};
                      
                            double avgPoint;
                            avgPoint = Convert.ToDouble(Console.ReadLine());
                            if(!(avgPoint >= 0 && avgPoint <= 100))
                            {
                                Console.WriteLine("duzgun bal qeyd edin");
                            }
                            student.Avgpoint = avgPoint;

                            group.Addstudent(student);
                            break;
                        
                     case "2":
                        foreach (Group grp in groups)
                        {
                            if (grp != null)
                            {
                                Console.WriteLine($"Qrup {grp.no}:");
                                for (int i = 0; i < grp.Studentcount; i++)
                                {
                                    Console.WriteLine($"Ad: {grp.students[i].Fullname}, Qrup No: {grp.students[i].Groupno}, Ortalama Nöqtə: {grp.students[i].Avgpoint}");
                                }
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Axtardiginiz telebeni qeyd edin: ");
                        string search = Console.ReadLine();
                        foreach (Group grp in groups)
                        {
                            if (grp != null)
                            {
                                Console.WriteLine($"Qrup {grp.no}:");
                                for (int i = 0; i < grp.Studentcount; i++)
                                {
                                    if (grp.students[i].Fullname.ToLower().Contains(search.ToLower()))
                                    {
                                        Console.WriteLine($"Ad: {grp.students[i].Fullname}, Qrup No: {grp.students[i].Groupno}, Ortalama Nöqtə: {grp.students[i].Avgpoint}");
                                    }
                                }
                            }
                        }
                        break;

                    case "0":
                        Console.WriteLine("program bitir.......");
                        return;

                    default:
                        Console.WriteLine("Bele bir secim yoxudur");
                        break;
                }
            }
        }
    }
}
class Student
{
    public string Fullname;
    public string Groupno;
    public double Avgpoint;
}
class Group
{
    public int Studentlimit;
    public int Studentcount;
    public Student[] students;
    public string no;

    public  Group(int studentlimit, int studentcount, string no)
    {
        Studentlimit = studentlimit;
        Studentcount = 0;
        students = new Student[studentlimit];
        this.no = no;
    }
    public void Addstudent(Student student)
    {
        if(Studentcount<Studentlimit)
        {
            students[Studentcount++] = student;
            Console.WriteLine("telebe elave olundu");
        }
        else
        {
            Console.WriteLine("qrupda telebe elava etmek ucun yer yoxdur");
        }
    }
}