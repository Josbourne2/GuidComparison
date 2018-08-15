using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GuidComparison.Workers;

namespace GuidComparison
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Name = "Guid comparison";


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            InsertMethods.InsertDelegate handler = null;
            int numberOfRowsToInsert;
            int.TryParse(txtNumberOfRows.Text, out numberOfRowsToInsert);
            for (int i = 0; i < cblInsertOptions.Items.Count; i++)
            {
                if (cblInsertOptions.GetItemChecked(i))
                {
                    if (cblInsertOptions.Items[i].ToString() == "Random guids")
                    {
                        handler += Workers.InsertMethods.InsertRandomGuids;                        
                    } 
                    //MessageBox.Show(cblInsertOptions.Items[i].ToString());
                    if (cblInsertOptions.Items[i].ToString() == "Sequential guids (Leonid)")
                    {
                        handler += Workers.InsertMethods.InsertLeonid;
                    }
                    if (cblInsertOptions.Items[i].ToString() == "Sequential guids (RT.Comb)")
                    {
                        handler += Workers.InsertMethods.InsertRTComb;
                    }
                     
                }
            }

            //Execute all methods
            handler?.Invoke(numberOfRowsToInsert);


        }
    }
}
