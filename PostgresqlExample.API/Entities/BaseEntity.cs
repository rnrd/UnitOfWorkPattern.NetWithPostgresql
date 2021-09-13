using System;
using System.Collections.Generic;
using System.Text;

namespace PostgresqlExample.Data.Entities
{
    //This clas will be abstract and our model will inherit this.
    public abstract class BaseEntity
    {
        public int Id { get; set; } //primary key of database table

        public bool IsActive { get; set; } = true; //checking parameter for a row in database  activation. True as Default.

        public DateTime CreatedTime { get; set; } = DateTime.Now; // while creating a row in the table, timestamp  will be created automatically.

        public DateTime? UpdatedTime { get; set; } //DateTime? here ? means nullable, this property can be null in the table
    }
}
