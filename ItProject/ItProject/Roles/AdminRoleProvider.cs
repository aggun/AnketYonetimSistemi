using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BussinesLayer.Concrete;
using Buss.Concrete;
using DataAccesLayer.EntityFramework;
using System.Text;
using DataAccesLayer.Concrete;

namespace ItProject.Roles
{
    public class AdminRoleProvider : RoleProvider
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        //admin rolu veritabanından çekilir.
        public override string[] GetRolesForUser(string username)
        {
            Context c = new Context();
            var x = c.admins.FirstOrDefault(y => y.AdminUsername == username);
            return new string[] { x.AdminRole };

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}