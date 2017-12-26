using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HRESULT_Creator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateHRESULT_Click(object sender, EventArgs e)
        {
            LabelError.Text = "";
            {
                CodeTextBox.BackColor = ProfessionalColors.OverflowButtonGradientMiddle;
                foreach (Control c in groupBox1.Controls)
                {
                    c.BackColor = ProfessionalColors.OverflowButtonGradientMiddle;
                }
            }
            long hresultcode = 0; //32 bit number
            UInt16 codeshort = 0;
            List<int> ilist = new List<int>(32);
            ilist.Capacity = 32;
            for (int i = 0; i < 32; i++) {
                ilist.Add(0);
            }
            bool ignorecode = (CodeTextBox.Text != "");
            if (ignorecode)
            {
                try {codeshort = UInt16.Parse(CodeTextBox.Text); } //Get i16 from CodeTextBox.
                catch (Exception) {CodeTextBox.BackColor = System.Drawing.Color.Red; }
            }
            foreach (Control t in groupBox1.Controls)
            {
                if (t.GetType() == CodeTextBox.GetType())
                {
                    try
                    {
                        int i = int.Parse(t.Text);
                        if (t.Name.Contains("Bit") && t.Name != "Bits")
                        {
                            int index = 0;
                            if (t.Name.Length == 5) index = int.Parse(t.Name.Substring(3, 2)) - 1;
                            if (t.Name.Length == 4) index = int.Parse(t.Name.Substring(3, 1)) - 1;
                            if (i == 0) ilist[index] = 0;
                            if (i > 0) ilist[index] = 1;
                        }
                        else { };
                    }
                    catch (Exception ex)
                    {
                        t.BackColor = System.Drawing.Color.Red;
                        LabelError.Text += "\nError in bits! (" + t.Name + " not set! Assuming \"0\")";
                     
                    }
                }
            }

            for (int i = 0; i < 32; i++) hresultcode = hresultcode | (uint)(ilist[i] << 31 - i);
            if (codeshort != 0)
            {
                hresultcode = hresultcode & 0xFFFF0000;
                hresultcode = hresultcode | (long)codeshort;
            }
            HRESDec.Text = hresultcode.ToString();
            HRESHex.Text = "0x";
            HRESHex.Text += hresultcode.ToString("X");
            bool error3 = false, error2 = false, error5 = false;
            if (Bit3.Text == "0") error3 = true;
            if (Bit2.Text == "1" && Bit4.Text == "0") error2 = true;
            if (Bit5.Text == "1") error5 = true;
            if (error2 || error3 || error5) LabelError.Text += "\nWarning! \nI won't stop you from creating this HRESULT value, but it breaks specification!";
            if (error2) LabelError.Text += "\n(R bit set, N bit clear) ";
            if (error3) LabelError.Text += "\n(C bit not set! This should be set if this isn't a Microsoft HRESULT.)";
            if (error5) LabelError.Text += "\n(X bit set! This is reserved, and this could be ignored if there is a reason for setting it.)";
        }
        private void CodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CodeTextBox.Text == "") return;
            try
            {
                BitArray bits = new BitArray(new int[] { UInt16.Parse(CodeTextBox.Text) });

                BitArray sbit = new BitArray(bits);

                bits[0] = sbit[15];
                bits[1] = sbit[14];
                bits[2] = sbit[13];
                bits[3] = sbit[12];
                bits[4] = sbit[11];
                bits[5] = sbit[10];
                bits[6] = sbit[9];
                bits[7] = sbit[8];
                bits[8] = sbit[7];
                bits[9] = sbit[6];
                bits[10] = sbit[5];
                bits[11] = sbit[4];
                bits[12] = sbit[3];
                bits[13] = sbit[2];
                bits[14] = sbit[1];
                bits[15] = sbit[0];



                Bit17.Text = "0";
                Bit18.Text = "0";
                Bit19.Text = "0";
                Bit20.Text = "0";
                Bit21.Text = "0";
                Bit22.Text = "0";
                Bit23.Text = "0";
                Bit24.Text = "0";
                Bit25.Text = "0";
                Bit26.Text = "0";
                Bit27.Text = "0";
                Bit28.Text = "0";
                Bit29.Text = "0";
                Bit30.Text = "0";
                Bit31.Text = "0";
                Bit32.Text = "0";
                if (bits[0]) Bit17.Text = "1";
                if (bits[1]) Bit18.Text = "1";
                if (bits[2]) Bit19.Text = "1";
                if (bits[3]) Bit20.Text = "1";
                if (bits[4]) Bit21.Text = "1";
                if (bits[5]) Bit22.Text = "1";
                if (bits[6]) Bit23.Text = "1";
                if (bits[7]) Bit24.Text = "1";
                if (bits[8]) Bit25.Text = "1";
                if (bits[9]) Bit26.Text = "1";
                if (bits[10]) Bit27.Text = "1";
                if (bits[11]) Bit28.Text = "1";
                if (bits[12]) Bit29.Text = "1";
                if (bits[13]) Bit30.Text = "1";
                if (bits[14]) Bit31.Text = "1";
                if (bits[15]) Bit32.Text = "1";
            }
            catch (Exception ex) { }
        }

        private void CodeTextBox_Leave(object sender, EventArgs e)
        {
            if (CodeTextBox.Text == "") return;
            try
            {
                BitArray bits = new BitArray(new int[] { UInt16.Parse(CodeTextBox.Text) });

                BitArray sbit = new BitArray(bits);

                bits[0] = sbit[15];
                bits[1] = sbit[14];
                bits[2] = sbit[13];
                bits[3] = sbit[12];
                bits[4] = sbit[11];
                bits[5] = sbit[10];
                bits[6] = sbit[9];
                bits[7] = sbit[8];
                bits[8] = sbit[7];
                bits[9] = sbit[6];
                bits[10] = sbit[5];
                bits[11] = sbit[4];
                bits[12] = sbit[3];
                bits[13] = sbit[2];
                bits[14] = sbit[1];
                bits[15] = sbit[0];



                Bit17.Text = "0";
                Bit18.Text = "0";
                Bit19.Text = "0";
                Bit20.Text = "0";
                Bit21.Text = "0";
                Bit22.Text = "0";
                Bit23.Text = "0";
                Bit24.Text = "0";
                Bit25.Text = "0";
                Bit26.Text = "0";
                Bit27.Text = "0";
                Bit28.Text = "0";
                Bit29.Text = "0";
                Bit30.Text = "0";
                Bit31.Text = "0";
                Bit32.Text = "0";
                if (bits[0]) Bit17.Text = "1";
                if (bits[1]) Bit18.Text = "1";
                if (bits[2]) Bit19.Text = "1";
                if (bits[3]) Bit20.Text = "1";
                if (bits[4]) Bit21.Text = "1";
                if (bits[5]) Bit22.Text = "1";
                if (bits[6]) Bit23.Text = "1";
                if (bits[7]) Bit24.Text = "1";
                if (bits[8]) Bit25.Text = "1";
                if (bits[9]) Bit26.Text = "1";
                if (bits[10]) Bit27.Text = "1";
                if (bits[11]) Bit28.Text = "1";
                if (bits[12]) Bit29.Text = "1";
                if (bits[13]) Bit30.Text = "1";
                if (bits[14]) Bit31.Text = "1";
                if (bits[15]) Bit32.Text = "1";
            }
            catch (Exception ex) { }
        }
    }
}