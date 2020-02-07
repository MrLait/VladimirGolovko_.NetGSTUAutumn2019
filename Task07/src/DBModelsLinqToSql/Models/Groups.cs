using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Group table
    /// </summary>
    [Table(Name = "Groups")]
    public class Groups : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Number of group
        /// </summary>
        [Column(Name = "GroupName")]
        public string GroupName { get; set; }

        [Column(Name = "SpecialtiesID")]
        public int SpecialtiesID { get; set; }


        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Groups groups = (Groups)obj;

            return (ID == groups.ID) && (GroupName == groups.GroupName) && (SpecialtiesID == groups.SpecialtiesID);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return ID.GetHashCode() + GroupName.GetHashCode() + SpecialtiesID.GetHashCode();
        }
    }
}
