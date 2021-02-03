using System;
using System.Collections.Generic;
using System.Text;

namespace GameSalesProject.Entities.Abstract
{
    public interface IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string DateOfBirth { get; set; }
        public string NationalIdentity { get; set; }
    }
}
