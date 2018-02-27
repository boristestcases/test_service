using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using Microsoft.Win32;

namespace test_service
{
    public static class regUpdater
    {
        public static void WriteKey(string company, string product)
        {
            try
            {
                var key = Registry.LocalMachine.OpenSubKey("Software", true);
                key?.CreateSubKey(company, RegistryKeyPermissionCheck.ReadWriteSubTree);
                key = key?.OpenSubKey(company, true);
                key?.CreateSubKey(product, RegistryKeyPermissionCheck.ReadWriteSubTree);
                key = key?.OpenSubKey(product, true);
                key?.SetValue("URL", "localhost", RegistryValueKind.String);
                Logging.WriteLog("записали ключ в реестр");
                RegAccess(key);
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message);
            }
        }

        public static void RegAccess(RegistryKey key)
        {
            try
            {
                var rs = new RegistrySecurity();
                var currentUser = Environment.UserDomainName + "\\" + Environment.UserName;
                //var users = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
                //NTAccount usersAc = users.Translate(typeof(NTAccount)) as NTAccount;
                //RegistryAccessRule usersDeny = new RegistryAccessRule(
                //    identity: usersAc?.ToString(),
                //    registryRights: RegistryRights.ReadKey,
                //    inheritanceFlags: InheritanceFlags.None,
                //    propagationFlags: PropagationFlags.NoPropagateInherit,
                //    type: AccessControlType.Deny);
                //rs.AddAccessRule(usersDeny);
                rs.AddAccessRule(new RegistryAccessRule(currentUser,
                    RegistryRights.ReadKey,
                    InheritanceFlags.None,
                    PropagationFlags.NoPropagateInherit,
                    AccessControlType.Allow));

                key.SetAccessControl(rs);
                key.Close();
                Logging.WriteLog("Задали права");

            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message);
            }
        }

    }
}
