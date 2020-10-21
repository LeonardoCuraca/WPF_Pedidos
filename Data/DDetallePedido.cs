using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DDetallePedido
    {
        SqlParameter[] parameters = null;
        string commandText = string.Empty;
        List<DetallePedido> detallepedidos;
        public List<DetallePedido> GetDetallePedidos (int idPedido)
        {
            try
            {
                commandText = "USP_DETALLE";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idPedido", SqlDbType.Int);
                parameters[0].Value = idPedido;
                detallepedidos = new List<DetallePedido>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, "USP_DETALLE", CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        detallepedidos.Add(new DetallePedido
                        {
                            Pedido = Convert.ToInt32(reader["idpedido"]),
                            IdProducto = Convert.ToInt32(reader["idproducto"]),
                            Cantidad = Convert.ToInt32(reader["cantidad"]),
                            PrecioUnidad = Convert.ToDecimal(reader["preciounidad"]),
                            Descuento = Convert.ToDecimal(reader["descuento"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return detallepedidos;
        }
    }
}
