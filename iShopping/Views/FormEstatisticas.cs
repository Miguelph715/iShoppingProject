using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iShopping.Views
{
    public partial class FormEstatisticas: Form
    {
        public FormEstatisticas()
        {
            InitializeComponent();

            tabPage1.Text = "Estatísticas";
            tabPage2.Text = "Sugestões";
        }        
    }
}
