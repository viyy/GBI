using System.Collections.Generic;

namespace Geekbrains
{
    public class InputController : BaseController<BaseModel>, IUpdatable
    {
        private List<InputCommand> _commands;
        
        public InputController(BaseModel baseModel) : base(baseModel)
        {
            _commands = new List<InputCommand>();
        }

        public void OnUpdate(float deltaTime)
        {
            _commands.Clear();

            // здесь проверять нажатия кнопок из Input
            // и создавать команды через InputCommandFactory.GetCommand<InputCommand>();
            // возможно стоит пересмотреть такую модель, но я сейчас хочу спать)
            
            _commands.ForEach(command => command.Execute());
        }
    }
}