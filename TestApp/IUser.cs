using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    public interface IUser
    {
        string FirstName{get;set;}
        string Surname { get; set; }
        DateTime? DateOfBirth{get;set;}
        int Age();
    }
}
