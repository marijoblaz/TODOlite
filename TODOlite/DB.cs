using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TODOlite
{
    class DB
    {
        public SqlConnection MyConnection { get; set; }

        public DB(string connetionString)
        {
            MyConnection = new SqlConnection(connetionString);

            try
            {
                MyConnection.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<tagModel> GetTagModels()
        {
            List<tagModel> output = new List<tagModel>();

            try
            {
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("select * from [dbo].[tag]",
                                                         MyConnection);
                myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    output.Add(new tagModel(Convert.ToInt32(myReader["tagPriority"]), myReader["content"].ToString()));
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        internal void Push(UIElementCollection children)
        {
            //First clear the table
            SqlCommand myCommand = new SqlCommand("delete [dbo].[tag]", MyConnection);
            myCommand.ExecuteNonQuery();

            foreach (var item in children)
            {
                int pri;

                switch (item.GetType().GetProperty("Background").GetValue(item).ToString())
                {
                    case "#FF82E48C":
                        pri = 1;
                        break;
                    
                    case "#FF82BFE5":
                        pri = 2;
                        break;
                    
                    case "#FFFF7C8A":
                        pri = 3;
                        break;

                    default:
                        pri = 0;
                        break;
                }


                SqlCommand myCommandAdd = new SqlCommand("INSERT INTO [dbo].[tag] (tagPriority, content) " +
                                     $"Values ({pri},'{item.GetType().GetProperty("Content").GetValue(item).ToString()}')", MyConnection);


                myCommandAdd.ExecuteNonQuery();
            }

        }
    }
}
