using DBModelsLinqToSql.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace DBModelsLinqToSql.Models
{
    /// <summary>
    /// Group table model.
    /// </summary>
    [Table(Name = "Groups")]
    public class Groups : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }

        /// <summary>
        /// Group name column.
        /// </summary>
        [Column(Name = "GroupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Specialities id column.
        /// </summary>
        [Column(Name = "SpecialtiesID")]
        public int SpecialtiesID { get; set; }

        /// <summary>
        /// Overrides equals.
        /// </summary>
        /// <param name="obj">Equal object</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Groups groups = (Groups)obj;

            return (ID == groups.ID) && (GroupName == groups.GroupName) && (SpecialtiesID == groups.SpecialtiesID);
        }

        /// <summary>
        /// Override object.GetHashCode 
        /// </summary>
        /// <returns>Returns a new hash code.</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode() + GroupName.GetHashCode() + SpecialtiesID.GetHashCode();
        }
    }
}
