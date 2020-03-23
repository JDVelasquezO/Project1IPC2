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

        public bool functionForAddContact(string procedure, Contact_Entity contact)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(procedure, sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_nameContact = new SqlParameter();
                p_nameContact.ParameterName = "@nameContact";
                p_nameContact.SqlDbType = SqlDbType.VarChar;
                p_nameContact.Size = 30;
                p_nameContact.Value = contact.name_contact;

                SqlParameter p_dpiContact = new SqlParameter();
                p_dpiContact.ParameterName = "@dpiContact";
                p_dpiContact.SqlDbType = SqlDbType.VarChar;
                p_dpiContact.Size = 20;
                p_dpiContact.Value = contact.dpi_contact;

                SqlParameter p_celContact = new SqlParameter();
                p_celContact.ParameterName = "@celContact";
                p_celContact.SqlDbType = SqlDbType.VarChar;
                p_celContact.Size = 10;
                p_celContact.Value = contact.celphone;

                SqlParameter p_officeContact = new SqlParameter();
                p_officeContact.ParameterName = "@officeContact";
                p_officeContact.SqlDbType = SqlDbType.VarChar;
                p_officeContact.Size = 10;
                p_officeContact.Value = contact.officephone;

                SqlParameter p_extension = new SqlParameter();
                p_extension.ParameterName = "@extension";
                p_extension.SqlDbType = SqlDbType.VarChar;
                p_extension.Size = 10;
                p_extension.Value = contact.extension;

                SqlParameter p_emailContact = new SqlParameter();
                p_emailContact.ParameterName = "@emailContact";
                p_emailContact.SqlDbType = SqlDbType.VarChar;
                p_emailContact.Size = 30;
                p_emailContact.Value = contact.email;

                SqlParameter p_addressContact = new SqlParameter();
                p_addressContact.ParameterName = "@addressContact";
                p_addressContact.SqlDbType = SqlDbType.VarChar;
                p_addressContact.Size = 30;
                p_addressContact.Value = contact.address_office;

                SqlParameter p_idClientBusiness = new SqlParameter();
                p_idClientBusiness.ParameterName = "@idClientBusiness";
                p_idClientBusiness.SqlDbType = SqlDbType.Int;
                p_idClientBusiness.Value = contact.client_business.id_client_business;

                sqlCommand.Parameters.Add(p_nameContact);
                sqlCommand.Parameters.Add(p_dpiContact);
                sqlCommand.Parameters.Add(p_celContact);
                sqlCommand.Parameters.Add(p_officeContact);
                sqlCommand.Parameters.Add(p_extension);
                sqlCommand.Parameters.Add(p_emailContact);
                sqlCommand.Parameters.Add(p_addressContact);
                sqlCommand.Parameters.Add(p_idClientBusiness);

                sqlCommand.ExecuteNonQuery();

                response = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return response;
        }

        public bool addComercialContact(Contact_Entity contact)
        {
            return this.functionForAddContact("add_comercial_contact", contact);
        }

        public bool addFinanceContact(Contact_Entity contact)
        {
            return this.functionForAddContact("add_finance_contact", contact);
        }

        public bool addAdminServices(AdminServices_Entity adminServices)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("add_admin_service", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
            
                SqlParameter p_client_business = new SqlParameter();
                p_client_business.ParameterName = "@idClientBusiness";
                p_client_business.SqlDbType = SqlDbType.Int;
                p_client_business.Value = adminServices.clientBusiness.id_client_business;

                sqlCommand.Parameters.Add(p_client_business);

                sqlCommand.ExecuteNonQuery();

                response = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return response;
        }

        public int returnIdAdminServices()
        {
            int idAdminServices = 0;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("return_id_adminServices", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                AdminServices_Entity adminServices = new AdminServices_Entity();

                while (sqlDataReader.Read())
                {
                    adminServices.id_admin_services = Convert.ToInt32(sqlDataReader["Identificador"]);
                }

                idAdminServices = adminServices.id_admin_services;

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return idAdminServices;
        }

        public bool addAdminServicesContact(Contact_Entity contact)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("add_adminService_contact", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter p_nameContact = new SqlParameter();
                p_nameContact.ParameterName = "@nameContact";
                p_nameContact.SqlDbType = SqlDbType.VarChar;
                p_nameContact.Size = 30;
                p_nameContact.Value = contact.name_contact;

                SqlParameter p_dpiContact = new SqlParameter();
                p_dpiContact.ParameterName = "@dpiContact";
                p_dpiContact.SqlDbType = SqlDbType.VarChar;
                p_dpiContact.Size = 20;
                p_dpiContact.Value = contact.dpi_contact;

                SqlParameter p_celContact = new SqlParameter();
                p_celContact.ParameterName = "@celContact";
                p_celContact.SqlDbType = SqlDbType.VarChar;
                p_celContact.Size = 10;
                p_celContact.Value = contact.celphone;

                SqlParameter p_officeContact = new SqlParameter();
                p_officeContact.ParameterName = "@officeContact";
                p_officeContact.SqlDbType = SqlDbType.VarChar;
                p_officeContact.Size = 10;
                p_officeContact.Value = contact.officephone;

                SqlParameter p_extension = new SqlParameter();
                p_extension.ParameterName = "@extension";
                p_extension.SqlDbType = SqlDbType.VarChar;
                p_extension.Size = 10;
                p_extension.Value = contact.extension;

                SqlParameter p_emailContact = new SqlParameter();
                p_emailContact.ParameterName = "@emailContact";
                p_emailContact.SqlDbType = SqlDbType.VarChar;
                p_emailContact.Size = 30;
                p_emailContact.Value = contact.email;

                SqlParameter p_addressContact = new SqlParameter();
                p_addressContact.ParameterName = "@addressContact";
                p_addressContact.SqlDbType = SqlDbType.VarChar;
                p_addressContact.Size = 30;
                p_addressContact.Value = contact.address_office;

                SqlParameter p_idClientBusiness = new SqlParameter();
                p_idClientBusiness.ParameterName = "@idClientBusiness";
                p_idClientBusiness.SqlDbType = SqlDbType.Int;
                p_idClientBusiness.Value = contact.client_business.id_client_business;

                SqlParameter p_idAdminSerives = new SqlParameter();
                p_idAdminSerives.ParameterName = "@idAdminServices";
                p_idAdminSerives.SqlDbType = SqlDbType.Int;
                p_idAdminSerives.Value = contact.adminServices.id_admin_services;

                sqlCommand.Parameters.Add(p_nameContact);
                sqlCommand.Parameters.Add(p_dpiContact);
                sqlCommand.Parameters.Add(p_celContact);
                sqlCommand.Parameters.Add(p_officeContact);
                sqlCommand.Parameters.Add(p_extension);
                sqlCommand.Parameters.Add(p_emailContact);
                sqlCommand.Parameters.Add(p_addressContact);
                sqlCommand.Parameters.Add(p_idClientBusiness);
                sqlCommand.Parameters.Add(p_idAdminSerives);

                sqlCommand.ExecuteNonQuery();

                response = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return response;
        }

        public Contact_Entity searchContact(int id)
        {
            Contact_Entity contact = new Contact_Entity();
        
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("search_contact", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idContact";
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
                    contact.password = sqlDataReader["Password"].ToString();
                    contact.extension = sqlDataReader["Ext Contacto"].ToString();
                    contact.typeContact.type_contact = sqlDataReader["Tipo Contacto"].ToString();
                    contact.client_business.id_client_business = Convert.ToInt32(sqlDataReader["Identificador Cliente"].ToString());
                    contact.client_business.name_client_business = sqlDataReader["Nombre Cliente"].ToString();
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return contact;
        }

        public List<Contact_Entity> returnCredentials()
        {
            List<Contact_Entity> list = new List<Contact_Entity>();

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("list_credentials_contact", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

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
                    contact.password = sqlDataReader["Password"].ToString();
                    contact.extension = sqlDataReader["Ext Contacto"].ToString();
                    contact.typeContact.id_typecontact = Convert.ToInt32(sqlDataReader["Tipo Contacto"]);
                    contact.client_business.id_client_business = Convert.ToInt32(sqlDataReader["Identificador Cliente"].ToString());
                    contact.client_business.name_client_business = sqlDataReader["Nombre Cliente"].ToString();

                    list.Add(contact);
                }

                sqlConnection.Close();
            }
            catch (Exception e)
            {
                throw;
            }

            return list;
        }

        public bool updatePassword (Contact_Entity contact)
        {
            bool response = false;

            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand("update_pass_contact", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_parameter = new SqlParameter();
                id_parameter.ParameterName = "@idContact";
                id_parameter.SqlDbType = SqlDbType.Int;
                id_parameter.Value = contact.id_contact;

                SqlParameter p_password = new SqlParameter();
                p_password.ParameterName = "@Password";
                p_password.SqlDbType = SqlDbType.VarChar;
                p_password.Size = 20;
                p_password.Value = contact.password;

                sqlCommand.Parameters.Add(id_parameter);
                sqlCommand.Parameters.Add(p_password);

                sqlCommand.ExecuteNonQuery();

                response = true;
            }
            catch (Exception e)
            {
                throw;
            }

            return response;
        }
    }
}
