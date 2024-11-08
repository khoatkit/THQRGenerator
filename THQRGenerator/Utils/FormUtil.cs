using System;
using System.Drawing;
using System.Windows.Forms;

namespace THQRGenerator.Utils
{
    class FormUtil
    {
        public static void ScaleListViewColumns(ListView listview, SizeF factor)
        {
            foreach (ColumnHeader column in listview.Columns)
                column.Width = (int)Math.Round(column.Width * factor.Width);
        }
        public static void ScaleDataGridViewColumns(DataGridView dataGridView, SizeF factor)
        {
            dataGridView.RowHeadersWidth = (int)Math.Round(dataGridView.RowHeadersWidth * factor.Width);
            foreach (DataGridViewColumn column in dataGridView.Columns)
                column.Width = (int)Math.Round(column.Width * factor.Width);
        }
    }
}
