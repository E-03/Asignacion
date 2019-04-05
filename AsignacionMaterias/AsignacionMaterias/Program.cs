using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsignacionMaterias.Clases;
using AsignacionMaterias.Dto;

namespace AsignacionMaterias
{
    public class Program
    {
        private static List<ProfesoresDto> profesorList = new List<ProfesoresDto>();
        private static List<MateriasDto> MateriaList = new List<MateriasDto>();
        public static string usuario, password; //Variables para logeo

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            //Variables incrementables
            int IdProfesor = 0;
            int IdMateria = 0;

            Login login = new Login(); //Aqui esta el metodo para loguearse, espera un usuario y password. 
            login.Logearse(usuario, password);
            
            Pmenu:
            //Menu Principal
            Console.WriteLine("1- Profesor \n" +
                              "2)- Materias \n" +
                              "3)- Asignacion \n" +
                              "4)- Salir");
            int opcion = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (opcion > 0)
            {
                switch (opcion)
                {

                    case 1:
                        AgregarNuevoProfesor:

                        Console.WriteLine("1- Ingresar\n 2- Eliminar\n 3- Volver al Menu Principal");
                        opcion = Convert.ToInt32(Console.ReadLine());
                        switch (opcion)
                        {
                            case 1:
                                NuevoProfesor:
                                Console.Clear();

                                IdProfesor++; //Incrementando id del profesor...
                                //Agregar usuario
                                ProfesoresDto profe = new ProfesoresDto();
                                Console.WriteLine("Profesores: \n");
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
                                    goto Pmenu;
                                }
                                else
                                {
                                    Console.Clear();
                                    goto NuevoProfesor;
                                }
                            case 2:
                                EliminarOtroProfesor:
                                try
                                {
                                    if (profesorList.Count() != 0)
                                    {
                                        Console.Clear();
                                        //variable de control para eliminar el usuario
                                        int Iddelete;
                                        foreach (var item in profesorList)
                                        {
                                            Console.WriteLine("Id: " + item.Id +
                                                            "\nNombre: " + item.nombre +
                                                            "\nApellido: " + item.apellido +
                                                            "\nTelefono: " + item.telefono +
                                                            "\nDireccion: " + item.direccion + "\n\n");
                                        }
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
                                            Console.WriteLine("El profesor ha sido eliminado! \n\n");

                                            Console.WriteLine("Desea eliminar otro profesor?");
                                            string QuiereEliminarOtro = Console.ReadLine();
                                            if (QuiereEliminarOtro == "y")
                                            {
                                                Console.Clear();
                                                goto EliminarOtroProfesor;
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
                                }
                                break;
                            case 3:
                                Console.Clear();
                                goto Pmenu; //Menu principal
                            case 4:
                                return;
                        }
                        break;
                    case 2:
                        try
                        {
                            CrudMenu:
                            Console.WriteLine("1- Igresar\n 2- Eliminar\n 3- Menu Principal");
                            opcion = Convert.ToInt32(Console.ReadLine());
                            switch (opcion)
                            {
                                case 1://Insertar Materia
                                    InsertarOtraMateria: //m
                                    Console.Clear();

                                    //auto-incremento del ID
                                    IdMateria++;
                                    Console.WriteLine("Materia\n");

                                    //Creamos un objeto de la clase materia para agregarlos a la lista
                                    MateriasDto materia = new MateriasDto();
                                    materia.id = IdMateria;
                                    Console.Write("Nombre: ");
                                    materia.materia = Console.ReadLine();
                                    Console.Write("Hora de Inicio: ");
                                    materia.horaInicio = Console.ReadLine();
                                    Console.Write("Hora de Finalizacin: ");
                                    materia.horaFinal = Console.ReadLine();

                                    //Agregamos registro a la lista
                                    MateriaList.Add(materia);

                                    Console.Clear();
                                    //Mostramos un aviso de que se ha agregado un registro y mostramos los datos agregados
                                    Console.WriteLine("Registro insertado.\n");
                                    Console.WriteLine("Id: " + materia.id +
                                                    "\nMateria: " + materia.materia +
                                                    "\nHora Inicio: " + materia.horaInicio +
                                                    "\nHora Fin: " + materia.horaFinal);

                                    //mostramos mensaje de ingresar un new usuario
                                    Console.WriteLine("\nDesea ingresar otra materia Si(y) o No(n)");
                                    string n = Console.ReadLine();
                                    if (n.ToLower() == "n")
                                    {
                                        Console.Clear();
                                        goto Pmenu;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        goto InsertarOtraMateria;
                                    }

                                case 2://Eliminar Matera
                                    EliminarOtra: //R:
                                    try
                                    {
                                        if (MateriaList.Count() != 0)
                                        {
                                            Console.Clear();
                                            //variable de control para eliminar la materia
                                            int contador;
                                            foreach (var item in MateriaList)
                                            {
                                                Console.WriteLine("Listado de materias agregadas \n");
                                                Console.WriteLine("Id: " + item.id +
                                                            "\nNombre: " + item.materia +
                                                            "\nHora Inicio: " + item.horaInicio +
                                                            "\nHora Fin: " + item.horaFinal + "\n\n");
                                            }
                                            Console.Write("Ingrese el Id de la materia a eliminar: ");
                                            contador = int.Parse(Console.ReadLine());
                                            //eliminamos un numero ya que es por posicion que estamos eliminando, asi no esta fuera de rango.
                                            contador -= 1;
                                            //Mostramos los datos a eliminar
                                            Console.Clear();
                                            Console.WriteLine("Datos a eliminar\n");
                                            Console.WriteLine("Id: " + MateriaList[contador].id +
                                                            "\nNombre: " + MateriaList[contador].materia +
                                                            "\nHora de inicio: " + MateriaList[contador].horaInicio +
                                                            "\nHora de finalizacion: " + MateriaList[contador].horaFinal);

                                            //Eliminar Si o No
                                            Console.WriteLine("\nDesea eliminar este registro Si(y) o No(n)?");
                                            string si = Console.ReadLine();
                                            if (si.ToLower() == "y")
                                            {  
                                                MateriaList.RemoveAt(contador);//Aqui removemos la materia
                                                Console.Clear();
                                                Console.WriteLine("Se ha eliminado la materia satisfactoriamente..!\n");

                                                Console.WriteLine("Desea eliminar otra materia?");
                                                string QuiereEliminar = Console.ReadLine();
                                                if (QuiereEliminar == "y")
                                                {
                                                    goto EliminarOtra;
                                                }
                                                else { 
                                                    goto CrudMenu;//Menu principal
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                goto CrudMenu;
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Debe registrar al menos una materia para poder asignarla!..\n");
                                            goto CrudMenu;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Error de sistema,verifique. \n\n" + ex.Message);
                                    }
                                    break;
                                case 3:
                                    goto Pmenu; //Menu principal
                                    
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error de sistema,verifique. \n\n" + ex.Message);
                        }
                        break;
                    case 3: //Asignar Materias
                        if (profesorList.Count() != 0 && profesorList.Count() != 0)
                        {
                            AsignarOtraMateria:
                            int i;
                            Console.Clear();
                            //mostramos los profesores Registrados
                            Console.WriteLine("Asignacion de Materias\n\nProfesores Registrados\n");
                            //foreach (var item in profesorList)
                            //{
                            //    Console.WriteLine(
                            //        "Id: " + item.Id +
                            //        "Profesor: " + item.nombre
                            //    );
                            //}
                            for (i = 0; i < profesorList.Count(); i++)
                            {
                                Console.WriteLine("Id: " + profesorList[i].Id +
                                                "\nNombre: " + profesorList[i].nombre + "\n");
                            }

                            try
                            {//capturamos un error en Try Catch ej: un string
                                Console.Write("\nIngrese el ID del profesor para asignar una Materia :");
                                int pro = int.Parse(Console.ReadLine());
                                pro -= 1;
                                //si el numero ingresado (ID) no existe le mostramos un mensaje
                                if (pro > i)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Debe ingresar un ID existente");
                                    goto AsignarOtraMateria;
                                }
                                else
                                {

                                    // int j;
                                    Console.Clear();
                                    ma:
                                    //Mostramos el Profesor seleccionado
                                    Console.WriteLine("Asignar una Materia para el Profesor " + profesorList[pro].nombre + "\n");
                                    //mostramos las Materias Registradas

                                    for (i = 0; i < MateriaList.Count(); i++)
                                    {
                                        Console.WriteLine("ID: " + MateriaList[i].id +
                                            "\nNombre: " + MateriaList[i].materia + "\n");
                                    }
                                    //foreach (var item in MateriaList)
                                    //{
                                    //    Console.WriteLine("ID: " + item.id +
                                    //                    "\nNombre: " + item.materia + "\n");
                                    //}
                                    try
                                    {

                                        Console.Write("\nIngrese el ID de la Materia que desea asignar :");
                                        int materia = int.Parse(Console.ReadLine());
                                        materia -= 1;
                                        //si el numero ingresado (ID) no existe le mostramos un mensaje
                                        if (materia > i)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Debe ingresar un ID existente\n");
                                            goto ma;
                                        }
                                        else
                                        {//mostramos la materia asignada a dicho profesor
                                            Console.Clear();
                                            Console.WriteLine("Materia asignada..!!\n");
                                            Console.WriteLine("Profesor: " + profesorList[pro].nombre +
                                                              "\nMateria: " + MateriaList[materia].materia +
                                                              "\nHora de inicio: " + MateriaList[materia].horaInicio +
                                                              "\nHora de finalizacion: " + MateriaList[materia].horaFinal);
                                            //eliminamos el prfesor ya que tiene su materia asignada
                                            profesorList.RemoveAt(pro);
                                            //si desea asignar otro profesor 
                                            Console.WriteLine("\nDesea asignar materia a otro Profesor Si(y) No(n), Presione el *4* si desea salir del programa.");
                                            string s = Console.ReadLine();
                                            if (s.ToLower() == "y")
                                            {
                                                Console.Clear();
                                                goto AsignarOtraMateria;
                                            }
                                            else if (s.ToLower() == "4")
                                            {
                                                return;
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                goto Pmenu;
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Debe insertar un numero \n\n");
                                        goto ma;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                Console.WriteLine("Debe insertar un numero \n\n");
                                goto AsignarOtraMateria;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Aun no has registrado Materias ni Profesores..\n");
                            goto Pmenu;
                        }
                    //goto Pmenu;
                    //break;
                    default:
                        Console.WriteLine("Esta opcion no existe");
                        break;
                }
            }
        }
    }
}
