
using Feonufry.CUI.Menu.Builders;

namespace SupplyClient {
    class Program {
        static void Main(string[] args) {
            new MenuBuilder()
                .Title("Снабжение")
                .Repeatable()
                .Submenu("Добавление контракта")
                    .Exit("Назад")
                    .End()
                .Submenu("Изменение состояний")
                    .Exit("Назад")
                    .End()
                .Exit("Закрыть").GetMenu().Run();
        }
    }
}
