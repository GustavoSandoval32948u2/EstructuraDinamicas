namespace EstructurasDinamicas
{

    public class Nodo
    {
        public int Dato { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo Anterior { get; set; }

        public Nodo(int dato)
        {
            this.Dato = dato;
            this.Siguiente = null;
            this.Anterior = null;
        }
    }

    public class ListaDoble
    {
        private Nodo cabeza;
        private Nodo cola;
        private int tamaño;

        public ListaDoble()
        {
            this.cabeza = null;
            this.cola = null;
            this.tamaño = 0;
        }

        public static void Pausa()
        {
            Console.WriteLine("Presione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public void InsertarAlInicio(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza.Anterior = nuevoNodo;
                cabeza = nuevoNodo;
            }
            tamaño++;
            Console.WriteLine($"Elemento {dato} insertado al inicio");

            Pausa();
        }

        public void InsertarAlFinal(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = cola;
                cola = nuevoNodo;                                                                                                           
            }
            tamaño++;
            Console.WriteLine($"Elemento {dato} insertado al final");

            Pausa();
        }

        public void RecorrerAdelante()
        {
            if(cabeza == null)
            {
                Console.WriteLine("La lista está vacio");
                return;
            }

            Console.Write("Lista (adelante): ");
            Nodo actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Dato);
                if (actual.Siguiente != null)
                {
                    Console.Write("<>");
                }
                actual = actual.Siguiente;
            }
            Console.WriteLine();

            Pausa();
        }

        public void RecorrerAtras()
        {
            if (cola == null)
            {
                Console.WriteLine("La lista está vacía");
                return ;
            }

            Console.Write("Lista (atrás): ");
            Nodo actual = cola;
            while (actual != null)
            {
                Console.Write(actual.Dato);
                if (actual.Anterior != null)
                {
                    Console.Write("<>");
                }
                actual= actual.Anterior;
            }
            Console.WriteLine();

            Pausa();
        }

        public void MostrarTamaño()
        {
            Console.WriteLine($"Tamaño de la lista: {tamaño} elementos");
            Pausa();
        }

        public void MostrarSiEstaVacia()
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía");
            }
            else
            {
                Console.WriteLine($"La lista NO está vacía (tiene {tamaño} elementos)");
            }

            Pausa();
        }

        public void BuscarPorValor(int valor)
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacia");
                return;
            }

            Nodo actual = cabeza;
            int posicion = 0;
            bool encontrado = false;

            while (actual != null)
            {
                if(actual.Dato == valor)
                {
                    Console.WriteLine($"Elemento {valor} encontrado en el indice {posicion}");
                    encontrado = true;
                    break;
                }
                actual = actual.Siguiente;
                posicion++;
            }

            if(!encontrado)
            {
                Console.WriteLine($"Elemento {valor} no encontrado en la lista");
            }

            Pausa();
        }

        public void BuscarPorIndice(int indice)
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía");   
                return;
            }

            if(indice < 0 || indice >= tamaño)
            {
                Console.WriteLine($"Índice fuera de rango (0 - {tamaño - 1})");
                return;
            }

            Nodo actual = cabeza;
            int posicion = 0;

            while (actual != null)
            {
                if (posicion == indice)
                {
                    Console.WriteLine($"Elemento en índice {indice}: {actual.Dato}");
                    return ;
                }
                actual = actual.Siguiente;
                posicion++;
            }

            Pausa();
        }

        public void BorrarElemento(int valor)
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía");
                return ;
            }

            Nodo actual = cabeza;

            while (actual != null && actual.Dato != valor)
            {
                actual = actual.Siguiente;
            }

            if (actual == null)
            {
                Console.WriteLine($"Elemento {valor} no encontrado");
                return;
            }

            if (actual == cabeza)
            {
                cabeza = cabeza.Siguiente;
                if (cabeza != null)
                {
                    cabeza.Anterior = null;
                }
                else
                {
                    cola = null;
                }
            }

            else if (actual == cola)
            {
                cola = cola.Anterior;
                cola.Siguiente = null;
            }

            else
            {
                actual.Anterior.Siguiente = actual.Siguiente;
                actual.Siguiente.Anterior = actual.Anterior;
            }

            tamaño--;
            Console.WriteLine($"Elemento {valor} eliminado de la lista");

            Pausa();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaDoble lista = new ListaDoble();
            int opcion;

            do
            {
                Console.WriteLine("=== Lista Doblemente Enlazada - Menú ===");
                Console.WriteLine("1. Insertar al inicio");
                Console.WriteLine("2. Insertar al final");
                Console.WriteLine("3. Recorrer hacia adelante");
                Console.WriteLine("4. Recorrer hacia atrás");
                Console.WriteLine("5. Mostrar tamaño de la lista");
                Console.WriteLine("6. Mostrar si la lista está vacía");
                Console.WriteLine("7. Buscar elemento por valor");
                Console.WriteLine("8. Buscar elemento por índice");
                Console.WriteLine("9. Borrar un elemento");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingreso el valor a insertar al inicio: ");
                        int valorInicio = int.Parse(Console.ReadLine());
                        lista.InsertarAlInicio(valorInicio);
                        break;
                    case 2:
                        Console.Write("Ingreso el valor a insertar al inicio: ");
                        int valorFinal = int.Parse(Console.ReadLine());
                        lista.InsertarAlFinal(valorFinal);
                        break;
                    case 3:
                        lista.RecorrerAdelante();
                        break;
                    case 4:
                        lista.RecorrerAtras();
                        break;
                    case 5:
                        lista.MostrarTamaño();
                        break;
                    case 6:
                        lista.MostrarSiEstaVacia();
                        break;
                    case 7:
                        Console.Write("Ingrese el valor a buscar: ");
                        int valorBuscar = int.Parse(Console.ReadLine());
                        lista.BuscarPorValor(valorBuscar);
                        break;
                    case 8:
                        Console.Write("Ingrese el índice a buscar: ");
                        int indiceBuscar = int.Parse(Console.ReadLine());
                        lista.BuscarPorIndice(indiceBuscar);
                        break;
                    case 9:
                        Console.Write("Ingrese el valor a eliminar: ");
                        int valorEliminar = int.Parse(Console.ReadLine());
                        lista.BorrarElemento(valorEliminar);
                        break;
                    case 0:
                        Console.WriteLine("Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

            } while (opcion != 0);

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
