using System;
using System.Security.AccessControl;
using Microsoft.Win32;

namespace test_service
{
    public static class RegUpdater
    {
        public static void WriteKey(string company, string product) //идем в ветку создаем и пишем
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
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex.Message);
            }
        }
        //public static void RegAccess(RegistryKey key) //решить задачу как отобрать наследуемые права быстро решить не получилось, если потом придумаю обновлю
        //{
        //    try
        //    {
        //        var rs = new RegistrySecurity();
        //        var currentUser = Environment.UserDomainName + "\\" + Environment.UserName;
        //        //var users = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
        //        //NTAccount usersAc = users.Translate(typeof(NTAccount)) as NTAccount;
        //        //RegistryAccessRule usersDeny = new RegistryAccessRule(
        //        //    identity: usersAc?.ToString(),
        //        //    registryRights: RegistryRights.ReadKey,
        //        //    inheritanceFlags: InheritanceFlags.None,
        //        //    propagationFlags: PropagationFlags.NoPropagateInherit,
        //        //    type: AccessControlType.Deny);
        //        //rs.AddAccessRule(usersDeny);
        //        rs.AddAccessRule(new RegistryAccessRule(currentUser, //выдаю текущему пользователю права на чтение
        //            RegistryRights.ReadKey,
        //            InheritanceFlags.None,
        //            PropagationFlags.NoPropagateInherit,
        //            AccessControlType.Allow));

        //        key.SetAccessControl(rs);
        //        key.Close();
        //        Logging.WriteLog("Задали права");

        //    }
        //    catch (Exception ex)
        //    {
        //        Logging.WriteLog(ex.Message);
        //    }
        //}

    }
}
