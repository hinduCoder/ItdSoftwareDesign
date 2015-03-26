using System;
using Feonufry.CUI;
using Feonufry.CUI.Actions;
using SupplyDomain.Api;

namespace SupplyClient
{
    public static class ActionExecutionContextExtension
    {
        public static int InputInt(this ActionExecutionContext context, string prompt)
        {
            context.Out.Write("{0}: ", prompt);
            return context.In.ReadInt32();  
        }

        public static string InputString(this ActionExecutionContext context, string prompt)
        {
            context.Out.Write("{0}: ", prompt);
            return context.In.ReadLine();
        }

        public static DateTime ReadDateTime(this IActionInput @in)
        {
            return DateTime.Parse(@in.ReadLine());
        }

        public static DateTime InputDateTime(this ActionExecutionContext context, string promt)
        {
            context.Out.Write("{0}: ", promt);
            return context.In.ReadDateTime();
        }

        public static string ConvertToString(this ContractDto contractDto)
        {
            return String.Format("\nНомер: {0}\nДата начала действия: {1:D}\nПериодичность: {2}\nДата окончания действия: {3:D}",
               contractDto.Number, contractDto.Period.StartDate, contractDto.Period.MonthRepetition, contractDto.Period.CloseDate);
        }
    }
}