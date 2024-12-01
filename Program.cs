namespace InventarioTienda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Producto> list = new List<Producto>();
            string opcion;

            do
            {
                opcion = menu();

                opcionesMenu(list, opcion);

            } while (!opcion.Equals("4"));

        }

        private static string menu()
        {
            string opcion;
            Console.WriteLine("\nEscribe la opción que necesitas(1,2,3,4)");
            Console.WriteLine("1.- Agregar nuevo producto.");
            Console.WriteLine("2.- Actualizar stock de un producto.");
            Console.WriteLine("3.- Consultar estado inventario.");
            Console.WriteLine("4.- Salir.\n");

            opcion = Console.ReadLine();
            return opcion;
        }

        private static void opcionesMenu(List<Producto> list, string opcion)
        {
            switch (opcion)
            {
                case "1":
                    string nombreProducto;
                    int stockProducto = 0;
                    decimal precioProducto = 0;

                    Console.WriteLine("Escribe el nombre del nuevo producto");
                    nombreProducto = Console.ReadLine();

                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Escribe la cantidad de stock del nuevo producto");
                            stockProducto = int.Parse(Console.ReadLine());
                            if (stockProducto <= 0)
                            {
                                throw new Exception("El stock debe ser mayor a 0.");
                            }
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }

                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Escribe el precio del nuevo producto");
                            precioProducto = Convert.ToDecimal(Console.ReadLine());
                            if (precioProducto <= 0)
                            {
                                throw new Exception("El precio debe ser mayor a 0.");
                            }
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }
                    if (!nombreProducto.Equals(null) && stockProducto > 0 && precioProducto > 0)
                    {

                        list.Add(new Producto(nombreProducto, stockProducto, precioProducto));
                    }
                    break;

                case "2":
                    string nombreComprobar;
                    int stockActualizar = 0;
                    int contador = 0;

                    Console.WriteLine("Escribe el nombre del producto que quieres actualizar");
                    nombreComprobar = Console.ReadLine();

                    foreach (Producto nombre in list)
                    {
                        contador++;
                        if (nombre.nombre.ToLower().Equals(nombreComprobar.ToLower()))
                        {

                            while (true)
                            {
                                try
                                {
                                    Console.WriteLine("Escribe el nuevo stock");
                                    stockActualizar = int.Parse(Console.ReadLine());
                                    if (stockActualizar <= 0)
                                    {
                                        throw new Exception("\nEl stock debe ser mayor a 0.");
                                    }
                                    break;
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                            }
                            nombre.stock = stockActualizar;
                            Console.WriteLine($"\nStock del producto {nombreComprobar} actualizado a {stockActualizar} unidades.");
                        }
                        else if (list.Count == contador)
                        {
                            Console.WriteLine("\nNo existe un producto con ese nombre.");
                        }
                    }
                    break;

                case "3":
                    Console.Clear();
                    if (list.Count > 0)
                    {
                        foreach (Producto p in list)
                        {
                            Console.WriteLine($"\nProducto {p.nombre}:");
                            Console.WriteLine($"Stock: {p.stock} unidades, Precio: {p.precio}E");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInventario vacio.");
                    }

                    break;

                case "4":
                    Console.WriteLine("\nPrograma cerrado.");
                    break;

                default:
                    Console.WriteLine("\nOpción no contemplada");
                    break;

            }
        }
    }

    internal class Producto
    {
        public string nombre { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }

        public Producto()
        {
        }

        public Producto(string nombre, int stock, decimal precio)
        {
            this.nombre = nombre;
            this.stock = stock;
            this.precio = precio;
        }

        public override string ToString()
        {
            return $"Nombre: {nombre}, Stock: {stock}, Precio {precio}E";
        }

    }
}
