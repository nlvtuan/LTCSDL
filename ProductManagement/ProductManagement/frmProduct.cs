using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace ProductManagement
{
    public partial class frmProduct : Form
    {
        private SqlConnection cn = null;

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            string cnStr = "Server = .; Database = QLBanHang; Integrated security = true;";
            cn = new SqlConnection(cnStr);

            dgvProduct.DataSource = GetData();
        }

        private void Connect()
        {
            try
            {
                if (cn != null && cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Cannot open a connection without specifying a data source or server \n\n" + ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("A connection-level error occurred while opening the connection \n\n" + ex.Message);
            }
            catch (ConfigurationErrorsException ex)
            {
                MessageBox.Show("There are two entries with the same name in the <localdbinstances> section \n\n" + ex.Message);
            }

        }

        private void DisConnect()
        {
            if (cn != null && cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
        }

        private List<object> GetData()
        {
            Connect();

            string sql = "SELECT * FROM SanPham";

            List<object> list = new List<object>();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader dr = cmd.ExecuteReader();

                string id, name, unit, image;
                double price;
                int categoryId;

                while (dr.Read())
                {
                    id = dr.GetString(0);
                    name = dr.GetString(1);
                    unit = dr.GetString(2);
                    // ...

                    var prod = new
                    {
                        MaSP = id,
                        TenSP = name,
                        DVT = unit
                    };
                    list.Add(prod);
                }
                dr.Close();
            }
            catch (SqlException ex) // Internet => Exception
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return list;
        } // End of GetData

    } // End of frmProduct
}
