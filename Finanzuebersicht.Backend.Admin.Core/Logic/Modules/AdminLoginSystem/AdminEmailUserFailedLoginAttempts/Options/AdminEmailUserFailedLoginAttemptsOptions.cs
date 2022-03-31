namespace Finanzuebersicht.Backend.Admin.Core.Logic.Modules.AdminLoginSystem.AdminEmailUserFailedLoginAttempts
{
    internal class AdminEmailUserFailedLoginAttemptsOptions : OptionsFromConfiguration
    {
        public override string Position => "FinanzuebersichtAdminCore:AdminLoginSystem:AdminEmailUser:FailedLoginAttempts";

        public bool RunOnInitialization { get; set; }

        public int ThresholdInMinutes { get; set; }

        public int MaxCount { get; set; }
    }
}