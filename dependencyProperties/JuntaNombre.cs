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
        private string[] result;

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
            get { return nombre; } 
            set { nombre = value;

                OnPropertyChanged(nameof(Apellido));
                OnPropertyChanged(nameof(Nombre_completo));
            }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value;

                OnPropertyChanged(nameof(Apellido));
                OnPropertyChanged(nameof(Nombre_completo));
            }
        }

        public string Nombre_completo
        {
            get => $"{Nombre} {Apellido}".Trim();
            /*
            set 
            { 
                if (value != nombre_completo)
                {
                    nombre_completo = value;
                    string[] partes = new string[] { " " };
                    result = nombre_completo.Split(partes, 2, StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();

                    if (partes.Length > 0)
                    {
                        Nombre = partes[0];
                        
                    }
                    if (partes.Length > 1)
                    {
                        Apellido = partes[1];
                        
                    }
                    else
                    {
                        Apellido = string.Empty;
                    }
                    OnPropertyChanged(nameof(Nombre_completo));
                }
            }*/

            set
            {
                // Evitar notificaciones innecesarias si no hay cambios
                if (value != nombre_completo)
                {
                    nombre_completo = value;

                    if (string.IsNullOrWhiteSpace(value))
                    {
                        // 🧹 Si el usuario borra todo el texto, limpiamos nombre y apellido
                        Nombre = string.Empty;
                        Apellido = string.Empty;
                    }
                    else
                    {
                        // 🧩 Separar el texto en dos partes (Nombre y Apellido)
                        string[] partes = value.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

                        if (partes.Length > 0)
                            Nombre = partes[0];
                        if (partes.Length > 1)
                            Apellido = partes[1];
                        else
                            Apellido = string.Empty;
                    }

                    OnPropertyChanged(nameof(Nombre_completo));
                }
            }

        }
    }
}
