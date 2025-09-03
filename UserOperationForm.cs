using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Temperature_and_Humidity_Collection.UserControls;

namespace Temperature_and_Humidity_Collection
{
    public partial class UserOperationForm : Form
    {
        public UserOperationForm(int id)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            switch (id)
            {
                case 0:
                    var control1 = new AddUserControl();
                    this.Controls.Add(control1);
                    control1.Location = new Point(12, 12);
                    control1.CloseRequested += CloseSelf_OK;
                    control1.CancelRequested += CloseSelf_Cancel;
                    break;
                case 1:
                    var control2 = new UpdateUserControl();
                    this.Controls.Add(control2);
                    control2.Location = new Point(12, 12);
                    control2.CloseRequested += CloseSelf_OK;
                    control2.CancelRequested += CloseSelf_Cancel;
                    break;
                case 2:
                    var control3 = new DeleteUserControl();
                    this.Controls.Add(control3);
                    control3.Location = new Point(12, 12);
                    control3.CloseRequested += CloseSelf_OK;
                    control3.CancelRequested += CloseSelf_Cancel;
                    break;
            }
        }

        private void CloseSelf_OK(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CloseSelf_Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
