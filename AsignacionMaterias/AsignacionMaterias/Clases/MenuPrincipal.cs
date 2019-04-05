using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionMaterias.Clases;
using AsignacionMaterias.Dto;

namespace AsignacionMaterias.Clases
{
    public class MenuPrincipal
    {
        private static List<ProfesoresDto> profesorList = new List<ProfesoresDto>();
        private static List<MateriasDto> MateriaList = new List<MateriasDto>();
        Login login = new Login(); //Aqui esta el metodo para loguearse, espera un usuario y password. 
        string usuario, password; //Variables para logeo
        public void Menu()
        {
            //Variables incrementables
            int IdProfesor = 0;
            int IdMateria = 0;

            Console.WriteLine("Login");
            login.Logearse(usuario, password);//Login

            //Menu Principal
            Console.WriteLine("1- Profesor \n" +
                              "2)- Materias \n" +
                              "3)- Asignacion \n" +
                              "4)- Salir \n");
            Console.Write("Opcion: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            //if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out opcion))
            //{
                switch (opcion)
                {
                    case 1:
                        AgregarNuevoProfesor:

                        Console.WriteLine("1- Ingresar\n 2- Eliminar\n 3- Volver al Menu Principal");

                        if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out opcion))
                        {
                            switch (opcion)
                            {
                                case 1:
                                    NuevoProfesor:
                                    Console.Clear();

                                    IdProfesor++; //Incrementando id del profesor...
                                    //Agregar usuario
                                    ProfesoresDto profe = new ProfesoresDto();
                                    profe.Id = IdProfesor;//Igualamos el id Al autoincrementable...

                                    Console.Write("Nombre: ");
                                    profe.nombre = Console.ReadLine();

                                    Console.Write("Apellido: ");
                                    profe.apellido = Console.ReadLine();

                                    Console.Write("Telefono: ");
                                    profe.telefono = Console.ReadLine();

                                    Console.Write("Direccion: ");
                                    profe.direccion = Console.ReadLine();
                                    profesorList.Add(profe);
                                    //End Agregar Usuario
                                    Console.Clear();
                                    Console.WriteLine("\n El profesor ha sido agregado correctamente");

                                    //Mostrando el profesor registrado.....
                                    Console.WriteLine("Id: " + profe.Id +
                                                                    "\n Nombre: " + profe.nombre +
                                                                    "\n Apellido: " + profe.apellido +
                                                                    "\n Telefono: " + profe.telefono +
                                                                    "\n Direccion: " + profe.direccion);

                                    //Preguntar si se desea agregar otro registro...
                                    Console.WriteLine("\nDesea insertar otro profesor? Si(y) o No(n)");
                                    string n = Console.ReadLine();
                                    if (n.ToLower() == "n")
                                    {
                                        Console.Clear();
                                        goto AgregarNuevoProfesor;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto NuevoProfesor;
                                    }

                                case 2:
                                    labelEliminar:
                                    try
                                    {
                                        if (profesorList.Count() != 0)
                                        {
                                            Console.Clear();
                                            //variable de control para eliminar el usuario
                                            int Iddelete;
                                            Console.Write("Digite el Id de el profesor a eliminar: ");
                                            Iddelete = int.Parse(Console.ReadLine());
                                            //eliminamos un numero ya que es por posicion que estamos eliminando, asi no esta fuera de rango.
                                            Iddelete -= 1;

                                            Console.Clear();
                                            Console.WriteLine("Datos a eliminar\n");
                                            Console.WriteLine("Id: " + profesorList[Iddelete].Id +
                                                                              "\nNombre: " + profesorList[Iddelete].nombre +
                                                                              "\nApellido: " + profesorList[Iddelete].apellido +
                                                                              "\nTelefono: " + profesorList[Iddelete].telefono +
                                                                              "\nDireccion: " + profesorList[Iddelete].direccion + "\n\n");
                                           
                                            Console.WriteLine("\nDesea eliminar este Profesor Si(y) o No(n)?");
                                            string si = Console.ReadLine();
                                            if (si.ToLower() == "y")
                                            {
                                                profesorList.RemoveAt(Iddelete);
                                                Console.Clear();
                                                Console.WriteLine("El profesor ha sido eliminado! \n");
                                                goto NuevoProfesor;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                goto AgregarNuevoProfesor;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Debe tener al menos un profesor agregado! \n");
                                            goto AgregarNuevoProfesor;
                                        }
                                    }
                                    
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Error" + ex.Message);
                                        throw;
                                    }
                                    //break;
                                default:
                                    Console.WriteLine("Esta opcion no existe");
                                    break;
                            }
                           
                        }
                        break;
                    default:
                        break;
                //}
            }
        }
        
    }
}
