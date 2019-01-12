using System.Collections.Generic;

namespace Geekbrains
{
    /// <summary>
    /// Класс контроллера пользовательского ввода
    /// </summary>
    /// <see cref="IUpdatable"/> <br/>
    /// <see cref="BaseController{T}"/> <br/>
    /// <see cref="BaseModel"/>
    public class InputController : BaseController<BaseModel>, IUpdatable
    {
        /// <summary>
        /// Список команд на исполнение
        /// </summary>
        private List<InputCommand> _commands;
        
        public InputController(BaseModel baseModel) : base(baseModel)
        {
            _commands = new List<InputCommand>();
        }

        /// <summary>
        /// Метод, где происходит считывание пользовательского ввода <br/>
        /// После того, как мы обнаружили пользовательский ввод, мы должны из InputCommandFactory достать объект команды/ <br/>
        /// Проинициализировав объект команды, его нужно добавить в список команд на исполнение. <br/>
        /// После этого система сама вернет объект команды в пул, а список команд для исполенния - очистится
        /// </summary>
        /// <param name="deltaTime"></param>
        public void OnUpdate(float deltaTime)
        {
            _commands.Clear();
            
            
            for ( var i = 0; i < _commands.Count; i++ ) {
                _commands[i].Execute();
            }
        }
    }
}