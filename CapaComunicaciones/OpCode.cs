

namespace CapaComunicaciones
{
    public enum OpCode
    {
        //Llamado Ping
        Ping = 0,

        //Autenticación / Sesión
        LoginCliente = 1,
        Desconectar = 0,


        //Artículos
        ObtenerArticulosActivos = 20,
        ObtenerArticuloPorId = 21,

        // Pedidos
        RegistrarPedido = 30,
        ConsultarMisPedidos = 31,
        ConsultarPedidoPorId = 32

    }
}
