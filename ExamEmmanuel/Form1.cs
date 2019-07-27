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
using System.IO;


namespace ExamEderCiolette
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source = INSTRUCTORIT; Initial Catalog = TournamentManager; " +
                                  "User ID = ProfileUser; Password = ProfileUser2019";
        private IEnumerable<object> query;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)

        {


            if (txt1.Text == string.Empty)
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            if (txt2.Text == string.Empty)
            {
                MessageBox.Show("Please enter a CoachName.");
                return;
            }


            if (txt3.Text == string.Empty)
            {
                MessageBox.Show("Please enter a DirectorsName.");
                return;
            }

            if (txt4.Text == string.Empty)
            {
                MessageBox.Show("Please enter address.");
                return;
            }


            if (txt6.Text == string.Empty)
            {
                MessageBox.Show("Please enter a PostaCode.");
                return;
            }

            if (txt7.Text == string.Empty)
            {
                MessageBox.Show("Please enter a City.");
                return;
            }

            if (txt8.Text == string.Empty)
            {
                MessageBox.Show("Please enter a City.");
                return;
            }

            if (txt9.Text == string.Empty)
            {
                MessageBox.Show("Please enter an Email Address.");
                return;
            }


            if (txt10.Text == string.Empty)
            {
                MessageBox.Show("Please enter who it was created by.");
                return;
            }

            SqlConnection myConnection = new SqlConnection(connectionString);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();
                string mySql = "INSERT INTO Teams (TeamName, CoachName, DirectorName, AddressLine1, AddressLine2, PostCode, City, ContactNumber, EmailAddress, CreatedBy) " +
                                " VALUES ('" + txt1.Text + "','" + txt2.Text + "'," +
                                " '" + txt3.Text + "','" + txt4.Text + "','" + txt5.Text + "','" + txt6.Text + "','" + txt7.Text + "','" + txt8.Text + "','" + txt9.Text + "','" + txt10.Text + "')";

                myCommand.Connection = myConnection;
                myCommand.CommandText = mySql;

                myCommand.ExecuteNonQuery();
               
               
                MessageBox.Show("Successfully Saved", "Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail");
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
            }
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();

                string mySql = "DELETE FROM Teams WHERE TeamId = " + txtDelete.Text;

                myCommand.Connection = myConnection;
                myCommand.CommandText = mySql;

                myCommand.ExecuteNonQuery();

                btnDelete.Text = "";
                MessageBox.Show("Successfully Deleted", "Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail");
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {


            if (textBox16.Text == string.Empty)
            {
                MessageBox.Show("Please enter a name.");
                return;
            }

            if (textBox15.Text == string.Empty)
            {
                MessageBox.Show("Please enter a CoachName.");
                return;
            }


            if (textBox14.Text == string.Empty)
            {
                MessageBox.Show("Please enter a DirectorsName.");
                return;
            }

            if (textBox13.Text == string.Empty)
            {
                MessageBox.Show("Please enter address.");
                return;
            }


            if (textBox11.Text == string.Empty)
            {
                MessageBox.Show("Please enter a PostaCode.");
                return;
            }

            if (textBox10.Text == string.Empty)
            {
                MessageBox.Show("Please enter a City.");
                return;
            }

            if (textBox9.Text == string.Empty)
            {
                MessageBox.Show("Please enter a ContactNumber.");
                return;
            }

            if (textBox8.Text == string.Empty)
            {
                MessageBox.Show("Please enter an Email Address.");
                return;
            }


            if (textBox7.Text == string.Empty)
            {
                MessageBox.Show("Please enter who it was created by.");
                return;
            }


            SqlConnection myConnection = new SqlConnection(connectionString);

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();

                
                


                string mySql = "UPDATE Teams SET TeamName = '" + textBox16.Text + "', CoachName = '" + textBox15.Text + "', DirectorName = '" + textBox14.Text + "', AddressLine1 = '" + textBox13.Text + "'   , AddressLine2 = '" + textBox12.Text + "' , PostCode = '" + textBox11.Text + "'   , City = '" + textBox10.Text + "'   , ContactNumber = '" + textBox9.Text + "'   , EmailAddress = '" + textBox8.Text + "' ,  CreatedBy  = '" + textBox7.Text + "'   " +
                "WHERE TeamId = '" + txt11.Text + "'";

                myCommand.Connection = myConnection;
                myCommand.CommandText = mySql;

                myCommand.ExecuteNonQuery();

               
                MessageBox.Show("Successfully Update", "Update");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail");
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
            }

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {

            
                SqlConnection myConnection = new SqlConnection(connectionString);

                try
                {
                    TextWriter sw = new StreamWriter(@"c:\\TEAMLIST.txt");
                    int rowcount = gridResults.Rows.Count;
                    for (int i = 0; i < rowcount - 1; i++)
                    {
                        sw.WriteLine(gridResults.Rows[i].Cells[0].Value.ToString() + "\t" + gridResults.Rows[i].Cells[1].Value.ToString() + "\t" + gridResults.Rows[i].Cells[2].Value.ToString());
                    }
                    sw.Close();     //Don't Forget Close the TextWriter Object(sw)


                    MessageBox.Show("Data Successfully Exported");



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fail");
                }
                finally
                {
                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Close();
                }

            }
        

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();

                string mySql = "SELECT * FROM Teams";

                myCommand.Connection = myConnection;
                myCommand.CommandText = mySql;

                SqlDataReader myReader;
                myReader = myCommand.ExecuteReader();

                DataTable myTable = new DataTable();


                
                myTable.Columns.Add("TeamId");
                myTable.Columns.Add("TeamName");
                myTable.Columns.Add("CoachName");
                myTable.Columns.Add("DirectorName");
                myTable.Columns.Add("AddressLine1");
                myTable.Columns.Add("AddressLine2");
                myTable.Columns.Add("PostCode");
                myTable.Columns.Add("City");
                myTable.Columns.Add("ContactNumber");
                myTable.Columns.Add("EmailAddress");
                myTable.Columns.Add("CreatedBy");


                while (myReader.Read())
                {
                    DataRow Teams = myTable.NewRow();

                    Teams["TeamId"] = myReader["TeamId"].ToString();
                    Teams["TeamName"] = myReader["TeamName"].ToString();
                    Teams["CoachName"] = myReader["CoachName"].ToString();
                    Teams["DirectorName"] = myReader["DirectorName"].ToString();
                    Teams["AddressLine1"] = myReader["AddressLine1"].ToString();
                    Teams["AddressLine2"] = myReader["AddressLine2"].ToString();
                    Teams["PostCode"] = myReader["PostCode"].ToString();
                    Teams["City"] = myReader["City"].ToString();
                    Teams["ContactNumber"] = myReader["ContactNumber"].ToString();
                    Teams["EmailAddress"] = myReader["EmailAddress"].ToString();
                    Teams["CreatedBy"] = myReader["CreatedBy"].ToString();

                    myTable.Rows.Add(Teams);

                }

                gridResults.DataSource = myTable;

                gridResults.Update();
                gridResults.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fail!");
            }
            finally
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();
            }
        }

        private void BtnLinq_Click(object sender, EventArgs e)
        {
            
            //var results = from p in Teams 
            //              where p.LastName == "'SMITH'"
            //              select p;

            //foreach (var l in query)
            //{
            //    gridResults.Text = int.Parse(results.ToString());
            //}


        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label25_Click(object sender, EventArgs e)
        {

        }

        private void Label26_Click(object sender, EventArgs e)
        {

        }

        private void Label27_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {





            {
                SqlConnection myConnection = new SqlConnection(connectionString);

                try
                {
                    TextWriter sw = new StreamWriter(@"c:\\TEAMLIST.txt");
                    int rowcount = gridResults.Rows.Count;
                    for (int i = 0; i < rowcount - 1; i++)
                    {
                        sw.WriteLine(gridResults.Rows[i].Cells[0].Value.ToString() + "\t" + gridResults.Rows[i].Cells[1].Value.ToString() + "\t" + gridResults.Rows[i].Cells[2].Value.ToString() + "\t" + gridResults.Rows[i].Cells[3].Value.ToString() + "\t" + gridResults.Rows[i].Cells[4].Value.ToString() + "\t" + gridResults.Rows[i].Cells[5].Value.ToString() + "\t" + gridResults.Rows[i].Cells[6].Value.ToString() + "\t" + gridResults.Rows[i].Cells[7].Value.ToString() + "\t" + gridResults.Rows[i].Cells[8].Value.ToString() + "\t" + gridResults.Rows[i].Cells[9].Value.ToString() + "\t" + gridResults.Rows[i].Cells[10].Value.ToString());
                    }
                    sw.Close();     //Don't Forget Close the TextWriter Object(sw)


                    MessageBox.Show("Data Successfully Exported");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fail");
                }
                finally
                {
                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Close();
                }



            }




        }
    }
}

