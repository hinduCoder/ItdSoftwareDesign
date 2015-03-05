using Feonufry.CUI.Actions;

namespace SupplyClient
{
    public static class ActionExecutionContextExtension
    {
        public static string InputString(this ActionExecutionContext context, string prompt)
        {
            context.Out.Write("{0}: ");
            return context.In.ReadLine();
        }
    }
}