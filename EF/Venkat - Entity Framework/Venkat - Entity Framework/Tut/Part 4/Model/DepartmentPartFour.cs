using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Venkat___Entity_Framework.Tut.Part_4.Model
{
    //POI: EF searches for Model name (Type name) in the whole assembly ignoring namespace. From EF's 
    //stand point it causes multiple Models with the same name to co-exist which definitely causes error
    //'The mapping of CLR type to EDM type is ambiguous because multiple CLR types match the EDM type .....'

    //POI: This EF issue makes sense considering DB tables are qualified by DB schema which has no relation
    //with .NET namespace

    //BP: One assembly shouldn't contain multiple Models with the same name both which might be included 
    //as DbSet<TModel> to the DbContext class

    [Table("Department")]
    public class DepartmentPartFour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        //POI: If 'Include' is required to be used to get the navigation property values then this navigation
        //property name has to be used in the string of Include method

        public List<EmployeePartFour> Employees { get; set; }
    }
}