using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsignacionMaterias.Clases
{
    public class Login
    {
        public bool Logearse(string usuario, string password)
        {
            bool logueado = false;
            do
            {
                logueado = true;
                Console.WriteLine("Bienvenido: " + Environment.UserName + " " + "admin " + " - " + "1234\n \n");
                Console.WriteLine("Ingrese el nombre de usuario");
                usuario = Console.ReadLine();

                Console.WriteLine("Ingrese el password!!!");
                password = Console.ReadLine();
                if (usuario != "admin" || password != "1234")
                {
                    Console.WriteLine("El usuario o la contrasena estan incorrectos");
                }
                Console.Clear();
            } while (usuario != "admin" || password != "1234");

            Console.Clear();
            Console.WriteLine("Bienvenido al sistema", usuario.ToUpper() + "\n");
            return logueado;
        }
    }
}
