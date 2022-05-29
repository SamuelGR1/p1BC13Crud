using p1BC13Crud.Clases;
using p1BC13Crud.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1BC13Crud.Servicios
{
    public class ServicioAlumno
    {

        public void lee()
        {
            ClsConexion cone = new();
            DataTable resp = cone.consultaTablaDirecta("select * from tb_alumnos where seccion= 'D' ");

            int acumulador = 0;

            foreach (DataRow dr in resp.Rows)
            {
                acumulador = acumulador + Convert.ToInt32(dr["parcial1"]);
                Console.WriteLine($"Seccion:{dr["seccion"]}  carnet={dr["carnet"]} nombre={dr["nombre"]} p1:{dr["parcial1"]}");
            }

        }


        public DataTable ConsultaSQL(string consulta)
        {
            ClsConexion cone = new();
            DataTable resp = cone.consultaTablaDirecta(consulta);

            return resp;
            //int acumulador = 0;

            //foreach (DataRow dr in resp.Rows)
            //{
            //    acumulador = acumulador + Convert.ToInt32(dr["parcial1"]);
            //    Console.WriteLine($"Seccion:{dr["seccion"]}  carnet={dr["carnet"]} nombre={dr["nombre"]} p1:{dr["parcial1"]}");
            //}

        }







        //public int promedios(string seccion)
        //{
        //    ClsConexion cone = new();
        //    DataTable resp = cone.consultaTablaDirecta($"select * from tb_alumnos where seccion= '{seccion}'");

        //    int acumulador = 0;

        //    foreach (DataRow dr in resp.Rows)
        //    {
        //        acumulador = acumulador + Convert.ToInt32(dr["parcial1"]);

        //    }

        //    int promedio = acumulador / resp.Rows.Count;
        //    return promedio;

        //}



        //public void cambia(string carnet, int nota)
        //{
        //    ClsConexion conse = new();
        //    conse.EjecutarSQLDirecto($"update tb_alumnos set parcial1 = {nota} where carnet='{carnet}'");
        //}



        //public void inserta(string nombre, string carnet, string correo, string clase, string seccion)
        //{

        //    ClsConexion cone = new();
        //    string instruccino = $"insert into tb_alumnos (carnet,nombre,correo,clase,seccion) values('{carnet}','{nombre}','{correo}','{clase}','{seccion}')";
        //    cone.EjecutarSQLDirecto(instruccino);
        //}



        public int crearAlumno(MdAlumno alu)
        {
            ClsConexion conn = new ClsConexion();
            string instruccion = $"insert into tb_alumnos (carnet,nombre,correo,clase,seccion,parcial1,parcial2,parcial3) values('{alu.carnet}','{alu.nombre}','{alu.correo}','{alu.clase}','{alu.seccion}','{alu.parcial1}','{alu.parcial2}','{alu.parcial3}')";
           

            return conn.EjecutarSQLDirecto(instruccion);
        }




        public MdAlumno ObtenerAlumno(string carnet)
        {
            ClsConexion conn = new ClsConexion();
            MdAlumno alu = new MdAlumno();

            DataTable resp = conn.consultaTablaDirecta($"select * from tb_alumnos where carnet ='{carnet}'");
            if (resp.Rows.Count > 0)
            {
                foreach (DataRow item in resp.Rows)
                {
                    alu.idAlumno = Convert.ToInt32(item["idAlumno"]);
                    alu.carnet = item["carnet"].ToString();
                    alu.nombre = item["nombre"].ToString();
                    alu.seccion = item["seccion"].ToString();
                    alu.clase = item["clase"].ToString();
                    alu.correo = item["correo"].ToString();
                    alu.parcial1 = Convert.ToInt32(item["parcial1"]);
                    alu.parcial2 = Convert.ToInt32(item["parcial2"]);
                    alu.parcial3 = Convert.ToInt32(item["parcial3"]);
                }
                return alu;
            }
            else
            {
                return null;
            }
        }




        public int actualizarAlumno(MdAlumno alu)
        {
            ClsConexion conn = new ClsConexion();
            string instruccion = $"update tb_alumnos set nombre = '{alu.nombre}',correo = '{alu.correo}',clase = '{alu.clase}',seccion= '{alu.seccion}',parcial1= '{alu.parcial1}',parcial2= '{alu.parcial2}',parcial3= '{alu.parcial3}' where carnet='{alu.carnet}'";


            return conn.EjecutarSQLDirecto(instruccion);
        }

        public int EliminarAlumno(MdAlumno alu)
        {
            ClsConexion conn = new ClsConexion();

            
            string instruccion = $"delete tb_alumnos where carnet='{alu.carnet}'";

            return conn.EjecutarSQLDirecto(instruccion);
     
        }
        

    }



    
}
