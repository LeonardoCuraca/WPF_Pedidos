using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DPedido
    {
        public List<Pedido> GetPedidos(Pedido pedido)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<Pedido> pedidos = null;

            try
            {
                commandText = "USP_FECHAFECHA";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@Fec1", SqlDbType.DateTime);
                parameters[0].Value = pedido.FechaInicio;
                parameters[1] = new SqlParameter("@Fec2", SqlDbType.DateTime);
                parameters[1].Value = pedido.FechaFin;
                pedidos = new List<Pedido>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, "USP_FECHAFECHA", CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        pedidos.Add(new Pedido
                        {
                            IdPedido = Convert.ToInt32(reader["IdPedido"]),
                            IdCliente = Convert.ToString(reader["IdCliente"]),
                            IdEmpleado = Convert.ToInt32(reader["IdEmpleado"]),
                            FechaPedido = Convert.ToDateTime(reader["FechaPedido"]),
                            FechaEntrega = Convert.ToDateTime(reader["FechaEntrega"]),
                            FechaEnvio = Convert.ToDateTime(reader["FechaEnvio"]),
                            FormaEnvio = Convert.ToInt32(reader["FormaEnvio"]),
                            Cargo = Convert.ToInt32(reader["Cargo"]),
                            Destinatario = Convert.ToString(reader["Destinatario"]),
                            DireccionDestinatario = Convert.ToString(reader["CiudadDestinatario"]),
                            RegionDestinatario = Convert.ToString(reader["RegionDestinatario"]),
                            CodPostalDestinatario = Convert.ToString(reader["CodPostalDestinatario"]),
                            PaisDestinatario = Convert.ToString(reader["PaisDestinatario"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pedidos;
        }
    }
}
