using EventEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDAL
{
    public class RegistrationRepository
    {
        public List<Registration> GetRegistrations(int eventId)
        {
            List<Registration> registrations = new List<Registration>();

            using(SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_GetRegistrations", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventID", eventId);

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    registrations.Add(
                        new Registration
                        {
                            RegistrationID = Convert.ToInt32(row["RegistrationID"]),
                            EventID = Convert.ToInt32(row["EventID"]),
                            ParticipantName = Convert.ToString(row["ParticipantName"]),
                            ParticipantEmail = Convert.ToString(row["ParticipantEmail"]),
                            RegistrationDate = Convert.ToDateTime(row["RegistrationDate"])
                        }
                    );
                }

            }
            return registrations;
        }

        public bool DeleteRegistration(int registrationId)
        {
            using(SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_DeleteRegistration", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@RegistrationID", registrationId);

                conn.Open();
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                bool result = i > 0 ? true : false;
                return result;
            }
        }

        public bool AddRegistration(Registration registration)
        {
            using(SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_AddRegistration", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventID", registration.EventID);
                sqlCommand.Parameters.AddWithValue("@ParticipantName", registration.ParticipantName);
                sqlCommand.Parameters.AddWithValue("@ParticipantEmail", registration.ParticipantEmail);
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);

                conn.Open();
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                bool result = i > 0 ? true : false;
                return result;
            }
        }

        public bool UpdateRegistration(Registration registration)
        {
            using(SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_UpdateRegistration", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventID", registration.EventID);
                sqlCommand.Parameters.AddWithValue("@RegistrationID", registration.RegistrationID);
                sqlCommand.Parameters.AddWithValue("@ParticipantName", registration.ParticipantName);
                sqlCommand.Parameters.AddWithValue("@ParticipantEmail", registration.ParticipantEmail);
                sqlCommand.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);

                conn.Open();
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                bool result = i > 0 ? true : false;
                return result;
            }
        }
    }
}
