using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            format.Text = "EAN_13";
            code.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            string barcode = code.Text;

            //System.Diagnostics.Debug.WriteLine(barcode + " -> " + barcode.Length.ToString());
            if (format.Text == "EAN_13" && barcode.Length == 13)
            {
                process(barcode);
            }

            if (format.Text == "UPC_A" && barcode.Length == 12)
            {
                process(barcode);
            }

        }


        protected void process(string code)
        {
            MessageBox.Show(code);
            var brcode = new ZXing.BarcodeWriter();
            var encOptions = new ZXing.Common.EncodingOptions() { Width = Convert.ToInt32(width.Value), Height = Convert.ToInt32(height.Value), Margin = Convert.ToInt32(margin.Value) };
            brcode.Options = encOptions;
            switch (format.Text)
            {
                case "EAN_13":
                    brcode.Format = ZXing.BarcodeFormat.EAN_13;
                    break;
                case "UPC_A":
                    brcode.Format = ZXing.BarcodeFormat.UPC_A;
                    break;
                default:
                    MessageBox.Show("Unsupported");
                    return;
            }
            Bitmap result = new Bitmap(brcode.Write(code));
            result.Save("test.bmp");
            picture.ImageLocation = "test.bmp";
        }

        private void format_SelectedIndexChanged(object sender, EventArgs e)
        {
            code.Focus();
        }
    }
}
