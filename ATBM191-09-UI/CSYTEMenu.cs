﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATBM191_09_UI
{
    public partial class CSYTEMenu : Form
    {
        public CSYTEMenu()
        {
            InitializeComponent();
            Them_Button.Visible = false;
        }

        private void HSBA_Button_Click(object sender, EventArgs e)
        {
            Them_Button.Visible = true;
        }

        private void PersonalInfo_Button_Click(object sender, EventArgs e)
        {

        }

        private void Them_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
