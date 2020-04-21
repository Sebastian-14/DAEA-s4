using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DDetallePedido
    {
        public List<DetallePedido> GetDetallePedidos (DetallePedido detallePedido)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            List<DetallePedido> detallesPedidos = null;
            try
            {
                comandText = "USP_ListarDetalles";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@IdPedido", SqlDbType.Int);
                parameters[0].Value = detallePedido.IdProducto;
                detallesPedidos = new List<DetallePedido>();

                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, "USP_ListarDetalles", CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        detallesPedidos.Add(new DetallePedido
                        {
                            IdProducto = reader["IdProducto"] != null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            PrecioUnidad = reader["preciounidad"] != null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            Cantidad = reader["cantidad"] != null ? Convert.ToInt32(reader["cantidad"]) : 0,
                            Descuento = reader["descuento"] != null ? Convert.ToInt32(reader["descuento"]) : 0,
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return detallesPedidos;
        }
    }
}
