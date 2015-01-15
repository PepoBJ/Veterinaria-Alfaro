using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaAlfaro.Controller
{
    public class Reserva
    {
        private int id;
        private string fecha_reserva;
        private string fecha_entrega;
        private Usuario usuario;
        private Mascota Mascota;
        private int cantidad;

        private Conexion conexion;

        /*public Mascota(int _id = 0)
        {
            this.conection = new Conexion();
            if (_id != 0)
                buscarMascotaId(_id);
        }

        public void buscarMascotaId(int _id)
        {
            DataTable dt = this.conection.getQuery("SELECT id, raza, stock, precio,descripcion,foto,pelo,color,cola,tamanyo_raza,type FROM tmascota WHERE id = " + _id);
            if (dt.Rows.Count > 0)
            {
                this.Id = _id;
                this.Raza = dt.Rows[0].ItemArray[1].ToString();
                this.Stock = Convert.ToInt16(dt.Rows[0].ItemArray[2].ToString());
                this.Precio = Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString());
                this.Descripcion = dt.Rows[0].ItemArray[4].ToString();
                this.Foto = dt.Rows[0].ItemArray[5].ToString();
                this.Pelo = dt.Rows[0].ItemArray[6].ToString();
                this.Color = dt.Rows[0].ItemArray[7].ToString();
                this.Cola = dt.Rows[0].ItemArray[8].ToString();
                this.Tamanyo = Convert.ToInt16(dt.Rows[0].ItemArray[9].ToString());
                this.Type = dt.Rows[0].ItemArray[10].ToString();
            }
            else
            {
                this.Id = -11243;
            }
        }

        public bool newMascota()
        {
            if (!conection.getNonQuery("INSERT INTO tmascota (raza,stock,precio,descripcion,pelo,color,cola,tamanyo_raza,type) VALUES (" +
                "'" + this.Raza + "' , " + this.Stock + " , " + Helpers.HelpTool.convertDouble(this.Precio) + " , '" + this.Descripcion + "' , '" + this.Pelo + "' , '" + this.Color + "' , '" + this.Cola + "' , " + this.Tamanyo + " , '" + this.Type + "' )"))
                return false;

            return true;
        }
        public bool delMascota()
        {
            return (conection.getNonQuery("DELETE FROM tmascota WHERE id = " + this.Id));
        }

        public bool editMascota()
        {
            if (conection.getNonQuery("UPDATE tmascota SET raza = '" + this.Raza + "' , " +
                        "stock = '" + this.Stock + "' , " +
                        "precio = '" + Helpers.HelpTool.convertDouble(this.Precio) + "' , " +
                        "descripcion = '" + this.Descripcion + "' , " +
                        "pelo = '" + this.Pelo + "' , " +
                        "color = '" + this.Color + "' , " +
                        "cola = '" + this.Cola + "' , " +
                        "tamanyo_raza = '" + this.Tamanyo + "' , " +
                        "type = '" + this.Type + "' " +
                    "WHERE id = " + this.Id))
                buscarMascotaId(this.Id);
            else
                return false;
            return true;
        }

        public DataTable listaMascota(string patron = "", string order = "")
        {
            return this.conection.getQuery("SELECT id, raza,stock,precio,descripcion, foto, pelo, color,cola,tamanyo_raza,type FROM tmascota WHERE id like '%" + patron + "%' OR raza like '%" + patron + "%' OR type like '%" + patron + "%' " + order);
        }  
        */


        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public Mascota Mascota1
        {
            get { return Mascota; }
            set { Mascota = value; }
        }

        public Usuario Usuario
        {
            get { return usuario; }
            set { usuario = value; }
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
    }
}