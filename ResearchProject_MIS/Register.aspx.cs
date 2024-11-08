using System;
using System.Data.SqlClient;
using System.Data;

namespace ResearchProject_MIS
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridData();
            }
        }

        public void clearData()
        {
            idBox.Text = String.Empty;
            nameBox.Text = String.Empty;
            yearBox.Text = String.Empty;
            gpaBox.Text = String.Empty;
            emailBox.Text = String.Empty;
            passwordBox.Text = String.Empty;
            searchBox.Text = String.Empty;
        }


        public void LoadGridData()
        {
            string connectionString = "Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=RP_MIS;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT * FROM UserTable";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    dataAdapter.Fill(dataTable);
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Label2.Text = "Error: " + ex.Message;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Registration code
            string connectionString = "Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=RP_MIS;Integrated Security=True;TrustServerCertificate=True";
            string query = "INSERT INTO UserTable (StudentID, FullName, YearOfStudy, GPA, Email, Password) VALUES (@StudentID, @FullName, @YearOfStudy, @GPA, @Email, @Password)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@StudentID", idBox.Text);
                command.Parameters.AddWithValue("@FullName", nameBox.Text);
                command.Parameters.AddWithValue("@YearOfStudy", yearBox.Text);
                command.Parameters.AddWithValue("@GPA", gpaBox.Text);
                command.Parameters.AddWithValue("@Email", emailBox.Text);
                command.Parameters.AddWithValue("@Password", passwordBox.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Label2.Text = "Registration successful!";
                    clearData();
                    LoadGridData(); // Refresh GridView data
                }
                catch (Exception ex)
                {
                    Label2.Text = "Error: " + ex.Message;
                }
            }
        }

        protected void updateBTN_Click(object sender, EventArgs e)
        {
            // Update code
            string connectionString = "Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=RP_MIS;Integrated Security=True;TrustServerCertificate=True";
            string query = "update UserTable set FullName=@FullName, YearOfStudy=@YearOfStudy, GPA=@GPA, Email=@Email, Password=@Password where StudentID=@StudentID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@StudentID", idBox.Text);
                command.Parameters.AddWithValue("@FullName", nameBox.Text);
                command.Parameters.AddWithValue("@YearOfStudy", yearBox.Text);
                command.Parameters.AddWithValue("@GPA", gpaBox.Text);
                command.Parameters.AddWithValue("@Email", emailBox.Text);
                command.Parameters.AddWithValue("@Password", passwordBox.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Label2.Text = "Updated successfully!";
                    clearData();
                    LoadGridData(); // Refresh GridView data
                }
                catch (Exception ex)
                {
                    Label2.Text = "Error: " + ex.Message;
                }
            }
        }

        protected void deleteBTN_Click(object sender, EventArgs e)
        {
            // Delete code
            string connectionString = "Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=RP_MIS;Integrated Security=True;TrustServerCertificate=True";
            string query = "delete from UserTable where StudentID=@StudentID;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@StudentID", searchBox.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Label2.Text = "Deleted successfully!";
                    clearData();
                    LoadGridData(); // Refresh GridView data
                }
                catch (Exception ex)
                {
                    Label2.Text = "Error: " + ex.Message;
                }
            }
        }

        protected void searchBTN_Click(object sender, EventArgs e)
        {
            // Search code
            string connectionString = "Data Source=DESKTOP-2042M6B\\SQLEXPRESS;Initial Catalog=RP_MIS;Integrated Security=True;TrustServerCertificate=True";
            string query = "SELECT * FROM UserTable WHERE StudentID=@StudentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", searchBox.Text);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        idBox.Text = reader["StudentID"].ToString();
                        nameBox.Text = reader["FullName"].ToString();
                        yearBox.Text = reader["YearOfStudy"].ToString();
                        gpaBox.Text = reader["GPA"].ToString();
                        emailBox.Text = reader["Email"].ToString();
                        passwordBox.Text = reader["Password"].ToString();
                    }
                    else
                    {
                        Label2.Text = "ID not found.";
                        clearData();
                    }
                }
                catch (Exception ex)
                {
                    Label2.Text = "Error: " + ex.Message;
                }
            }
        }
    }
}
