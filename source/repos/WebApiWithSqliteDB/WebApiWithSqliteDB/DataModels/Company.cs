using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiWithSqliteDB.DataModels
{
    [Table("Company")]
    public class Company
    {
        public string Id { get; set; }
        public string Name{ get; set; }
        public string Location { get; set; }

    }
}
