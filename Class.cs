using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp1
{
    [Serializable()]
    public class Class : ISerializable
    {
        
        private double Points { get; set; }
        private int Credit { get; set; }
        private string Name { get; set; }
        private string Grade { get; set; }

        public Class(string name, string grade, int credits)
        {
            Name = name;
            Credit = credits;

            switch (grade)
            {
                case "A+":
                    this.Points = 4.0;
                    this.Grade = "A+";
                    break;
                case "A":
                    this.Points = 4.0;
                    this.Grade = "A";
                    break;
                case "A-":
                    this.Points = 3.7;
                    this.Grade = "A-";
                    break;
                case "B+":
                    this.Points = 3.3;
                    this.Grade = "B+";
                    break;
                case "B":
                    this.Points = 3.0;
                    this.Grade = "B";
                    break;
                case "B-":
                    this.Points = 2.7;
                    this.Grade = "B-";
                    break;
                case "C+":
                    this.Points = 2.3;
                    this.Grade = "C+";
                    break;
                case "C":
                    this.Points = 2.0;
                    this.Grade = "C";
                    break;
                case "C-":
                    this.Points = 1.7;
                    this.Grade = "C-";
                    break;
                case "D+":
                    this.Points = 1.3;
                    this.Grade = "D+";
                    break;
                case "D":
                    this.Points = 1.0;
                    this.Grade = "D";
                    break;
                case "D-":
                    this.Points = 0.7;
                    this.Grade = "D-";
                    break;
                case "F":
                    this.Points = 0.0;
                    this.Grade = "F";
                    break;
                default:
                    this.Points = 0.0;
                    this.Grade = "F";
                    break;
            }
        }

        public int getCredit()
        {
            return Credit;
        }

        public double getPoints()
        {
            return Points;
        }

        public string getName()
        {
            return Name;
        }

        public string getGrade()
        {
            return Grade;
        }

        public void setCredit(int credits)
        {
            this.Credit = credits;
        }

        public void setGrade(string grade)
        {

            switch (grade)
            {
                case "A+":
                    this.Points = 4.0;
                    this.Grade = "A+";
                    break;
                case "A":
                    this.Points = 4.0;
                    this.Grade = "A";
                    break;
                case "A-":
                    this.Points = 3.7;
                    this.Grade = "A-";
                    break;
                case "B+":
                    this.Points = 3.3;
                    this.Grade = "B+";
                    break;
                case "B":
                    this.Points = 3.0;
                    this.Grade = "B";
                    break;
                case "B-":
                    this.Points = 2.7;
                    this.Grade = "B-";
                    break;
                case "C+":
                    this.Points = 2.3;
                    this.Grade = "C+";
                    break;
                case "C":
                    this.Points = 2.0;
                    this.Grade = "C";
                    break;
                case "C-":
                    this.Points = 1.7;
                    this.Grade = "C-";
                    break;
                case "D+":
                    this.Points = 1.3;
                    this.Grade = "D+";
                    break;
                case "D":
                    this.Points = 1.0;
                    this.Grade = "D";
                    break;
                case "D-":
                    this.Points = 0.7;
                    this.Grade = "D-";
                    break;
                case "F":
                    this.Points = 0.0;
                    this.Grade = "F";
                    break;
                default:
                    this.Points = 0.0;
                    this.Grade = "F";
                    break;
            }
        }

 

        public void setName(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            if (Name.Length < 7)
            {
                return Name + ":\t\t" + Grade + "\t       " + Credit;
            }

            if (Name.Length > 7)
            {
                return Name + ":\t" + Grade + "\t" + Credit;
            }

            if ((Name.Length > 13) && (Name.Length < 18))
            {
                return Name + ":" + Grade + "\t" + Credit;
            }

            return Name + ":\t\t" +  Grade + "\t" + Credit;
        }

        public void GetObjectData(SerializationInfo info,
            StreamingContext context)
        {
            info.AddValue("Points", Points);
            info.AddValue("Credit", Credit);
            info.AddValue("Name", Name);
            info.AddValue("Grade", Grade);
        }
        /*
        public ClassDeserialize(SerializationInfo info, StreamingContext context)
        {
            Points = (int)info.GetValue("Points", typeof(int));
            Credit = (int)info.GetValue("Credit", typeof(int));
            Name = (string)info.GetValue("Name", typeof(string));
            Grade = (string)info.GetValue("Grade", typeof(string));
        }
        */
    }
}
