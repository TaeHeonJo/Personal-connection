using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace personal_connections
{
    public partial class Form1 : Form
    {
        int people_no;
        String people_name;
        //하는일은 사용자 검색 시(button6) no,name값 저장.
        //people_no, people_name 두개의 전역변수는 button3_Click()함수와
        //button4_Click()함수에서 content 추가, 삭제 관련하여 참조함.
        
        public Form1()
        {
            InitializeComponent();
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            String name;
            name = textBox4.Text;

            DB_code db = new DB_code();
            db.Insert_people(name);
            textBox4.Clear();
            button5.PerformClick();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<personal_connections.Part> parts;

            textBox1.Clear();

            DB_code db = new DB_code();
            parts = db.Select_people();
            
            foreach(Part aPart in parts)
            {
                String sentence;

                sentence = Convert.ToString(aPart.Partno)+"."+aPart.PartName+"\r\n";

                textBox1.AppendText(sentence);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            List<personal_connections.Search> searches;
            String name;
            int a;

            a = Convert.ToInt32(textBox5.Text);
            name = textBox6.Text;

            //전역변수에 값을 넣어줌. 이유는 내용을 추가 시 번호필요.
            people_no = a;
            people_name = name;          

            DB_code db = new DB_code();
            searches = db.Select_content(people_no, people_name);

            textBox2.Clear();
            foreach (Search aSearch in searches)
            {
                String sentence;
                String content = aSearch.content;
                int pn_no = aSearch.pn_no;
                int no = aSearch.no;

                sentence = content;
                textBox2.AppendText(sentence);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String content;

            content = textBox2.Text;

            DB_code db = new DB_code();

            db.Update_content(people_name, content, people_no);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int no;

            no = Convert.ToInt32(textBox8.Text);

            DB_code db = new DB_code();
            db.Delete_people(no);
            db.Delete_content(no);//내용을 삭제하는 이유는 쓰레기값 남기기 싫어서임
            textBox8.Clear();
            button5.PerformClick();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

            object missing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document doc = app.Documents.Add();

            doc.Content.SetRange(0, 0);

            //Doc파일에 제목
            Microsoft.Office.Interop.Word.Paragraph para1 = doc.Content.Paragraphs.Add(ref missing);
            //object styleHeading1 = "Heading 1";
            //para1.Range.set_Style(ref styleHeading1);
            para1.Range.Text = "인맥 정보";
            para1.Range.InsertParagraphAfter();

            //Doc파일에 테이블생성
            Microsoft.Office.Interop.Word.Table table;
            table = doc.Tables.Add(para1.Range, 2, 2, ref missing, ref missing);
            table.Borders.Enable = 1;
            
            //Doc파일에 테이블입력
            table.Cell(1, 1).Range.Text = "이름";
            table.Cell(1, 2).Range.Text = "내용";
            table.Cell(2, 1).Range.Text = textBox6.Text;
            table.Cell(2, 2).Range.Text = textBox2.Text;
            
            
            object filename = @"C:\Users\J\Desktop\personal connection.docx";
            doc.SaveAs2(ref filename);
            doc.Close();
        }
    }
}