using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GiftEjecutor
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            //hacerFeo();
         
        }

        public void hacerFeo()
        {
            //labelCargando.Text = "Cargando";
            int contador = 0;
            for (int i = 0; i < 100000; ++i)                
            {
                if (contador < 3)
                {
                    labelCargando.Text = labelCargando.Text + ".";
                    ++contador;
                }
                else
                {
                    labelCargando.Text = "Cargando";
                    contador = 0;
                }
                //for (int j = 0; j < 1000; ++j)
                //{
                //}
            }
        }
    }
}