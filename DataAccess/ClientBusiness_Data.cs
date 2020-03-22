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
    public class ClientBusiness_Data
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ToString());
        SqlCommand sqlCommand;

        public List<ClientBusiness_Entity> listClientBusiness()
        {
            List<ClientBusiness_Entity> list = new List<ClientBusiness_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_client_business", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    ClientBusiness_Entity client_business = new ClientBusiness_Entity();
                    client_business.id_client_business = Convert.ToInt32(sqlDataReader["Identificador"]);
                    client_business.name_client_business = sqlDataReader["Nombre Empresa"].ToString();

                    list.Add(client_business);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public ClientBusiness_Entity searchClientBusiness(int id)
        {
            ClientBusiness_Entity client_business = new ClientBusiness_Entity();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("search_client_business", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idClient";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = id;

                sqlCommand.Parameters.Add(id_parameter);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();

                if (sqlDataReader.HasRows)
                {
                    client_business.id_client_business = Convert.ToInt32(sqlDataReader["Identificador"]);
                    client_business.name_client_business = sqlDataReader["Nombre Empresa"].ToString();
                    client_business.quantity_employees = Convert.ToInt32(sqlDataReader["Cantidad de Empleados"]);
                    client_business.typeBusiness_Entity.type_business = sqlDataReader["Tipo de Empresa"].ToString();
                    client_business.sizeBusiness_Entity.size = sqlDataReader["Tamaño de Empresa"].ToString();
                    client_business.typeCard_Entity.type_card = sqlDataReader["Tarjeta de Crédito"].ToString();
                    client_business.sizeBusiness_Entity.name_size = sqlDataReader["Nombre Tamaño"].ToString();
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return client_business;
        }

        public bool addClientBusiness(ClientBusiness_Entity client_business)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("add_client_business", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_idTypeBusiness = new SqlParameter();
                p_idTypeBusiness.ParameterName = "@idTypeBusiness";
                p_idTypeBusiness.SqlDbType = SqlDbType.Int;
                p_idTypeBusiness.Value = client_business.typeBusiness_Entity.id_type_business;

                SqlParameter p_idSizeBusiness = new SqlParameter();
                p_idSizeBusiness.ParameterName = "@idSizebusiness";
                p_idSizeBusiness.SqlDbType = SqlDbType.Int;
                p_idSizeBusiness.Value = client_business.sizeBusiness_Entity.id_size_business;

                SqlParameter p_idCreditCard = new SqlParameter();
                p_idCreditCard.ParameterName = "@idCreditCard";
                p_idCreditCard.SqlDbType = SqlDbType.Int;
                p_idCreditCard.Value = client_business.creditCard_Entity.id_credit_card;

                SqlParameter p_nit = new SqlParameter();
                p_nit.ParameterName = "@nit";
                p_nit.SqlDbType = SqlDbType.VarChar;
                p_nit.Size = 20;
                p_nit.Value = client_business.nit;

                SqlParameter p_nameClientBusiness = new SqlParameter();
                p_nameClientBusiness.ParameterName = "@nameClientBusiness";
                p_nameClientBusiness.SqlDbType = SqlDbType.VarChar;
                p_nameClientBusiness.Size = 20;
                p_nameClientBusiness.Value = client_business.name_client_business;

                SqlParameter p_quantityEmployees = new SqlParameter();
                p_quantityEmployees.ParameterName = "@quantityEmployess";
                p_quantityEmployees.SqlDbType = SqlDbType.Int;
                p_quantityEmployees.Value = client_business.quantity_employees;

                sqlCommand.Parameters.Add(p_idTypeBusiness);
                sqlCommand.Parameters.Add(p_idSizeBusiness);
                sqlCommand.Parameters.Add(p_idCreditCard);
                sqlCommand.Parameters.Add(p_nit);
                sqlCommand.Parameters.Add(p_nameClientBusiness);
                sqlCommand.Parameters.Add(p_quantityEmployees);

                sqlCommand.ExecuteNonQuery();

                response = true;
            }
            catch(Exception e)
            {
                throw;
            }

            return response;
        }

        public bool deleteClientBusiness(int id)
        {
            bool deleted = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("delete_client_business", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_client_business = new SqlParameter();
                id_client_business.ParameterName = "@idClientBusiness";
                id_client_business.SqlDbType = SqlDbType.Int;
                id_client_business.Value = id;

                sqlCommand.Parameters.Add(id_client_business);
                sqlCommand.ExecuteNonQuery();

                deleted = true;

            }
            catch (Exception e)
            {
                throw;
            }

            return deleted;
        }

        public List<Contact_Entity> searchContact(int id)
        {
            List<Contact_Entity> list = new List<Contact_Entity>();

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

                while (sqlDataReader.Read())
                {
                    Contact_Entity contact = new Contact_Entity();
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

                    list.Add(contact);
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }
    }
}
