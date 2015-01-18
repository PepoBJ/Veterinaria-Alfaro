using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace VeterinariaAlfaro.Controller
{
    public class Mascota
    {
        public static string DIR = "/media/img-mascota/";
        private int id;
        private string raza;
        private int stock;
        private double precio;
        private string descripcion;
        private string foto;
        private string pelo;
        private string color;
        private string cola;
        private int tamanyo;
        private string type;

        private Conexion conection;

        public Mascota(int _id = 0)
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

        private int ult_id()
        {
            string sql = "select MAX(id) from tmascota";
            DataTable dt = this.conection.getQuery(sql);
            return Convert.ToInt16(dt.Rows[0].ItemArray[0].ToString());
        }

        public bool newMascota()
        {
            if (conection.getNonQuery("INSERT INTO tmascota (raza,stock,precio,descripcion,pelo,color,cola,tamanyo_raza,type) VALUES (" +
                "'" + this.Raza + "' , " + this.Stock + " , '" + Helpers.HelpTool.convertDouble(this.Precio) + "' , '" + this.Descripcion + "' , '" + this.Pelo + "' , '" + this.Color + "' , '" + this.Cola + "' , " + this.Tamanyo + " , '" + this.Type + "' )"))
            {
                this.Id = ult_id();
                return true;
            }

            return true;
        }
        public bool delMascota()
        {
            return (conection.getNonQuery("DELETE FROM tmascota WHERE id = " + this.Id));
        }
        public bool aumentar_stock(int _cant)
        {
            this.stock = _cant;
            if (conection.getNonQuery("UPDATE tmascota SET " +
                        "stock = stock + " + this.Stock + 
                    "WHERE id = " + this.Id))
                buscarMascotaId(this.Id);
            else
                return false;
            return true;
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

        public DataTable listaMascota(string patron = "", string order = "", bool ddl = false)
        {
            if(ddl)
                return this.conection.getQuery("SELECT id, type + ' ' + raza as mascota FROM tmascota ORDER BY type" );
            return this.conection.getQuery("SELECT id, raza,stock,precio,descripcion, foto, pelo, color,cola,tamanyo_raza,type FROM tmascota WHERE id like '%" + patron + "%' OR raza like '%" + patron + "%' OR type like '%" + patron + "%' " + order);
        }       
        
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Tamanyo
        {
            get { return tamanyo; }
            set { tamanyo = value; }
        }

        public string Cola
        {
            get { return cola; }
            set { cola = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Pelo
        {
            get { return pelo; }
            set { pelo = value; }
        }

        public string Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        public string Raza
        {
            get { return raza; }
            set { raza = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}