using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace db_contacts.Model
{
    /*
CREATE TABLE contact(
    id INT IDENTITY(1,1),
    name VARCHAR(100),
    sex VARCHAR(1),
    age INT,
    phoneone VARCHAR(50),
    PRIMARY KEY(id)
);
*/
    public class Contact
    {
        private int id;
        private string name;
        private string sex;
        private int age;
        private string phone;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
}