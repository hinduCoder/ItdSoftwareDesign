using Feonufry.CUI.Actions;
using SupplyDomain.Api;

namespace SupplyClient.Actions
{
    public class ArchiveContractsAction : IAction
    {
        private readonly ContractApi _contractApi;

        public ArchiveContractsAction(ContractApi contractApi)
        {
            _contractApi = contractApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            var date = context.InputDateTime("Введите дату");
            var archiveContracts = _contractApi.GetArchiveContracts(date);
            foreach (var archiveContract in archiveContracts)
            {
                context.Out.WriteLine(archiveContract.ConvertToString());
            }
        }
    }
}