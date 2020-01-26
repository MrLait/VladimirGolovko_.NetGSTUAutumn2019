namespace DAO.Enums
{
    /// <summary>
    /// DAO enum
    /// </summary>
    public enum DBAccessTechnologyEnum
    {
        /// <summary>
        /// Access to database with sqlClient and using Reflection technology
        /// </summary>
        SqlClientUsingReflection,

        /// <summary>
        /// Access to database with LINQtoSQL technology
        /// </summary>
        LINQtoSQL
    }
}
