using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace VeterinariaAlfaro.Controller
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string apellido;
        private string telefono;
        private string email;
        private string tarjeta;
        private string codigoSeguridad;
        private string contrasena;
        private string tipo;
                
        private Conexion conection;

        public Usuario(int _id = 0)
        {
            this.conection = new Conexion();
            if (_id != 0)
                buscarUsuarioId(_id);
        }

        public void buscarUsuarioId(int _id)
        {
            DataTable dt = this.conection.getQuery("SELECT id, nombre, apellido, telefono, email, tarjeta, codigo_seguridad, contrasena, tipo  FROM tusuario WHERE id = " + _id);
            if (dt.Rows.Count > 0)
            {
                this.Id = _id;
                this.Nombre = dt.Rows[0].ItemArray[1].ToString();
                this.Apellido = dt.Rows[0].ItemArray[2].ToString();
                this.Telefono = dt.Rows[0].ItemArray[3].ToString();
                this.Email = dt.Rows[0].ItemArray[4].ToString();
                this.Tarjeta = dt.Rows[0].ItemArray[5].ToString();
                this.CodigoSeguridad = dt.Rows[0].ItemArray[6].ToString();
                this.Contrasena = dt.Rows[0].ItemArray[7].ToString();
                this.Tipo = dt.Rows[0].ItemArray[8].ToString();
            }
            else
            {
                this.Id = -11243;
            }
        }

        public bool login(string _email, string _contrasena)
        {
            DataTable dt = this.conection.getQuery("SELECT id, nombre, apellido, telefono, email, tarjeta, codigo_seguridad, contrasena, tipo FROM tusuario WHERE email = '" + _email + "' AND contrasena = '" + Helpers.HelpTool.md5(_contrasena) + "'");
            if (dt.Rows.Count > 0)
            {
                this.Id = Convert.ToInt16(dt.Rows[0].ItemArray[0].ToString());
                this.Nombre = dt.Rows[0].ItemArray[1].ToString();
                this.Apellido = dt.Rows[0].ItemArray[2].ToString();
                this.Telefono = dt.Rows[0].ItemArray[3].ToString();
                this.Email = dt.Rows[0].ItemArray[4].ToString();
                this.Tarjeta = dt.Rows[0].ItemArray[5].ToString();
                this.CodigoSeguridad = dt.Rows[0].ItemArray[6].ToString();
                this.Contrasena = dt.Rows[0].ItemArray[7].ToString();
                this.Tipo = dt.Rows[0].ItemArray[8].ToString();
            }
            else
            {
                return false;
            }
            return true;
        }


        public void buscarUsuarioEmail(string _email)
        {
            DataTable dt = this.conection.getQuery("SELECT id FROM tusuario WHERE email = '" + _email + "'");
            if (dt.Rows.Count > 0)
            {
                this.Id = Convert.ToInt16(dt.Rows[0].ItemArray[0].ToString());
                buscarUsuarioId(this.Id);
            }
            else
            {
                this.Id = -11243;
            }
        }

        public bool newUser()
        {
            if (conection.getNonQuery("INSERT INTO tusuario (nombre, apellido, email, telefono, tarjeta, codigo_seguridad, contrasena) VALUES ('" + this.Nombre + "' , '" + this.Apellido + "' , '" + this.Email + "' , '" + this.Telefono + "' , '" + this.Tarjeta + "' , '" + this.CodigoSeguridad + "' , '" + Helpers.HelpTool.md5(this.Contrasena) + "' )"))
                buscarUsuarioEmail(this.Email);
            else
                return false;

            return true;
        }
        public bool delUser()
        {
            return (conection.getNonQuery("DELETE FROM tusuario WHERE id = " + this.Id));
        }

        public bool editUser()
        {
            if (conection.getNonQuery("UPDATE tusuario SET nombre = '" + this.Nombre + "' , " +
                        "apellido = '" + this.Apellido + "' , " +
                        "telefono = '" + this.Telefono + "' , " +
                        "email = '" + this.Email + "' , " +
                        "tarjeta = '" + this.Tarjeta + "' , " +
                        "codigo_seguridad = '" + this.CodigoSeguridad + "' , " +
                        "tipo = '" + this.Tipo + "' " + 
                    "WHERE id = " + this.Id))
                buscarUsuarioId(this.Id);
            else
                return false;
            return true;    
        }
        
        public DataTable listaUsuarios(string patron = "", bool ddl = false)
        {
            if (ddl)
                return this.conection.getQuery("SELECT id, nombre + ' ' + apellido as nombres FROM tusuario");
            return this.conection.getQuery("SELECT id, nombre, apellido, telefono, email, tarjeta, codigo_seguridad, contrasena, tipo FROM tusuario WHERE id like '%" + patron + "%' OR apellido like '%" + patron + "%'");
        }
        
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public string CodigoSeguridad
        {
            get { return codigoSeguridad; }
            set { codigoSeguridad = value; }
        }

        public string Tarjeta
        {
            get { return tarjeta; }
            set { tarjeta = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    }
}