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
    public class EventRepository
    {
        public List<Event> eventsList = new List<Event>();

        public List<Event> GetEvents()
        {
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_GetEvents", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    eventsList.Add(
                        new Event
                        {
                            EventID = Convert.ToInt32(dr["EventID"]),                            
                            EventName = Convert.ToString(dr["EventName"]),
                            Description = Convert.ToString(dr["Description"]),
                            EventDate = Convert.ToDateTime(dr["EventDate"]),
                            Capacity = Convert.ToInt32(dr["Capacity"]),
                            Location = Convert.ToString(dr["Location"])
                        }
                    );
                }
            }

            return eventsList;
        }

        public bool AddEvent(Event eventParam)
        {
            using (SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_AddEvent", conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventName", eventParam.EventName);
                sqlCommand.Parameters.AddWithValue("@EventDate", eventParam.EventDate);
                sqlCommand.Parameters.AddWithValue("@Location", eventParam.Location);
                sqlCommand.Parameters.AddWithValue("@Description", eventParam.Description);
                sqlCommand.Parameters.AddWithValue("@Capacity", eventParam.Capacity);

                conn.Open();
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                bool result = i > 0 ? true : false;

                return result;
            }
        }

        public bool RemoveEvent(int eventId)
        {
            using(SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_DeleteEvent", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventID", eventId);

                conn.Open();
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                bool result = i > 0 ? true : false;

                return result;
            }
        }

        public bool UpdateEvent(Event eventParam)
        {
            using(SqlConnection conn = new SqlConnection(Connection.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_UpdateEvent", conn);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@EventID", eventParam.EventID);
                sqlCommand.Parameters.AddWithValue("@EventName", eventParam.EventName);
                sqlCommand.Parameters.AddWithValue("@EventDate", eventParam.EventDate);
                sqlCommand.Parameters.AddWithValue("@Location", eventParam.Location);
                sqlCommand.Parameters.AddWithValue("@Description", eventParam.Description);
                sqlCommand.Parameters.AddWithValue("@Capacity", eventParam.Capacity);

                conn.Open();
                int i = sqlCommand.ExecuteNonQuery();
                conn.Close();

                bool result = i > 0 ? true : false;
                return result;
            }
        }
    }
}
