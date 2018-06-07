using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace personal_connections
{
    public class DB_code
    {
        public void Update_content(String name, String content, int pn_no)
        {
            string connectionString = "server = J-PC; uid = localhost; pwd = 1234; database = personal connection;";

            SqlConnection scon = new SqlConnection(connectionString);
            SqlCommand scom = new SqlCommand();

            scom.Connection = scon;
            scom.CommandText = "select no, name, content, pn_no from content where name = '"+name+"' and pn_no="+pn_no+"";
            scon.Open();

            SqlDataReader sdr = scom.ExecuteReader();     

            for(int a=0; a<1; a++)
            {
                int number=0;
                                
                if (!sdr.Read())
                {
                    sdr.Close();
                    scom.CommandText = "insert into content(name, content, pn_no) values('" + name + "', ' " + content + "', " + pn_no + ")";
                    scom.ExecuteReader();
                }
                else
                {
                    number = Convert.ToInt32(sdr["no"]);
                    sdr.Close();
                    scom.CommandText = "update content set content = '"+content+"' where no = "+number+"";
                    scom.ExecuteReader();
                }
            }
        }

        public void Insert_content (String name, String content, int pn_no)
        {
            string connectionString = "server = J-PC; uid = localhost; pwd = 1234; database = personal connection;";

            SqlConnection scon = new SqlConnection(connectionString);
            SqlCommand scom = new SqlCommand();

            scom.Connection = scon;
            scom.CommandText = "insert into content(name, content, pn_no) values('" + name + "', ' " + content + "', " + pn_no + ")";
            scon.Open();

            SqlDataReader sdr = scom.ExecuteReader();
        }

        public void Delete_people (int no)
        {
            string connectionString = "server = J-PC; uid = localhost; pwd = 1234; database = personal connection;";

            SqlConnection scon = new SqlConnection(connectionString);
            SqlCommand scom = new SqlCommand();

            scom.Connection = scon;
            scom.CommandText = "delete from [people name] where no = " + no + "";
            scon.Open();

            SqlDataReader sdr = scom.ExecuteReader();
        }

        public void Delete_content(int pn_no)
        {
            string connectionString = "server = J-PC; uid = localhost; pwd = 1234; database = personal connection;";

            SqlConnection scon = new SqlConnection(connectionString);
            SqlCommand scom = new SqlCommand();

            scom.Connection = scon;
            scom.CommandText = "Delete from content where pn_no = " + pn_no + "";
            scon.Open();

            SqlDataReader sdr = scom.ExecuteReader();
        }

        public void Insert_people(String name)
        {
            string connectionString = "server = J-PC; uid = localhost; pwd = 1234; database = personal connection;";

            SqlConnection scon = new SqlConnection(connectionString);
            SqlCommand scom = new SqlCommand();

            scom.Connection = scon;
            scom.CommandText = "insert into [people name] (name) values('" + name + "')";
            scon.Open();

            SqlDataReader sdr = scom.ExecuteReader();
        }

        public List<personal_connections.Part> Select_people()
        {
            List<Part> parts = new List<Part>();

            //SQL문 시작
            string connectionString = "server = J-PC; uid = localhost; pwd = 1234; database = personal connection;";

            SqlConnection scon = new SqlConnection(connectionString);
            SqlCommand scom = new SqlCommand();

            scom.Connection = scon;
            scom.CommandText = "select no, name from [people name]";
            scon.Open();
            
            SqlDataReader sdr = scom.ExecuteReader();

            while(sdr.Read())
            {
                int no = Convert.ToInt32(sdr["no"]);
                String name = Convert.ToString(sdr["name"]);
                parts.Add(new Part() { Partno = no, PartName = name });
            }

            return parts;
        }

        public List<personal_connections.Search> Select_content(int a, String name)
        {
            List<Search> searches = new List<Search>();

            //SQL문 시작
            string connectionString = "server = J-PC; uid = localhost; pwd = 1234; database = personal connection;";

            SqlConnection scon = new SqlConnection(connectionString);
            SqlCommand scom = new SqlCommand();

            scom.Connection = scon;
            scom.CommandText = "select pn_no, content, no from content where pn_no = "+a+" and name = '"+name+"'";
            scon.Open();

            SqlDataReader sdr = scom.ExecuteReader();

            while (sdr.Read())
            {
                int pn_no = Convert.ToInt32(sdr["pn_no"]);
                String content = Convert.ToString(sdr["content"]);
                int no = Convert.ToInt32(sdr["no"]);

                searches.Add(new Search() {pn_no = pn_no, content = content, no = no });
            }

            return searches;
        }
    }

    public class Part : IEquatable<Part>
    {
        //Part클래스는 People List에 뿌려주는 데이터 저장 클래스임.
        public string PartName { get; set; }

        public int Partno { get; set; }

        public override string ToString()
        {
            return "No: " + Partno + "   Name: " + PartName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return Partno;
        }
        public bool Equals(Part other)
        {
            if (other == null) return false;
            return (this.Partno.Equals(other.Partno));
        }
        // Should also override == and != operators.
    }

    public class Search : IEquatable<Search>
    {
        //Search클래스는 Contents에 뿌려주는 데이터 저장 클래스임.
        public string content { get; set; }

        public int pn_no { get; set; }

        public int no { get; set; }

        public override string ToString()
        {
            return "Pn_no: " + pn_no + "   Content: " + content + " No: " + no;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Search objAsPart = obj as Search;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return pn_no;
        }
        public bool Equals(Search other)
        {
            if (other == null) return false;
            return (this.pn_no.Equals(other.pn_no));
        }
        // Should also override == and != operators.
    }
}
