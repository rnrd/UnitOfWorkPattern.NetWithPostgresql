using System;
using System.Collections.Generic;
using System.Text;

namespace PostgresqlExample.Data.Entities
{
    //This will be our entity class
    public class Article : BaseEntity
    {
        public string Title { get; set; } //Article title

        public string Description { get; set; } //Article description
    }
}
