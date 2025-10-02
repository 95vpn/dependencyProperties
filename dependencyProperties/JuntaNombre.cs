using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependencyProperties
{
    public class JuntaNombre :INotifyPropertyChanged
    {
        private string nombre, apellido, nombre_completo;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public string Nombre
        {
            get { return nombre; } set { nombre = value; }
        }

        public string Apellido
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Nombre_completo
        {
            get { return nombre_completo = Nombre + " " + Apellido; }
            set {  }
        }
    }
}
