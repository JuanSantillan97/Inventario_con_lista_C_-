using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_Inventario
{
    class Inventario
    {
        private Producto inicio;

        public Inventario()
        {
            inicio = null;
        }

        /// <summary>
        /// Verifica que el código no se repita y el limite del vector.
        /// </summary>
        /// <param name="producto"></param>
        public void agregarProducto(Producto productoNew)
        {
            bool sePuedeAgregar = true;

            if (inicio == null)//En caso de no tener ningun producto, agrega al primer producto en inicio.
            {
                inicio = productoNew;
            }
            else//busca el último nodo con un siguiente en null para poder agregar y busca que el código no este repetido.
            {
                Producto temp = inicio;
                while (temp.siguiente != null && sePuedeAgregar == true)
                {
                    if (temp.codigo == productoNew.codigo)//condición para saber si esta repetido o no.
                    {
                        sePuedeAgregar = false;
                    }
                    temp = temp.siguiente;
                }
                if (sePuedeAgregar == true && temp.codigo != productoNew.codigo)
                {
                    temp.siguiente = productoNew;
                }
            }
        }

        /// <summary>
        /// Elimina el producto con el código ingresado y recorre a los demas productos, después borra el último.
        /// </summary>
        /// <param name="codigo"></param>
        public void eliminarProducto(int codigo)
        {
            Producto temp = inicio;
            if (temp != null)//Verifica que exista al menos un producto.
            {
                if (temp.codigo == codigo)//Elimina en caso de ser el primero.
                {
                    inicio = temp.siguiente;
                    temp = inicio;
                }
                else//Busca eliminar a partir del segundo nodo.
                {
                    while (temp.siguiente != null && temp.siguiente.codigo != codigo)//verifica que exista temp.siguiente y que su código sea diferente.
                    {
                        temp = temp.siguiente;
                    }
                    if (temp.siguiente != null)//]En caso de no encontrar dicho valor devolvera un null, es por eso que vuelve a verificar si regreso un valor.
                    {
                        temp.siguiente = temp.siguiente.siguiente;
                    }
                }
            }
        }

        /// <summary>
        /// Busca un producto mediante su código, en caso de no encontrar el producto regresa null.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public Producto buscarProducto(int codigo)
        {
            Producto temp = inicio;

            while (temp != null && temp.codigo != codigo)//Buscara si temp existe y si su código es igual al que se busca.
            {
                temp = temp.siguiente;
            }//Al terminar el ciclo si encontro el valor deseado, temp es el producto a regresar,
            //en caso de no serlo, temp valdra null, entonces regresaremos null.
            return temp;
        }

        /// <summary>
        /// Inserta un producto en una posición asignada por el usuario entre 1 y 15.
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="posicion"></param>
        public void insertarProducto(Producto productoNew, int posicion)//posicion de 1 a 15.
        {
            Producto temp = inicio;
            int contador = 2;
            bool sePuedeAgregar = true;
            
            while (temp != null && sePuedeAgregar == true)
            {
                if(temp.codigo == productoNew.codigo)
                {
                    sePuedeAgregar = false;
                }
                temp = temp.siguiente;
            }

            if(sePuedeAgregar == true)
            {
                temp = inicio;

                if (posicion == 1)
                {
                    productoNew.siguiente = temp;
                    inicio = productoNew;
                }
                else
                {
                    while (temp.siguiente != null && contador != posicion)
                    {
                        contador++;
                        temp = temp.siguiente;
                    }
                    productoNew.siguiente = temp.siguiente;
                    temp.siguiente = productoNew;
                }
            }
        }
        
        /// <summary>
        /// Muestra todos los productos en el vector.
        /// </summary>
        /// <returns></returns>
        public string reporteDeProductos()
        {
            string cadena = "";
            Producto temp = inicio;

            while (temp != null)
            {
                cadena += temp.ToString();
                temp = temp.siguiente;
            }

            return cadena;
        }
    }
}
