using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.Entities.Abstract
{
    public interface IPerson
    {
        int Id { get; set; }
        string Name { get; set; }
        string LastName { get; set; }
        string Country { get; set; }
        string DateOfBirth { get; set; }
        string NationalIdentity { get; set; }
    }
}
