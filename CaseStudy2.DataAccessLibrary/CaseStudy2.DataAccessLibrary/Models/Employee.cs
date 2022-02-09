using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy2.DataAccessLibrary.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; }

        public string Department { get; set; }
        public string Role { get; set; }
        [Required]
        public string Password { get; set; }
        public int SuperiorId { get; set; }
    }

    //Manage the user Role like employee/admin/customer
    /*public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }*/

    /*CREATE TABLE Users (
     *  Id INT NOT NULL IDENTITY(1,1), Firstname varchar(50) NOT NULL, LastName varchar(50) NOT NULL,
     *  Email varchar(100) NOT NULL, 
     *  CONSTRAINT pk_Users_Id PRIMARY KEY (Id)
     *  )
     *  CREATE TABLE Roles ( Id INT NOT NULL IDENTITY(1,1), RoleName varchar(50) NOT NULL,
     *      CONSTRAINT pk_Roles_Id PRIMARY KEY (Id)
     *  )
     *  CREATE TABLE UserRoles (
     *      UserId INT NOT NULL,
     *      RoleId INT NOT NULL,
     *      CONSTRAINT pk_UserRoles_id PRIMARY KEY (UserId, RoleId),
     *      CONSTRAINT fk_Users_Id FOREIGN KEY (UserId ) REFERENCES Users(Id),
     *      CONSTRAINT fk_Users_Id FOREIGN KEY (UserId ) REFERENCES Users(Id)
     *      )
     */
}
