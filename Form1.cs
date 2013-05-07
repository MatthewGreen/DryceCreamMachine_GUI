﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DryceCreamGUI
{
    public partial class frm_Main : Form
    {

        String temp = "1";
        bool btnFlag = true;

        public frm_Main()
        {
            InitializeComponent();
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            //If using boolean the structure would be [0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]
            //Slot A
            bool VanillaA = cb_A_Vanilla.Checked;
            bool ChocolateA = cb_A_Chocolate.Checked;
            bool ToppingA = cb_A_Topping.Checked;

            //Slot B
            bool VanillaB = cb_B_Vanilla.Checked;
            bool ChocolateB = cb_B_Chocolate.Checked;
            bool ToppingB = cb_B_Topping.Checked;

            //Slot C
            bool VanillaC = cb_C_Vanilla.Checked;
            bool ChocolateC = cb_C_Chocolate.Checked;
            bool ToppingC = cb_C_Topping.Checked;

            //Slot D
            bool VanillaD = cb_D_Vanilla.Checked;
            bool ChocolateD = cb_D_Chocolate.Checked;
            bool ToppingD = cb_D_Topping.Checked;

            //Slot E
            bool VanillaE = cb_E_Vanilla.Checked;
            bool ChocolateE = cb_E_Chocolate.Checked;
            bool ToppingE = cb_E_Topping.Checked;

            String concatA = VanillaA.ToString() + "," + ChocolateA.ToString() + "," + ToppingA.ToString();
            String concatB = VanillaB.ToString() + "," + ChocolateB.ToString() + "," + ToppingB.ToString();
            String concatC = VanillaC.ToString() + "," + ChocolateC.ToString() + "," + ToppingC.ToString();
            String concatD = VanillaD.ToString() + "," + ChocolateD.ToString() + "," + ToppingD.ToString();
            String concatE = VanillaE.ToString() + "," + ChocolateE.ToString() + "," + ToppingE.ToString();

            String finalString = concatA + "," + concatB + "," + concatC + "," + concatD + "," + concatE;

            System.Windows.Forms.MessageBox.Show(finalString);
            
            //Serial Part BEGIN ---------------------------
            serialPort1.PortName = "COM6";
            serialPort1.BaudRate = 9600;
            serialPort1.DtrEnable = true;
            

            //Uncomment this when test with the Arduino
            serialPort1.Open();

            System.Threading.Thread.Sleep(2000);

            if (serialPort1.IsOpen)
            {
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                Byte[] bytes = encoding.GetBytes(finalString);
                
                btn_Done.Enabled = false;
                //serialPort1.Write("1");
                Console.WriteLine(temp.ToCharArray());
                //serialPort1.Write(new byte[] { bytes }, 0, 1);
                serialPort1.Write(bytes, 0, bytes.Length);
                System.Threading.Thread.Sleep(1000);
                btn_Done.Enabled = true;
            }


        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Ice Creams Are All Done!", "Status!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Console.Write(serialPort1.ReadExisting());
            serialPort1.Close();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }
    }
}
