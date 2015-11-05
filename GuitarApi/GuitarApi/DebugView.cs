using System;
using System.Windows.Forms;

namespace GuitarApi
{
    public partial class DebugView : Form
    {
        private bool _stop;

        public bool Stop
        {
            get { return _stop; }
        }
        public DebugView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _stop = true;
        }
    }
}
