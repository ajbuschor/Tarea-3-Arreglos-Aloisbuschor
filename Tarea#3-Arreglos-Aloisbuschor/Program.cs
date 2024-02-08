using System;
using System.Collections;

class Program //creando una clase
{
    static void Main() //clase principal creando un arraylist para que sea guardad la informacion dada
    {
        ArrayList cedulas = new ArrayList();
        ArrayList nombres = new ArrayList();
        ArrayList tiposEmpleado = new ArrayList();
        ArrayList horasLaboradas = new ArrayList();
        ArrayList preciosPorHora = new ArrayList();
        ArrayList aumentos = new ArrayList();
        ArrayList salariosBrutos = new ArrayList();
        ArrayList deduccionesCCSS = new ArrayList();
        ArrayList salariosNetos = new ArrayList();

        do //utilizando un ciclo do while para que se repita los datos del usuario si es deseado ingresar datos de otro empleado
        {
            Console.WriteLine("\nIngrese datos del empleado");
            Console.Write("numero de cedula: ");
            string cedula = Console.ReadLine();
            cedulas.Add(cedula);

            Console.Write("nombre del empleado: ");
            string nombre = Console.ReadLine();
            nombres.Add(nombre);

            Console.Write("tipo de empleado (1-Operario, 2-Tecnico, 3-Profesional) : ");
            int tipoEmpleado;
            while (!int.TryParse(Console.ReadLine(), out tipoEmpleado) || tipoEmpleado < 1 || tipoEmpleado > 3)
            {
                Console.Write("por favor ingrese un numero valido entre 1 y 3: ");
            }
            tiposEmpleado.Add(tipoEmpleado);

            Console.Write("cantidad de horas de trabajo : ");
            double horas;
            while (!double.TryParse(Console.ReadLine(), out horas) || horas < 0)
            {
                Console.Write("por favor ingrese un numero valido mayor o igual a cero: ");
            }
            horasLaboradas.Add(horas);

            Console.Write("precio por hora : ");
            double precioHora;
            while (!double.TryParse(Console.ReadLine(), out precioHora) || precioHora < 0)
            {
                Console.Write("por favor ingrese un numero valido mayor o igual a cero: ");
            }
            preciosPorHora.Add(precioHora);

            double salarioOrdinario = horas * precioHora; // calcular salario ordinario
            double aumento = 0.0;
            if (tipoEmpleado == 1) // calcular aumento utiilizando el if con el porcentaje del aumento
            {
                aumento = salarioOrdinario * 0.15;
            }
            else if (tipoEmpleado == 2)
            {
                aumento = salarioOrdinario * 0.10;
            }
            else if (tipoEmpleado == 3)
            {
                aumento = salarioOrdinario * 0.05;
            }
            aumentos.Add(aumento);

            double salarioBruto = salarioOrdinario + aumento;
            salariosBrutos.Add(salarioBruto);

            double deduccionCCSS = salarioBruto * 0.0917; //el salario y el aumento * la deduccion de la ccss
            deduccionesCCSS.Add(deduccionCCSS);

            double salarioNeto = salarioBruto - deduccionCCSS;  // calcular salario bruto - la deduccion de la CCSS y salario neto
            salariosNetos.Add(salarioNeto);

            Console.WriteLine("\nResultados para el empleado:"); // muestra de  resultados para cada transaccion cual es guardada en el arraylist
            Console.WriteLine($"Cedula: {cedula}");
            Console.WriteLine($"Nombre empleado: {nombre}");
            Console.WriteLine($"Tipo empleado: {tipoEmpleado}");
            Console.WriteLine($"Salario por hora: {precioHora}");
            Console.WriteLine($"Cantidad de horas: {horas}");
            Console.WriteLine($"Salario ordinario: {salarioOrdinario}");
            Console.WriteLine($"Aumento: {aumento}");
            Console.WriteLine($"Salario bruto: {salarioBruto}");
            Console.WriteLine($"Deduccion CCSS: {deduccionCCSS}");
            Console.WriteLine($"Salario neto: {salarioNeto}");

            Console.Write("\n¿ Desea ingresar otro empleado ? (Sí/No): "); // preguntar al usuario si desea ingresar otros empleados volviendo a ejecutar el ciclo
        } while (Console.ReadLine().Equals("Si", StringComparison.OrdinalIgnoreCase));

        // Muestra de estadisticas al terminar si el usuario no decidio ingresar otro empleado
        Console.WriteLine("\nEstadisticas finales ");
        MostrarEstadisticas("Operarios", tiposEmpleado, aumentos, salariosNetos);
        MostrarEstadisticas("Tecnicos", tiposEmpleado, aumentos, salariosNetos);
        MostrarEstadisticas("Profesionales", tiposEmpleado, aumentos, salariosNetos);

        Console.WriteLine("\nPrograma ejecutado.");
    }

    static void MostrarEstadisticas(string tipoEmpleado, ArrayList tipos, ArrayList aumentos, ArrayList salariosNetos)
    {
        int cantidad = 0;
        double acumuladoNeto = 0;

        for (int i = 0; i < tipos.Count; i++)
        {
            if ((int)tipos[i] == (tipoEmpleado == "Operarios" ? 1 : tipoEmpleado == "Tecnicos" ? 2 : 3))
            {
                cantidad++;
                acumuladoNeto += (double)salariosNetos[i];
            }
        }

        Console.WriteLine($"\nCantidad empleados tipo {tipoEmpleado}: {cantidad}");          // muestra de estadisticas al terminar igual con la informacion dada en los arrays
        Console.WriteLine($"Acumulado salario neto para {tipoEmpleado}: {acumuladoNeto}");
        Console.WriteLine($"Promedio salario neto para {tipoEmpleado}: {(cantidad > 0 ? acumuladoNeto / cantidad : 0)}");
    }
}

