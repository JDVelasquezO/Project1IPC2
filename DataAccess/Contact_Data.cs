using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Contact_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public Contact_Entity searchContact(int id)
        {
            Contact_Entity contact = new Contact_Entity();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("search_contact", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idClientBusiness";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                {
                    contact.id_contact = Convert.ToInt32(sqlDataReader["Identificador"]);
                    contact.name_contact = sqlDataReader["Nombre Contacto"].ToString();
                    contact.celphone = sqlDataReader["Celular Contacto"].ToString();
                    contact.officephone = sqlDataReader["Telefono Contacto"].ToString();
                    contact.address_office = sqlDataReader["Direccion Contacto"].ToString();
                    contact.dpi_contact = sqlDataReader["DPI Contacto"].ToString();
                    contact.email = sqlDataReader["Email Contacto"].ToString();
                    contact.extension = sqlDataReader["Ext Contacto"].ToString();
                    contact.typeContact.type_contact = sqlDataReader["Tipo Contacto"].ToString();
                    contact.client_business.id_client_business = Convert.ToInt32(sqlDataReader["Identificador Cliente"].ToString());
                    contact.client_business.name_client_business = sqlDataReader["Nombre Cliente"].ToString();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return contact;
        }
    }
}
