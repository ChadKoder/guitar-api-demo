using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarApi
{
    [RunInstaller(true)]
    public partial class GuitarServiceInstaller : System.Configuration.Install.Installer
    {
        public GuitarServiceInstaller()
        {
            InitializeComponent();
        }
    }
}
