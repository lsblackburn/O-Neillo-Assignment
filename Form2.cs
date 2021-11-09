using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_Neillo_Assignment
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
            // When about menu is opened, the OK button can be clicked to close it
        }
    }
}
