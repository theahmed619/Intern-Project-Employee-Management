using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Intern_Project_Employee_Management
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        // Load GridView
        void LoadData()
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                string query = @"SELECT e.Emp_Id AS [Employee ID], e.Emp_Name AS [Name], e.Emp_Age AS [Age], e.Emp_Salary AS [Salary], d.Dpt_Name AS [Department]
                                 FROM Employee e 
                                 LEFT JOIN Department d ON e.Emp_Id = d.Emp_Id 
                                 ORDER BY e.Emp_Id DESC";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Error: " + ex.Message;
            }
        }

        // GridView Row Selection Handler
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.SelectedRow;

                // Cells mapping starts from 1 because index 0 holds the "Select" trigger link
                txtid.Text = HttpUtility.HtmlDecode(row.Cells[1].Text).Trim();
                txtName.Text = HttpUtility.HtmlDecode(row.Cells[2].Text).Trim();
                txtAge.Text = HttpUtility.HtmlDecode(row.Cells[3].Text).Trim();
                txtSalary.Text = HttpUtility.HtmlDecode(row.Cells[4].Text).Trim();
                txtDept.Text = HttpUtility.HtmlDecode(row.Cells[5].Text).Trim();

                lblMsg.ForeColor = System.Drawing.Color.Blue;
                lblMsg.Text = "Record copied to input boxes! Edit fields and hit Update.";
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Selection Error: " + ex.Message;
            }
        }

        // ADD Operation
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            try
            {
                con.Open();

                string addEmp = @"INSERT INTO Employee (Emp_Name, Emp_Age, Emp_Salary) 
                                  VALUES (@Name, @Age, @Salary); 
                                  SELECT SCOPE_IDENTITY();";

                SqlCommand cmd1 = new SqlCommand(addEmp, con);
                cmd1.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd1.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text.Trim()));
                cmd1.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtSalary.Text.Trim()));

                int newEmpId = Convert.ToInt32(cmd1.ExecuteScalar());

                string addDept = "INSERT INTO Department (Emp_Id, Dpt_Name) VALUES (@EmpId, @DeptName)";
                SqlCommand cmd2 = new SqlCommand(addDept, con);
                cmd2.Parameters.AddWithValue("@EmpId", newEmpId);
                cmd2.Parameters.AddWithValue("@DeptName", txtDept.Text.Trim());
                cmd2.ExecuteNonQuery();

                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Record added successfully!";
                ClearFields();
                LoadData();
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        // UPDATE Operation
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Please select or provide an Employee ID to update!";
                return;
            }

            SqlConnection con = new SqlConnection(conStr);
            try
            {
                con.Open();
                int empId = Convert.ToInt32(txtid.Text.Trim());

                string updateEmp = "UPDATE Employee SET Emp_Name=@Name, Emp_Age=@Age, Emp_Salary=@Salary WHERE Emp_Id=@EmpId";
                SqlCommand cmd1 = new SqlCommand(updateEmp, con);
                cmd1.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd1.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text.Trim()));
                cmd1.Parameters.AddWithValue("@Salary", Convert.ToDecimal(txtSalary.Text.Trim()));
                cmd1.Parameters.AddWithValue("@EmpId", empId);
                cmd1.ExecuteNonQuery();

                string updateDept = "UPDATE Department SET Dpt_Name=@DeptName WHERE Emp_Id=@EmpId";
                SqlCommand cmd2 = new SqlCommand(updateDept, con);
                cmd2.Parameters.AddWithValue("@DeptName", txtDept.Text.Trim());
                cmd2.Parameters.AddWithValue("@EmpId", empId);
                cmd2.ExecuteNonQuery();

                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Record updated successfully!";
                ClearFields();
                LoadData();
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        // DELETE Operation
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Please enter Employee ID to delete!";
                return;
            }

            SqlConnection con = new SqlConnection(conStr);
            try
            {
                con.Open();
                int empId = Convert.ToInt32(txtid.Text.Trim());

                string deleteQuery = "DELETE FROM Employee WHERE Emp_Id = @EmpId";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.Parameters.AddWithValue("@EmpId", empId);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Record deleted successfully!";
                    ClearFields();
                    LoadData();
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "No record found with ID: " + empId;
                }
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        // SEARCH Operation
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid.Text))
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Please enter Employee ID to search!";
                return;
            }

            SqlConnection con = new SqlConnection(conStr);
            try
            {
                con.Open();
                int empId = Convert.ToInt32(txtid.Text.Trim());

                string query = @"SELECT e.Emp_Id, e.Emp_Name, e.Emp_Age, e.Emp_Salary, d.Dpt_Name 
                                 FROM Employee e 
                                 LEFT JOIN Department d ON e.Emp_Id = d.Emp_Id 
                                 WHERE e.Emp_Id = @EmpId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmpId", empId);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtName.Text = dr["Emp_Name"].ToString();
                    txtAge.Text = dr["Emp_Age"].ToString();
                    txtSalary.Text = dr["Emp_Salary"].ToString();
                    txtDept.Text = dr["Dpt_Name"].ToString();

                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    lblMsg.Text = "Record found!";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                    lblMsg.Text = "No record found with ID: " + empId;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        void ClearFields()
        {
            txtid.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtSalary.Text = "";
            txtDept.Text = "";
        }
    }
}