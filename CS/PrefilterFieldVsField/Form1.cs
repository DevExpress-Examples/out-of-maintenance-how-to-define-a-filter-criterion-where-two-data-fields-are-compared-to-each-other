using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;
using DevExpress.Data.Filtering;

namespace PrefilterFieldVsField {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            SetupPivot(pivotGridControl1);

            pivotGridControl1.ActiveFilterCriteria = new OperandProperty("ActualSale") > new OperandProperty("ForecastSale");
        }

        private void SetupPivot(PivotGridControl grid) {
            DataTable Table = new DataTable();
            Table.Columns.Add("Category Name", typeof(string));
            Table.Columns.Add("Product Name", typeof(string));
            Table.Columns.Add("Year", typeof(int));
            Table.Columns.Add("ForecastSale", typeof(float));
            Table.Columns.Add("ActualSale", typeof(float));
            Table.Columns.Add("Quantity", typeof(int));
            Table.Columns.Add("Employee Name", typeof(string));

            Table.Rows.Add(new object[] { "Beverages", "Chai", 1995, 5000, 5070.60, 319, null });
            Table.Rows.Add(new object[] { "Beverages", "Chai", 1996, 6000, 6295.50, 399, null });
            Table.Rows.Add(new object[] { "Beverages", "Ipoh Coffee", 1995, 11000, 10034.90, 228, null });
            Table.Rows.Add(new object[] { "Beverages", "Ipoh Coffee", 1996, 8000, 8560.60, 216, null });
            Table.Rows.Add(new object[] { "Confections", "Chocolade", 1995, 1500, 1282.01, 130, null });
            Table.Rows.Add(new object[] { "Confections", "Chocolade", 1996, 800, 886.70, 8, null });
            Table.Rows.Add(new object[] { "Confections", "Scottish Longbreads", 1995, 4000, 3909.00, 380, null });
            Table.Rows.Add(new object[] { "Confections", "Scottish Longbreads", 1996, 4000, 4175.00, 354, null });

            grid.DataSource = new BindingSource(Table, "");

            grid.Fields.AddDataSourceColumn("Category Name", PivotArea.RowArea);
            grid.Fields.AddDataSourceColumn("Product Name", PivotArea.RowArea);
            grid.Fields.AddDataSourceColumn("Year", PivotArea.FilterArea);
            grid.Fields.AddDataSourceColumn("ForecastSale", PivotArea.FilterArea);
            grid.Fields.AddDataSourceColumn("ActualSale", PivotArea.FilterArea);
            grid.Fields.AddDataSourceColumn("Quantity", PivotArea.DataArea);

        }
    }
}
