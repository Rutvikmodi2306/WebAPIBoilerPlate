using WebAPIBoilerPlate.Debugging;

namespace WebAPIBoilerPlate
{
    public class WebAPIBoilerPlateConsts
    {
        public const string LocalizationSourceName = "WebAPIBoilerPlate";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "f49481890d6a4fdcb4ebbe3662ea09b0";
    }
}
