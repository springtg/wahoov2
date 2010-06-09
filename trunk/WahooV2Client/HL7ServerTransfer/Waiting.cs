using System.Windows.Forms;

namespace HL7ServerTransfer
{
    public partial class Waiting : Form
    {
        public Waiting(string msg)
        {
            InitializeComponent();
            lbMessage.Text = msg;
        }

        public string LBMessage
        {
            set { lbMessage.Text = value; }
        }
    }
}
