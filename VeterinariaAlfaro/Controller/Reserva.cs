using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace VeterinariaAlfaro.Controller
{
    public class Reserva
    {
        private int id;
        private string fecha_reserva;
        private string fecha_entrega;
        private Usuario usuario;
        private Mascota mascota;        
        private int cantidad;
        private double total;        
        private string estado;

        private Conexion conection;

        public Reserva(int _id = 0)
        {
            this.conection = new Conexion();
            if (_id != 0)
                buscarReservaId(_id);
        }

        public void buscarReservaId(int _id)
        {
            DataTable dt = this.conection.getQuery("SELECT id, fecha_reserva, fecha_entrega, id_usuario, id_mascota, cantidad, estado, total FROM treserva  WHERE id = " + _id);
            if (dt.Rows.Count > 0)
            {
                this.Id = _id;
                this.Fecha_reserva = dt.Rows[0].ItemArray[1].ToString();
                this.Fecha_entrega = dt.Rows[0].ItemArray[2].ToString();
                this.Usuario = new Usuario(Convert.ToInt16(dt.Rows[0].ItemArray[3].ToString()));
                this.Mascota = new Mascota(Convert.ToInt16(dt.Rows[0].ItemArray[4].ToString()));
                this.cantidad = Convert.ToInt16(dt.Rows[0].ItemArray[5].ToString());
                this.Estado = dt.Rows[0].ItemArray[6].ToString();
                this.Total = Convert.ToDouble(dt.Rows[0].ItemArray[7].ToString());
            }
            else
            {
                this.Id = -11243;
            }
        }

        
        public bool newReserva()
        {
            if (!conection.getNonQuery("INSERT INTO treserva (fecha_reserva,fecha_entrega,id_usuario,id_mascota,cantidad,estado, total) VALUES (" +
                "'" + this.Fecha_reserva + "' , '" + this.Fecha_entrega + "' , " + this.Usuario.Id + " , " + this.Mascota.Id + " , " + this.Cantidad + " , '" + this.Estado + "' , '" + Helpers.HelpTool.convertDouble(this.Total) + "' )"))
                return false;

            return true;
        }
        public bool delReserva()
        {
            return (conection.getNonQuery("DELETE FROM treserva WHERE id = " + this.Id));
        }
        
        public bool editReserva()
        {
            if (conection.getNonQuery("UPDATE treserva SET fecha_reserva = '" + this.Fecha_reserva + "' , " +
                        "fecha_entrega = '" + this.Fecha_entrega + "' , " +
                        "id_usuario = '" + this.Usuario.Id + "' , " +
                        "id_mascota = '" + this.Mascota.Id + "' , " +
                        "cantidad = '" + this.Cantidad + "' , " +
                        "total = '" + Helpers.HelpTool.convertDouble(this.Total) + "' , " +
                        "estado = '" + this.Estado + "' " +
                    "WHERE id = " + this.Id))
                buscarReservaId(this.Id);
            else
                return false;
            return true;
        }

        public bool cambiar_estado(string _estado)
        {
            this.Estado = _estado;
            int cant = this.Cantidad;
            if (conection.getNonQuery("UPDATE treserva SET " +
                        "estado = '" + this.Estado + "' " +
                    "WHERE id = " + this.Id))
            {
                buscarReservaId(this.Id);
                if (this.Estado.ToLower() == "cancelado")
                {
                    this.Mascota.aumentar_stock(cant);
                }                
            }
            else
                return false;
            return true;
        }

        public DataTable listaReserva(string patron = "", string order = "")
        {
            return this.conection.getQuery("SELECT id, fecha_reserva, fecha_entrega, id_usuario, id_mascota, cantidad, estado, total FROM treserva WHERE id like '%" + patron + "%' OR estado like '%" + patron + "%' OR fecha_reserva like '%" + patron + "%' OR fecha_entrega like '%" + patron + "%' " + order);
        }

        public DataTable listaReservaUser(int _id_user, string patron = "")
        {
            string query = "SELECT tr.id FROM treserva tr INNER JOIN tmascota tm ON tr.id_mascota = tm.id " +
                " JOIN tusuario tu ON tr.id_usuario = tu.id " +
                " WHERE id_usuario = " + _id_user + " " + patron + " ORDER BY estado DESC";
            return this.conection.getQuery(query);
        } 
        

        public string Estado
        {
            get { return estado; }
            set {
                estado =
                    value.ToLower().Equals("pendiente") ? value.ToLower() :
                    value.ToLower().Equals("cancelado") ? value.ToLower() :
                    value.ToLower().Equals("entregado") ? value.ToLower() : "pendiente";
            }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public Mascota Mascota
        {
            get { return mascota; }
            set { mascota = value; }
        }

        public string Fecha_entrega
        {
            get { return fecha_entrega; }
            set { fecha_entrega = value; }
        }

        public string Fecha_reserva
        {
            get { return fecha_reserva; }
            set { fecha_reserva = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public double Total
        {
            get { return total; }
            set { total = value; }
        }
    }
}