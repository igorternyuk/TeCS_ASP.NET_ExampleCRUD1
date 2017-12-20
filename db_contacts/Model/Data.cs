using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace db_contacts.Model
{
    public class Data: ICrud<Contact>
    {
        private const String SqlInsert = "INSERT INTO contact VALUES('{0}','{1}',{2},'{3}');";
        private const String SqlUpdate = "UPDATE contact SET name = '{0}', age = {1}, phone='{2}' WHERE id = {3};";
        private const String SqlDelete = "DELETE FROM contact WHERE id={0};";
        private const String SqlReadAll = "SELECT * FROM contact;";
        private const String SqlReadById = "SELECT * FROM contact WHERE id = {0};";
        private const String SqlSearch = "SELECT * from contact WHERE name LIKE '%{0}%';";
        private Connection con;
        private String query;

        public Data()
        {
            con = new Connection("COMPUTER-891624\\SQLEXPRESS", "db_contacts"); 
        }
        //CRUD
        //Create
        public void Create(Contact c)
        {
            query = String.Format(SqlInsert, c.Name, c.Sex, c.Age, c.Phone);
            //query = "INSERT INTO contact VALUES('Maria Cuevas','f',22,'+35854554223');";
            con.execute(query);
        }
        //Read(listing and search)
        public List<Contact> ReadAll()
        {
            List<Contact> result = new List<Contact>();
            query = SqlReadAll;
            con.execute(query);
            while (con.ResultSet.Read())
            {
                result.Add(getContactFromResultSet());
            }
            con.disconnect();
            return result;
        }

        public Contact ReadById(Object id)
        {
            query = String.Format(SqlReadById, Convert.ToInt32(id));
            con.execute(query);
            Contact contact = null;
            if (con.ResultSet.Read())
            {
                contact = getContactFromResultSet();
            }
            con.disconnect();
            return contact;
        }

        public List<Contact> Search(Object filter)
        {
            List<Contact> result = new List<Contact>();
            query = String.Format(SqlSearch, (string)filter);
            con.execute(query);
            while (con.ResultSet.Read())
            {
                result.Add(getContactFromResultSet());
            }
            con.disconnect();
            return result;
        }

        //Update

        public void Update(Contact c)
        {
            query = String.Format(SqlUpdate, c.Name, c.Age, c.Phone, c.Id);
            //query = "INSERT INTO contact VALUES('Maria Cuevas','f',22,'+35854554223');";
            con.execute(query);
        }
        //Delete

        public void Delete(Object id)
        {
            query = String.Format(SqlDelete, Convert.ToInt32(id));
            con.execute(query);
        }

        private Contact getContactFromResultSet()
        {
            Contact contact = new Contact();
            contact.Id = con.ResultSet.GetInt32(0);
            contact.Name = con.ResultSet.GetString(1);
            contact.Sex = con.ResultSet.GetString(2);
            contact.Age = con.ResultSet.GetInt32(3);
            contact.Phone = con.ResultSet.GetString(4);
            return contact;
        }

    }
}