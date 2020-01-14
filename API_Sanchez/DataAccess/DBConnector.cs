using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace DataAccess
{
    public class DBConnector
    {
        private string dbConnection;
        
        public DBConnector()
        {
            dbConnection = ConfigurationManager.ConnectionStrings["DB_MainConnection"].ConnectionString;
        }

        public Car addCar(Car pCar)
        {
            //command.ExecuteNonQuery();
            SqlConnection con = new SqlConnection(dbConnection);
            SqlCommand cmd = new SqlCommand("addCar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("anio", SqlDbType.VarChar);
            param.Value = pCar.anio;
            param = cmd.Parameters.Add("color", SqlDbType.VarChar);
            param.Value = pCar.color;
            param = cmd.Parameters.Add("marca", SqlDbType.VarChar);
            param.Value = pCar.marca;
            param = cmd.Parameters.Add("placa", SqlDbType.Int);
            param.Value = pCar.placa;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return pCar;
        }

        public Car deleteCar(Car pCar)
        {
            //command.ExecuteNonQuery();
            SqlConnection con = new SqlConnection(dbConnection);
            SqlCommand cmd = new SqlCommand("deleteCar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("id", SqlDbType.Int);
            param.Value = pCar.id;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return pCar;
        }

        public List<Car> getCars()
        {
            List<Car> carList = new List<Car>();
            SqlConnection con = new SqlConnection(dbConnection);
            SqlCommand cmd = new SqlCommand("getCars", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("id", SqlDbType.Int);
            param.Value = 0;
            con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Car objCar = new Car();
                    objCar.id = Int32.Parse(reader["id"].ToString());
                    objCar.placa = Int32.Parse(reader["placa"].ToString());
                    objCar.marca = reader["marca"].ToString();
                    objCar.anio = reader["anio"].ToString();
                    objCar.color = reader["color"].ToString();
                    carList.Add(objCar);                    
                }
            }
            return carList;
        }

        public Car getCars(Car pCar)
        {
            Car objCar = new Car();
            SqlConnection con = new SqlConnection(dbConnection);
            SqlCommand cmd = new SqlCommand("getCars", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("id", SqlDbType.Int);
            param.Value = pCar.id;
            con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    objCar.id = Int32.Parse(reader["id"].ToString());
                    objCar.placa = Int32.Parse(reader["placa"].ToString());
                    objCar.marca = reader["marca"].ToString();
                    objCar.anio = reader["anio"].ToString();
                    objCar.color = reader["color"].ToString();
                }
            }
            return objCar;
        }

        public Car updateCar(Car pCar)
        {
            //command.ExecuteNonQuery();
            SqlConnection con = new SqlConnection(dbConnection);
            SqlCommand cmd = new SqlCommand("updateCar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = cmd.Parameters.Add("id", SqlDbType.Int);
            param.Value = pCar.id;
            param = cmd.Parameters.Add("anio", SqlDbType.VarChar);
            param.Value = pCar.anio;
            param = cmd.Parameters.Add("color", SqlDbType.VarChar);
            param.Value = pCar.color;
            param = cmd.Parameters.Add("marca", SqlDbType.VarChar);
            param.Value = pCar.marca;
            param = cmd.Parameters.Add("placa", SqlDbType.Int);
            param.Value = pCar.placa;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return pCar;
        }

    }
}
